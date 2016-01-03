using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace Steve.SqlLite
{
	public class MySqlLiteParameter
	{
		public MySqlLiteParameter(string name, DbType dbType, object value)
		{
			Name = name;
			DbType = dbType;
			Value = value;
		}

		public string Name { get; set; }
		public object Value { get; set; }
		public DbType DbType { get; set; }
	}

	public static class SqlLiteHelper
	{
		public static void Insert(string sql, IList<MySqlLiteParameter> parameters, out int newId)
		{
			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					var sqlLiteParameters = parameters
						.Select(x => new SQLiteParameter(x.Name, x.DbType) {Value = x.Value})
						.ToArray();
					command.Parameters.AddRange(sqlLiteParameters);
					command.ExecuteNonQuery();
				}

				sql = "select last_insert_rowid();";
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					newId = (int) (long) command.ExecuteScalar();
				}
			}
		}

		public static void FillEntity(string sql, Action<IDataReader> fillFn)
		{
			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							fillFn(reader);
						}
					}
				}
			}
		}

		public static void Update(string sql, IList<MySqlLiteParameter> parameters)
		{
			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					var sqlLiteParameters = parameters
						.Select(x => new SQLiteParameter(x.Name, x.DbType) {Value = x.Value})
						.ToArray();
					command.Parameters.AddRange(sqlLiteParameters);
					command.ExecuteNonQuery();
				}
			}
		}

		public static DataTable GetDataTable(string sql)
		{
			var ds = new DataSet();

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				Debug.WriteLine(sql);
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					var myAdapter = new SQLiteDataAdapter(command);
					myAdapter.Fill(ds);
				}
			}

			// Setto la chiave primaria sulla tabella del DataSet
			var dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			var dt = ds.Tables[0];

			var dtCloned = dt.Clone();
			for (var i = 0; i < dtCloned.Columns.Count; i++)
			{
				var dc = dtCloned.Columns[i];
				if (dc.DataType == typeof (long))
				{
					dtCloned.Columns[i].DataType = typeof (int);
				}
			}

			foreach (DataRow row in dt.Rows)
			{
				dtCloned.ImportRow(row);
			}

			return dtCloned;
		}

		public static DataTable GetLookUpDataTable(string sqlTableName)
		{
			var ds = new DataSet();

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				var sql = "SELECT * FROM " + sqlTableName;
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					using (var myAdapter = new SQLiteDataAdapter(command))
					{
						myAdapter.Fill(ds);
					}
				}
			}

			return ds.Tables[0];
		}

		public static void Delete(int idPaziente)
		{
			var myQueries = new[]
			{
				string.Format("DELETE FROM {0} WHERE ID_paziente={1}", "esame", idPaziente),
				string.Format("DELETE FROM {0} WHERE ID_paziente={1}", "anamnesi_prossima", idPaziente),
				string.Format("DELETE FROM {0} WHERE ID_paziente={1}", "valutazione", idPaziente),
				string.Format("DELETE FROM {0} WHERE ID_paziente={1}", "consulto", idPaziente),
				string.Format("DELETE FROM {0} WHERE ID_paziente={1}", "anamnesi_remota", idPaziente),
				string.Format("DELETE FROM {0} WHERE ID={1}", "paziente", idPaziente)
			};

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				using (var tra = dbConnection.BeginTransaction())
				{
					try
					{
						foreach (var myQuery in myQueries)
						{
							using (var cd = new SQLiteCommand(myQuery, dbConnection, tra))
							{
								cd.ExecuteNonQuery();
							}
						}

						tra.Commit();
					}
					catch
					{
						tra.Rollback();
						throw;
					}
				}
			}
		}
	}
}