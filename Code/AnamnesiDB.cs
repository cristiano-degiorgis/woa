using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve
{
	public class AnamnesiDB {
		
		public static OleDbDataReader ListTipiAnamnesiRemota(){
			return OleDbHelper.ExecuteReader( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, "SELECT * FROM lkp_anamnesi", null );
		}


		public static bool SalvaDati( AnamnesiRemota anamnesi, ref string sMsg, eAzioni azione ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[5];


			arParams[0] = new OleDbParameter("@data", OleDbType.DBTimeStamp );
			arParams[0].Value = anamnesi.Data;

			arParams[1] = new OleDbParameter("@descrizione", OleDbType.LongVarWChar );
			arParams[1].Value = anamnesi.Descrizione;

			arParams[2] = new OleDbParameter("@tipo", OleDbType.Integer );
			arParams[2].Value = anamnesi.Tipo;

			arParams[3] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[3].Value = anamnesi.IdPaziente;

			arParams[4] = new OleDbParameter("@id", OleDbType.Integer );

			if(azione == eAzioni.Insert){

				int newID = GlobalDB.GetNewID("anamnesi_remota");
				arParams[4].Value = newID;

				try {					
					sb.Append("INSERT INTO ");
					sb.Append("anamnesi_remota");
					sb.Append("( data, descrizione, tipo, id_paziente, id )");
					sb.Append(" VALUES ");
					sb.Append("(@data, @descrizione, @tipo, @id_paziente, @id )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;
				}catch(Exception ex) {	
					bResult = false;
					sMsg = ex.Message;
				}
			}else{
				arParams[4].Value = anamnesi.ID;
				try {
					sb.Append("UPDATE ");
					sb.Append("anamnesi_remota");
					sb.Append(" SET ");
					sb.Append("data=@data,"); 
					sb.Append("descrizione=@descrizione,"); 
					sb.Append("tipo=@tipo,");
					sb.Append("id_paziente = @id_paziente");
					sb.Append(" WHERE ");
					sb.Append("id = @id");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;
				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}

			return bResult;
		}
	

		public static bool SalvaDati( AnamnesiProssima anamnesi, ref string sMsg, eAzioni azione ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[11];

			arParams[0] = new OleDbParameter("@prima_volta", OleDbType.VarWChar );
			arParams[0].Value = anamnesi.PrimaVolta;

			arParams[1] = new OleDbParameter("@tipologia", OleDbType.VarWChar );
			arParams[1].Value = anamnesi.Tipologia;

			arParams[2] = new OleDbParameter("@localizzazione", OleDbType.VarWChar );
			arParams[2].Value = anamnesi.Localizzazione;

			arParams[3] = new OleDbParameter("@irradiazione", OleDbType.VarWChar );
			arParams[3].Value = anamnesi.Irradiazione;

			arParams[4] = new OleDbParameter("@periodo_insorgenza", OleDbType.VarWChar );
			arParams[4].Value = anamnesi.PeriodoInsorgenza;

			arParams[5] = new OleDbParameter("@durata", OleDbType.VarWChar );
			arParams[5].Value = anamnesi.Durata;

			arParams[6] = new OleDbParameter("@familiarita", OleDbType.VarWChar );
			arParams[6].Value = anamnesi.Familiarita;

			arParams[7] = new OleDbParameter("@altre_terapie", OleDbType.VarWChar );
			arParams[7].Value = anamnesi.AltreTerapie;

			arParams[8] = new OleDbParameter("@varie", OleDbType.LongVarWChar );
			arParams[8].Value = anamnesi.Varie;

			arParams[9] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[9].Value = anamnesi.IdPaziente;

			arParams[10] = new OleDbParameter("@id_consulto", OleDbType.Integer );
			arParams[10].Value = anamnesi.IdConsulto;

			if(azione == eAzioni.Insert){
				try {					
					sb.Append("INSERT INTO ");
					sb.Append("anamnesi_prossima");
					sb.Append("( prima_volta, tipologia, localizzazione, irradiazione, periodo_insorgenza, durata, familiarita, altre_terapie, varie, id_paziente, id_consulto )");
					sb.Append(" VALUES ");
					sb.Append("( @prima_volta, @tipologia, @localizzazione, @irradiazione, @periodo_insorgenza, @durata, @familiarita, @altre_terapie, @varie, @id_paziente, @id_consulto )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}
			}else{
				try {
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

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );
					// commit the transaction if there are no errors
					bResult = true;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}

			return bResult;
		}
	

		public static Steve.AnamnesiRemota GetRemota(int id){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("anamnesi_remota");	
			sb.Append(" WHERE ");
			sb.Append("id=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			AnamnesiRemota ar = null;

			if(reader.Read()){
				ar = new AnamnesiRemota();
				ar.ID = id;
				ar.IdPaziente = (int)reader["id_paziente"];
				ar.Data = (DateTime)reader["data"];
				ar.Descrizione = reader["descrizione"].ToString();
				ar.Tipo = (int)reader["tipo"];
			}
			return ar;		
		}


		public static Steve.AnamnesiProssima GetProssima(int idConsulto){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("anamnesi_prossima");	
			sb.Append(" WHERE ");
			sb.Append("ID_consulto=" + idConsulto);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			AnamnesiProssima ar = null;

			if(reader.Read()){
				ar = new AnamnesiProssima();
				ar.IdConsulto = idConsulto;
				ar.IdPaziente = (int)reader["ID_paziente"];
				ar.PrimaVolta = reader["prima_volta"].ToString();
				ar.Tipologia = reader["tipologia"].ToString();
				ar.Localizzazione = reader["localizzazione"].ToString();
				ar.Irradiazione = reader["irradiazione"].ToString();
				ar.PeriodoInsorgenza = reader["periodo_insorgenza"].ToString();
				ar.Durata = reader["durata"].ToString();
				ar.Familiarita = reader["familiarita"].ToString();
				ar.AltreTerapie = reader["altre_terapie"].ToString();
				ar.Varie = reader["varie"].ToString();
			}
			return ar;		
		}

		public static DataTable AnamnesiRemoteList(int idPaziente){

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("anamnesi_remota.ID,");
			sb.Append("anamnesi_remota.data,");
			sb.Append("Mid(anamnesi_remota.descrizione,1,100) as descrizione,");
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

			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			return ds.Tables[0];
		}

	}

}
