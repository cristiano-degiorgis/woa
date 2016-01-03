using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Steve.SqlLite;

namespace Steve
{
	public class TrattamentoDB
	{
		public static bool SalvaDati(ref Trattamento trattamento, ref string sMsg)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@data", DbType.DateTime, trattamento.Data),
					new MySqlLiteParameter("@descrizione", DbType.String, trattamento.Descrizione),
					new MySqlLiteParameter("@id_paziente", DbType.Int32, trattamento.IdPaziente),
					new MySqlLiteParameter("@id_consulto", DbType.Int32, trattamento.IdConsulto)
				};

				if (trattamento.ID == -1)
				{
					sb.Append("INSERT INTO ");
					sb.Append("trattamento");
					sb.Append("( data, descrizione,id_paziente, id_consulto )");
					sb.Append(" VALUES ");
					sb.Append("( @data, @descrizione, @id_paziente, @id_consulto )");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					trattamento.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@ID", DbType.Int32, trattamento.ID));

					sb.Append("UPDATE ");
					sb.Append("trattamento");
					sb.Append(" SET ");
					sb.Append("data=@data,");
					sb.Append("descrizione=@descrizione,");
					sb.Append("id_paziente=@id_paziente,");
					sb.Append("id_consulto=@id_consulto");
					sb.Append(" WHERE ");
					sb.Append("ID = @ID");

					SqlLiteHelper.Update(sb.ToString(), arParams);
				}

				bResult = true;
			}
			catch (Exception ex)
			{
				bResult = false;
				sMsg = ex.Message;
			}

			return bResult;
		}

		public static Trattamento GetTrattamento(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("trattamento");
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			Trattamento trattamento = null;
			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				trattamento = new Trattamento();
				trattamento.ID = id;
				trattamento.Data = (DateTime) reader["data"];
				trattamento.Descrizione = reader["descrizione"].ToString();
				trattamento.IdPaziente = (int)(long)reader["ID_paziente"];
				trattamento.IdConsulto = (int)(long)reader["ID_consulto"];
			});

			return trattamento;
		}

		public static DataTable TrattamentiList(int idConsulto)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("ID,");
			sb.Append("data,");
			sb.Append("substr(descrizione,1,100) as descrizione");
			sb.Append(" FROM ");
			sb.Append("trattamento");
			sb.Append(" WHERE ");
			sb.Append("id_consulto = " + idConsulto);
			sb.Append(" ORDER BY ");
			sb.Append("data ASC");

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}
	}
}