using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Steve.SqlLite;

namespace Steve
{
	public class ValutazioneDB
	{
		public static bool SalvaDati(ref Valutazione valutazione, ref string sMsg)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@strutturale", DbType.String, valutazione.Strutturale),
					new MySqlLiteParameter("@cranio_sacrale", DbType.String, valutazione.CranioSacrale),
					new MySqlLiteParameter("@ak_ortodontica", DbType.String, valutazione.AkOrtodontica),
					new MySqlLiteParameter("@id_paziente", DbType.Int32, valutazione.IdPaziente),
					new MySqlLiteParameter("@id_consulto", DbType.Int32, valutazione.IdConsulto)
				};


				if (valutazione.ID == -1)
				{
					sb.Append("INSERT INTO ");
					sb.Append("valutazione");
					sb.Append("( strutturale, cranio_sacrale, ak_ortodontica, id_paziente, id_consulto)");
					sb.Append(" VALUES ");
					sb.Append("( @strutturale, @cranio_sacrale, @ak_ortodontica, @id_paziente, @id_consulto)");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					valutazione.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@ID", DbType.Int32, valutazione.ID));


					sb.Append("UPDATE ");
					sb.Append("valutazione");
					sb.Append(" SET ");
					sb.Append("strutturale=@strutturale,");
					sb.Append("cranio_sacrale=@cranio_sacrale,");
					sb.Append("ak_ortodontica=@ak_ortodontica,");
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

		public static Valutazione GetValutazione(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("valutazione");
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			Valutazione valutazione = null;

			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				valutazione = new Valutazione();
				valutazione.ID = id;
				valutazione.Strutturale = reader["strutturale"].ToString();
				valutazione.CranioSacrale = reader["cranio_sacrale"].ToString();
				valutazione.AkOrtodontica = reader["ak_ortodontica"].ToString();
				valutazione.IdPaziente = (int) (long) reader["ID_paziente"];
				valutazione.IdConsulto = (int) (long) reader["ID_consulto"];
			});

			return valutazione;
		}

		public static DataTable ValutazioniList(int idConsulto)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("ID,");
			sb.Append("substr(strutturale,1,100) as strutturale,");
			sb.Append("substr(cranio_sacrale,1,100) as cranio_sacrale,");
			sb.Append("substr(ak_ortodontica,1,100) as ak_ortodontica");
			sb.Append(" FROM ");
			sb.Append("valutazione");
			sb.Append(" WHERE ");
			sb.Append("id_consulto = " + idConsulto);

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}
	}
}