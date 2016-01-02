using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve {
	public class EsameDB {
		
		public static OleDbDataReader ListTipi(){
			return OleDbHelper.ExecuteReader( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, "SELECT * FROM lkp_esame", null );
		}


		public static bool SalvaDati( ref Esame esame, ref string sMsg ) {
			bool bResult;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams = new OleDbParameter[6];


			arParams[0] = new OleDbParameter("@data", OleDbType.DBTimeStamp );
			arParams[0].Value = esame.Data;

			arParams[1] = new OleDbParameter("@descrizione", OleDbType.LongVarWChar );
			arParams[1].Value = esame.Descrizione;

			arParams[2] = new OleDbParameter("@tipo", OleDbType.Integer );
			arParams[2].Value = esame.Tipo;

			arParams[3] = new OleDbParameter("@id_paziente", OleDbType.Integer );
			arParams[3].Value = esame.IdPaziente;

			arParams[4] = new OleDbParameter("@id_consulto", OleDbType.Integer );
			arParams[4].Value = esame.IdConsulto;

			arParams[5] = new OleDbParameter("@ID", OleDbType.Integer );



			if(esame.ID == -1){

				int newID = GlobalDB.GetNewID("esame");
				arParams[5].Value = newID;

				try {					
					sb.Append("INSERT INTO ");
					sb.Append("esame");
					sb.Append("( data, descrizione, tipo, id_paziente, id_consulto, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @data, @descrizione, @tipo, @id_paziente, @id_consulto, @ID )");

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );

					bResult = true;

					esame.ID = newID;

				}catch(Exception ex) {
					bResult = false;
					sMsg = ex.Message;
				}	
			}else{

				arParams[5].Value = esame.ID;

				try {
					sb.Append("UPDATE ");
					sb.Append("esame");
					sb.Append(" SET ");					
					sb.Append("data=@data,"); 
					sb.Append("descrizione=@descrizione,"); 
					sb.Append("tipo=@tipo,"); 
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
	

		public static Steve.Esame GetEsame( int id ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("esame");	
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			Esame esame = new Esame();

			if(reader.Read()){
				esame.ID = id;
				esame.Data = (DateTime)reader["data"];
				esame.Descrizione = reader["descrizione"].ToString();
				esame.Tipo = (int)reader["tipo"];
				esame.IdPaziente = (int)reader["ID_paziente"];
				esame.IdConsulto = (int)reader["ID_consulto"];
			}

			return esame;
		}


		public static DataTable EsamiList(int idConsulto){

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("esame.ID,");
			sb.Append("esame.data,");
			sb.Append("Mid(esame.descrizione,1,100) as descrizione,");
			sb.Append("lkp_esame.descrizione as tipo_esame");
			sb.Append(" FROM ");
			sb.Append("esame");
			sb.Append(" INNER JOIN ");
			sb.Append("lkp_esame");
			sb.Append(" ON ");
			sb.Append("esame.tipo = lkp_esame.ID");
			sb.Append(" WHERE ");
			sb.Append("esame.id_consulto = " + idConsulto);
			sb.Append(" ORDER BY ");
			sb.Append("esame.data ASC");

			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			return ds.Tables[0];
		}

	}
}
