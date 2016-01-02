using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve {
	public class TrattamentoDB {
		
		public static bool SalvaDati( ref Trattamento trattamento, ref string sMsg ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[5];


			arParams[0] = new OleDbParameter("@data", OleDbType.DBTimeStamp );
			arParams[0].Value = trattamento.Data;

			arParams[1] = new OleDbParameter("@descrizione", OleDbType.LongVarWChar );
			arParams[1].Value = trattamento.Descrizione;

			arParams[2] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[2].Value = trattamento.IdPaziente;

			arParams[3] = new OleDbParameter("@id_consulto", OleDbType.Integer );
			arParams[3].Value = trattamento.IdConsulto;

			arParams[4] = new OleDbParameter("@ID", OleDbType.Integer );



			if(trattamento.ID == -1){

				int newID = GlobalDB.GetNewID("trattamento");
				arParams[4].Value = newID;

				try {					
					sb.Append("INSERT INTO ");
					sb.Append("trattamento");
					sb.Append("( data, descrizione,id_paziente, id_consulto, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @data, @descrizione, @id_paziente, @id_consulto, @ID )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;

					trattamento.ID = newID;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}else{
				arParams[4].Value = trattamento.ID;
				try {
					sb.Append("UPDATE ");
					sb.Append("trattamento");
					sb.Append(" SET ");					
					sb.Append("data=@data,"); 
					sb.Append("descrizione=@descrizione,"); 
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
	

		public static Steve.Trattamento GetTrattamento( int id ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("trattamento");	
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			Trattamento trattamento = new Trattamento();

			if(reader.Read()){
				trattamento.ID = id;
				trattamento.Data = (DateTime)reader["data"];
				trattamento.Descrizione = reader["descrizione"].ToString();
				trattamento.IdPaziente = (int)reader["ID_paziente"];
				trattamento.IdConsulto = (int)reader["ID_consulto"];
			}

			return trattamento;
		}


		public static DataTable TrattamentiList(int idConsulto){

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("ID,");
			sb.Append("data,");
			sb.Append("Mid(descrizione,1,100) as descrizione");
			sb.Append(" FROM ");
			sb.Append("trattamento");
			sb.Append(" WHERE ");
			sb.Append("id_consulto = " + idConsulto);
			sb.Append(" ORDER BY ");
			sb.Append("data ASC");

			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			return ds.Tables[0];
		}

	}
}
