using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve
{
	public class ConsultoDB {
		public static bool SalvaDati( ref Consulto consulto, ref string sMsg ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[4];
			arParams[0] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[0].Value = consulto.IdPaziente;

			arParams[1] = new OleDbParameter("@data", OleDbType.DBTimeStamp );
			arParams[1].Value = consulto.Data;

			arParams[2] = new OleDbParameter("@problema_iniziale", OleDbType.LongVarWChar );
			arParams[2].Value = consulto.ProblemaIniziale;

			arParams[3] = new OleDbParameter("@ID", OleDbType.Integer );



			if(consulto.ID == -1){

				int newID = GlobalDB.GetNewID("consulto");
				arParams[3].Value = newID;

				try {					
					sb.Append("INSERT INTO ");
					sb.Append("consulto");
					sb.Append("( id_paziente, data, problema_iniziale, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @id_paziente, @data, @problema_iniziale, @ID )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;

					consulto.ID = newID;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}else{
				try {
					arParams[3].Value = consulto.ID;

					sb.Append("UPDATE ");
					sb.Append("consulto");
					sb.Append(" SET ");
					sb.Append("id_paziente=@id_paziente,");
					sb.Append("data=@data,"); 
					sb.Append("problema_iniziale=@problema_iniziale"); 
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
	

		public static Steve.Consulto GetConsulto( int id ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("consulto");	
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			Consulto consulto = new Consulto();

			if(reader.Read()){
				consulto.ID = id;
				consulto.Data = (DateTime)reader["data"];
				consulto.IdPaziente = (int)reader["id_paziente"];
				consulto.ProblemaIniziale = reader["problema_iniziale"].ToString();
			}

			return consulto;
		}


		public static DataTable ConsultiList(int idPaziente){
			
			DataTable dt;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
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

			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			dt = ds.Tables[0];
//
//			dt.Columns.Add("Esami", typeof(System.Int32));
//			dt.Columns.Add("Trattamenti", typeof(System.Int32));
//			dt.Columns.Add("Valutazioni", typeof(System.Int32));

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = dt.Columns["ID"];
			dt.PrimaryKey = dcPKs;

			return dt;
		}
	}

}
