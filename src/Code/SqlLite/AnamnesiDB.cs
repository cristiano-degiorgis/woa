using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Steve.SqlLite
{
	public class AnamnesiDB
	{
		public static DataTable ListTipiAnamnesiRemota()
		{
			return SqlLiteHelper.GetLookUpDataTable("lkp_anamnesi");
		}

		public static bool SalvaDati(AnamnesiRemota anamnesi, ref string sMsg, eAzioni azione)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@data", DbType.DateTime, anamnesi.Data),
					new MySqlLiteParameter("@descrizione", DbType.String, anamnesi.Descrizione),
					new MySqlLiteParameter("@tipo", DbType.Int32, anamnesi.Tipo),
					new MySqlLiteParameter("@id_paziente", DbType.Int32, anamnesi.IdPaziente)
				};

				if (azione == eAzioni.Insert)
				{
					sb.Append("INSERT INTO ");
					sb.Append("anamnesi_remota");
					sb.Append("( data, descrizione, tipo, id_paziente)");
					sb.Append(" VALUES ");
					sb.Append("(@data, @descrizione, @tipo, @id_paziente)");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					anamnesi.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@id", DbType.Int32, anamnesi.ID));

					sb.Append("UPDATE ");
					sb.Append("anamnesi_remota");
					sb.Append(" SET ");
					sb.Append("data=@data,");
					sb.Append("descrizione=@descrizione,");
					sb.Append("tipo=@tipo,");
					sb.Append("id_paziente = @id_paziente");
					sb.Append(" WHERE ");
					sb.Append("id = @id");

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

		public static bool SalvaDati(AnamnesiProssima anamnesi, ref string sMsg, eAzioni azione)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@prima_volta", DbType.String, anamnesi.PrimaVolta),
					new MySqlLiteParameter("@tipologia", DbType.String, anamnesi.Tipologia),
					new MySqlLiteParameter("@localizzazione", DbType.String, anamnesi.Localizzazione),
					new MySqlLiteParameter("@irradiazione", DbType.String, anamnesi.Irradiazione),
					new MySqlLiteParameter("@periodo_insorgenza", DbType.String, anamnesi.PeriodoInsorgenza),
					new MySqlLiteParameter("@durata", DbType.String, anamnesi.Durata),
					new MySqlLiteParameter("@familiarita", DbType.String, anamnesi.Familiarita),
					new MySqlLiteParameter("@altre_terapie", DbType.String, anamnesi.AltreTerapie),
					new MySqlLiteParameter("@varie", DbType.String, anamnesi.Varie),
					new MySqlLiteParameter("@id_paziente", DbType.Int32, anamnesi.IdPaziente),
					new MySqlLiteParameter("@id_consulto", DbType.Int32, anamnesi.IdConsulto)
				};

				if (azione == eAzioni.Insert)
				{
					sb.Append("INSERT INTO ");
					sb.Append("anamnesi_prossima");
					sb.Append(
						"( prima_volta, tipologia, localizzazione, irradiazione, periodo_insorgenza, durata, familiarita, altre_terapie, varie, id_paziente, id_consulto )");
					sb.Append(" VALUES ");
					sb.Append(
						"( @prima_volta, @tipologia, @localizzazione, @irradiazione, @periodo_insorgenza, @durata, @familiarita, @altre_terapie, @varie, @id_paziente, @id_consulto )");

					var sql = sb.ToString();
					int newID;
					SqlLiteHelper.Insert(sql, arParams, out newID);
					anamnesi.ID = newID;
				}
				else
				{
					sb.Append("UPDATE ");
					sb.Append("anamnesi_prossima");
					sb.Append(" SET ");
					sb.Append("prima_volta=@prima_volta,");
					sb.Append("tipologia=@tipologia,");
					sb.Append("localizzazione=@localizzazione,");
					sb.Append("irradiazione=@irradiazione,");
					sb.Append("periodo_insorgenza=@periodo_insorgenza,");
					sb.Append("durata=@durata,");
					sb.Append("familiarita=@familiarita,");
					sb.Append("altre_terapie=@altre_terapie,");
					sb.Append("varie=@varie,");
					sb.Append("id_paziente=@id_paziente");
					sb.Append(" WHERE ");
					sb.Append("id_consulto = @id_consulto");

					var sql = sb.ToString();
					SqlLiteHelper.Update(sql, arParams);
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

		public static AnamnesiRemota GetRemota(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("anamnesi_remota");
			sb.Append(" WHERE ");
			sb.Append("id=" + id);

			AnamnesiRemota ar = null;

			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				ar = new AnamnesiRemota();
				ar.ID = id;
				ar.IdPaziente = (int)(long) reader["id_paziente"];
				ar.Data = (DateTime) reader["data"];
				ar.Descrizione = reader["descrizione"].ToString();
				ar.Tipo = (int)(long)reader["tipo"];
			});

			return ar;
		}

		public static AnamnesiProssima GetProssima(int idConsulto)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("anamnesi_prossima");
			sb.Append(" WHERE ");
			sb.Append("ID_consulto=" + idConsulto);

			AnamnesiProssima ar = null;
			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				ar = new AnamnesiProssima();
				ar.IdConsulto = idConsulto;
				ar.IdPaziente = (int)(long)reader["ID_paziente"];
				ar.PrimaVolta = reader["prima_volta"].ToString();
				ar.Tipologia = reader["tipologia"].ToString();
				ar.Localizzazione = reader["localizzazione"].ToString();
				ar.Irradiazione = reader["irradiazione"].ToString();
				ar.PeriodoInsorgenza = reader["periodo_insorgenza"].ToString();
				ar.Durata = reader["durata"].ToString();
				ar.Familiarita = reader["familiarita"].ToString();
				ar.AltreTerapie = reader["altre_terapie"].ToString();
				ar.Varie = reader["varie"].ToString();
			});

			return ar;
		}

		public static DataTable AnamnesiRemoteList(int idPaziente)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("anamnesi_remota.ID,");
			sb.Append("anamnesi_remota.data,");
			sb.Append("substr(anamnesi_remota.descrizione,1,100) as descrizione,");
			sb.Append("lkp_anamnesi.descrizione as tipo_anamnesi");
			sb.Append(" FROM ");
			sb.Append("anamnesi_remota");
			sb.Append(" INNER JOIN ");
			sb.Append("lkp_anamnesi");
			sb.Append(" ON ");
			sb.Append("anamnesi_remota.tipo = lkp_anamnesi.ID");
			sb.Append(" WHERE ");
			sb.Append("anamnesi_remota.id_paziente = " + idPaziente);
			sb.Append(" ORDER BY ");
			sb.Append("anamnesi_remota.data ASC");

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}
	}
}