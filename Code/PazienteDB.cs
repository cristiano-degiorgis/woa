using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve
{
	public class PazienteDB{
		public static bool IsNuovo( string nome, string cognome ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("count(*)");
			sb.Append(" FROM ");
			sb.Append("paziente");
			sb.Append(" WHERE ");
			//sb.Append(" LCase(cognome) ='"+ cognome.ToLower() +"'");
			sb.Append("cognome LIKE '%"+ cognome +"%'");

			if(nome.Length>0){
				sb.Append(" AND ");
				sb.Append(" LCase(nome) ='"+ nome.ToLower() +"'");
			}
	
			Object res = OleDbHelper.ExecuteScalar( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			return (Convert.ToInt32(res) == 0)? true : false;
		}


		public static DataTable PazientiList(){
			return PazienteDB.PazientiList("", "");
		}

		public static Steve.Paziente GetPaziente( int id ){
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("paziente");	
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			OleDbDataReader reader = OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			Paziente paziente = new Paziente();

			if(reader.Read()){
				paziente.ID = id;
				paziente.Nome = reader["nome"].ToString();
				paziente.Cognome = reader["cognome"].ToString();
				paziente.DataNascita = (DateTime)reader["data_nascita"];
				paziente.Professione = reader["professione"].ToString();
				paziente.Indirizzo = reader["indirizzo"].ToString();
				paziente.Citta = reader["citta"].ToString();
				paziente.Cap = reader["cap"].ToString().Trim();
				paziente.Provincia = reader["prov"].ToString();
				paziente.Telefono = reader["telefono"].ToString();
				paziente.Cellulare = reader["cellulare"].ToString();
				paziente.Email = reader["email"].ToString();
			}

			return paziente;
		}


		public static DataTable PazientiList(string nome, string cognome){

			bool bNome=false,bCognome=false;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("paziente");

			if(nome.Length>0)
				bNome = true;

			if(cognome.Length>0)
				bCognome = true;

			if( bNome || bCognome )
				sb.Append(" WHERE ");

			if(bNome)
				sb.Append("LCase(nome) = '"+ nome.Replace("'","''").ToLower() +"'");

			if( bNome && bCognome )
				sb.Append(" AND ");

			if(bCognome)
				sb.Append("cognome LIKE '%"+ cognome.Replace("'","''") +"%'");
	
			DataSet ds = OleDbHelper.ExecuteDataSet( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			// Setto la chiave primaria sulla tabella del DataSet
			DataColumn[] dcPKs = new DataColumn[1];
			dcPKs[0] = ds.Tables[0].Columns["ID"];
			ds.Tables[0].PrimaryKey = dcPKs;

			return ds.Tables[0];
		}




		public static bool SalvaDati( ref Paziente paziente, ref string sMsg ) {
			bool bResult  =false;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			OleDbParameter[] arParams;

			arParams= new OleDbParameter[12];
			arParams[11] = new OleDbParameter("@ID", OleDbType.Integer );
			

			arParams[0] = new OleDbParameter("@nome", OleDbType.VarWChar );
			arParams[0].Value = paziente.Nome;

			arParams[1] = new OleDbParameter("@cognome", OleDbType.VarWChar );
			arParams[1].Value = paziente.Cognome;

			arParams[2] = new OleDbParameter("@data_nascita", OleDbType.DBTimeStamp );
			arParams[2].Value = paziente.DataNascita;
				
			arParams[3] = new OleDbParameter("@professione", OleDbType.VarWChar );
			arParams[3].Value = paziente.Professione;

			arParams[4] = new OleDbParameter("@indirizzo", OleDbType.VarWChar );
			arParams[4].Value = paziente.Indirizzo;	

			arParams[5] = new OleDbParameter("@citta", OleDbType.VarWChar );
			arParams[5].Value = paziente.Citta;

			arParams[6] = new OleDbParameter("@provincia", OleDbType.WChar, 2 );
			arParams[6].Value = paziente.Provincia;

			arParams[7] = new OleDbParameter("@cap", OleDbType.WChar, 5 );
			arParams[7].Value = paziente.Cap;

			arParams[8] = new OleDbParameter("@telefono", OleDbType.VarWChar );
			arParams[8].Value = paziente.Telefono;

			arParams[9] = new OleDbParameter("@cellulare", OleDbType.VarWChar );
			arParams[9].Value = paziente.Cellulare;

			arParams[10] = new OleDbParameter("@email", OleDbType.VarWChar );
			arParams[10].Value = paziente.Email;
			


			if(paziente.ID == -1){

				int newID = GlobalDB.GetNewID("paziente");
				arParams[11].Value = newID;


				// create and open the connection
				OleDbConnection con =  new OleDbConnection(ConfigurationSettings.AppSettings["strConn"]);
				con.Open(); 

				// create the SqlTransaction object and start a new transaction
				OleDbTransaction tran = con.BeginTransaction();
				try {

					sb.Append("INSERT INTO ");
					sb.Append("paziente");
					sb.Append("( nome, cognome, data_nascita, professione, indirizzo, citta, prov, cap, telefono, cellulare, email, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @nome, @cognome, @data_nascita, @professione, @indirizzo, @citta, @provincia, @cap, @telefono, @cellulare, @email, @ID )");

					OleDbHelper.ExecuteNonQuery( tran, CommandType.Text, sb.ToString(), arParams );

					tran.Commit();

					bResult = true;

					paziente.ID = newID;

				}catch(Exception ex) {
					tran.Rollback();

					bResult = false;

					sMsg = ex.Message;
				}finally {
					con.Close();
				}		
						
			}else{
				
				arParams[11].Value = paziente.ID;

			
				try {
					sb.Append("UPDATE ");
					sb.Append("paziente");
					sb.Append(" SET ");
					sb.Append("nome=@nome,"); 
					sb.Append("cognome=@cognome,");
					sb.Append("data_nascita=@data_nascita,"); 
					sb.Append("professione=@professione,"); 
					sb.Append("indirizzo=@indirizzo,"); 
					sb.Append("citta=@citta,"); 
					sb.Append("prov=@provincia,"); 
					sb.Append("cap=@cap,"); 
					sb.Append("telefono=@telefono,"); 
					sb.Append("cellulare=@cellulare");
					sb.Append("email=@email");

					sb.Append(" WHERE ");
					sb.Append("ID = @ID");

					

					OleDbHelper.ExecuteNonQuery( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), arParams );


					bResult = true;

				}catch(Exception ex) {
					//tran.Rollback();

					bResult = false;

					sMsg = ex.Message;
				}finally {
					//con.Close();
				}
			}

			return bResult;
		}

		public static bool Elimina(int idPaziente, ref string sMsg){
			bool bResult  =false;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			OleDbParameter[] arParams;

			arParams= new OleDbParameter[1];
			arParams[0] = new OleDbParameter("@ID", OleDbType.Integer );
			arParams[0].Value = idPaziente;

			// create and open the connection
			OleDbConnection con =  new OleDbConnection(ConfigurationSettings.AppSettings["strConn"]);
			con.Open(); 

			// create the SqlTransaction object and start a new transaction
			OleDbTransaction tran = con.BeginTransaction();
			try {
				sb.Append("DELETE FROM ");
				sb.Append("paziente");
				sb.Append(" WHERE ");
				sb.Append("( ID = @ID )");

				OleDbHelper.ExecuteNonQuery( tran, CommandType.Text, sb.ToString(), arParams );

				tran.Commit();

				bResult = true;

			}catch(Exception ex) {
				tran.Rollback();

				bResult = false;

				sMsg = ex.Message;
			}finally {
				con.Close();
			}

			return bResult;
		}
	}

}
