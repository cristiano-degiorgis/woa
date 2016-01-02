using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using OleDbDAL;

namespace Steve
{
	/// <summary>
	/// Summary description for DbAccess.
	/// </summary>
	
	

	public class GlobalDB{
		public static int GetNewID( string tableName){

			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			sb.Append("SELECT ");
			sb.Append("max(ID)");
			sb.Append(" FROM ");
			sb.Append(tableName);

			Object res = OleDbHelper.ExecuteScalar( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );

			return (res != DBNull.Value)? Convert.ToInt32(res)+1 : 1;
		}


		public static OleDbDataReader ListProvince(){
			string sql = "SELECT sigla, descrizione FROM lkp_provincia ORDER BY descrizione";

			return OleDbHelper.ExecuteReader(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sql, null );
		}

		public static bool CheckConn( ref string numPazienti ){
			bool bRes;

			try{
				
				System.Text.StringBuilder sb = new System.Text.StringBuilder();

				sb.Append("SELECT ");
				sb.Append("count(ID)");
				sb.Append(" FROM ");
				sb.Append("paziente");

				Object res = OleDbHelper.ExecuteScalar( ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null );
				
				numPazienti = res.ToString();

				bRes  = true;
			}catch(Exception exc){
				bRes = false;

				numPazienti = exc.Message;
			}

			return bRes;
		}
	}
}
