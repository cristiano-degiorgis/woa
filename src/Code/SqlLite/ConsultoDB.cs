using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Steve.SqlLite
{
	public class ConsultoDB
	{
		public static bool SalvaDati(ref Consulto consulto, ref string sMsg)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@id_paziente", DbType.Int32, consulto.IdPaziente),
					new MySqlLiteParameter("@data", DbType.DateTime, consulto.Data),
					new MySqlLiteParameter("@problema_iniziale", DbType.String, consulto.ProblemaIniziale)
				};

				if (consulto.ID == -1)
				{
					sb.Append("INSERT INTO ");
					sb.Append("consulto");
					sb.Append("( id_paziente, data, problema_iniziale)");
					sb.Append(" VALUES ");
					sb.Append("( @id_paziente, @data, @problema_iniziale)");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					consulto.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@ID", DbType.Int32, consulto.ID));


					sb.Append("UPDATE ");
					sb.Append("consulto");
					sb.Append(" SET ");
					sb.Append("id_paziente=@id_paziente,");
					sb.Append("data=@data,");
					sb.Append("problema_iniziale=@problema_iniziale");
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

		public static Consulto GetConsulto(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("consulto");
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			Consulto consulto = null;
			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				consulto = new Consulto();
				consulto.ID = id;
				consulto.Data = (DateTime) reader["data"];
				consulto.IdPaziente = (int)(long) reader["id_paziente"];
				consulto.ProblemaIniziale = reader["problema_iniziale"].ToString();
			});

			return consulto;
		}

		public static DataTable ConsultiList(int idPaziente)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("consulto.*,");
			sb.Append("anamnesi_prossima.id_consulto,");
			sb.Append("(SELECT count(*) FROM esame WHERE ID_consulto=consulto.ID) AS Esami,");
			sb.Append("(SELECT count(*) FROM trattamento WHERE ID_consulto=consulto.ID) AS Trattamenti,");
			sb.Append("(SELECT count(*) FROM valutazione WHERE ID_consulto=consulto.ID) AS Valutazioni");
			sb.Append(" FROM ");
			sb.Append("consulto");
			sb.Append(" LEFT JOIN ");
			sb.Append("anamnesi_prossima");
			sb.Append(" ON ");
			sb.Append("consulto.ID = anamnesi_prossima.id_consulto");
			sb.Append(" WHERE ");
			sb.Append("consulto.id_paziente = " + idPaziente);
			sb.Append(" ORDER BY ");
			sb.Append("consulto.data ASC");

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}
	}
}