using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve {
	public class ValutazioneDB {
		


		public static bool SalvaDati( ref Valutazione valutazione, ref string sMsg ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[6];


			arParams[0] = new OleDbParameter("@strutturale", OleDbType.LongVarWChar );
			arParams[0].Value = valutazione.Strutturale;

			arParams[1] = new OleDbParameter("@cranio_sacrale", OleDbType.LongVarWChar );
			arParams[1].Value = valutazione.CranioSacrale;

			arParams[2] = new OleDbParameter("@ak_ortodontica", OleDbType.LongVarWChar );
			arParams[2].Value = valutazione.AkOrtodontica;

			arParams[3] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[3].Value = valutazione.IdPaziente;

			arParams[4] = new OleDbParameter("@id_consulto", OleDbType.Integer );
			arParams[4].Value = valutazione.IdConsulto;

			arParams[5] = new OleDbParameter("@ID", OleDbType.Integer );



			if(valutazione.ID == -1){

				int newID = GlobalDB.GetNewID("valutazione");
				arParams[5].Value = newID;

				try {					
					sb.Append("INSERT INTO ");
					sb.Append("valutazione");
					sb.Append("( strutturale, cranio_sacrale, ak_ortodontica, id_paziente, id_consulto, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @strutturale, @cranio_sacrale, @ak_ortodontica, @id_paziente, @id_consulto, @ID )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;

					valutazione.ID = newID;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}else{

				arParams[5].Value = valutazione.ID;

				try {
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
	

		public static Steve.Valutazione GetValutazione( int id ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("valutazione");	
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			Valutazione valutazione = new Valutazione();

			if(reader.Read()){
				valutazione.ID = id;
				valutazione.Strutturale = reader["strutturale"].ToString();
				valutazione.CranioSacrale = reader["cranio_sacrale"].ToString();
				valutazione.AkOrtodontica = reader["ak_ortodontica"].ToString();
				valutazione.IdPaziente = (int)reader["ID_paziente"];
				valutazione.IdConsulto = (int)reader["ID_consulto"];
			}

			return valutazione;
		}


		public static DataTable ValutazioniList(int idConsulto){

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("ID,");
			sb.Append("Mid(strutturale,1,100) as strutturale,");
			sb.Append("Mid(cranio_sacrale,1,100) as cranio_sacrale,");
			sb.Append("Mid(ak_ortodontica,1,100) as ak_ortodontica");
			sb.Append(" FROM ");
			sb.Append("valutazione");
			sb.Append(" WHERE ");
			sb.Append("id_consulto = " + idConsulto);

			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			return ds.Tables[0];
		}

	}
}
