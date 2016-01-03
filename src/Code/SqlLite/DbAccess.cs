using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Steve.SqlLite
{
	/// <summary>
	///   Summary description for DbAccess.
	/// </summary>
	public class GlobalDB
	{
		public static int GetNewID(string tableName)
		{
			var sb = new StringBuilder();

			sb.Append("SELECT ");
			sb.Append("max(ID)");
			sb.Append(" FROM ");
			sb.Append(tableName);

			//Object res = OleDbHelper.ExecuteScalar(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				var sql = sb.ToString();
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					var res = command.ExecuteScalar(CommandBehavior.CloseConnection);

					return (res != DBNull.Value) ? Convert.ToInt32(res) + 1 : 1;
				}
			}
		}

		public static DataTable ListProvince()
		{
			var ds = new DataSet();

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
				//var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]);
			{
				dbConnection.Open();
				var sql = "SELECT sigla, descrizione FROM lkp_provincia ORDER BY descrizione";
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					//return command.ExecuteReader(CommandBehavior.CloseConnection);
					using (var myAdapter = new SQLiteDataAdapter(command))
					{
						myAdapter.Fill(ds);
					}
				}
			}

			return ds.Tables[0];

			//return OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sql, null);
		}

		public static bool CheckConn(ref string numPazienti)
		{
			bool bRes;

			try
			{
				var sb = new StringBuilder();

				sb.Append("SELECT ");
				sb.Append("count(ID)");
				sb.Append(" FROM ");
				sb.Append("paziente");

				object res = null;
				using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
				{
					dbConnection.Open();
					var sql = sb.ToString();
					using (var command = new SQLiteCommand(sql, dbConnection))
					{
						res = command.ExecuteScalar(CommandBehavior.CloseConnection);
						//Object res = OleDbHelper.ExecuteScalar( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );
					}
				}

				numPazienti = res.ToString();

				bRes = true;
			}
			catch (Exception exc)
			{
				bRes = false;

				numPazienti = exc.Message;
			}

			return bRes;
		}
	}
}