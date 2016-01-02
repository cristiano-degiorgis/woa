using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace OleDbDAL {

	/// <summary>
	/// A helper class used to execute queries against an OleDb database
	/// </summary>
	public abstract class OleDbHelper {

		// Read the connection strings from the configuration file
//		public static readonly string CONN_STRING_NON_DTC = ConnectionInfo.DecryptDBConnectionString(ConfigurationSettings.AppSettings["OraConnString1"]);
//		public static readonly string CONN_STRING_DTC_INV = ConnectionInfo.DecryptDBConnectionString(ConfigurationSettings.AppSettings["OraConnString2"]);
//		public static readonly string CONN_STRING_DTC_ORDERS = ConnectionInfo.DecryptDBConnectionString(ConfigurationSettings.AppSettings["OraConnString3"]);

		//Create a hashtable for the parameter cached
		private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// Execute a database query which does not include a select
		/// </summary>
		/// <param name="connString">Connection string to database</param>
		/// <param name="cmdType">Command type either stored procedure or SQL</param>
		/// <param name="cmdText">Acutall SQL Command</param>
		/// <param name="cmdParms">Parameters to bind to the command</param>
		/// <returns></returns>
		public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {
			
			// Create a new OleDb command
			OleDbCommand cmd = new OleDbCommand();

			//Create a connection
			using (OleDbConnection conn = new OleDbConnection(connString)) {
				
				//Prepare the command
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				
				//Execute the command
				int val = cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();
				return val;
			}
		}

		/// <summary>
		/// Execute an OleDbCommand (that returns no resultset) against an existing database transaction 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter(":prodid", 24));
		/// </remarks>
		/// <param name="trans">an existing database transaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {
			OleDbCommand cmd = new OleDbCommand();
			PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
			int val = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return val;
		}

		/// <summary>
		/// Execute an OleDbCommand (that returns no resultset) against an existing database connection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter(":prodid", 24));
		/// </remarks>
		/// <param name="conn">an existing database connection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {

			OleDbCommand cmd = new OleDbCommand();

			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
			int val = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return val;
		}

		/// <summary>
		/// Execute a select query that will return a result set
		/// </summary>
		/// <param name="connString">Connection string</param>
		//// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns></returns>
		public static OleDbDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {
			
			//Create the command and connection
			OleDbCommand cmd = new OleDbCommand();
			OleDbConnection conn = new OleDbConnection(connString);

			try {
				//Prepare the command to execute
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				
				//Execute the query, stating that the connection should close when the resulting datareader has been read
				OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return rdr;
			
			}catch (Exception e) {

				//If an error occurs close the connection as the reader will not be used and we expect it to close the connection
				conn.Close();
				throw e;
			}
		}
		
		/// <summary>
		/// Execute an OleDbCommand that returns the first column of the first record against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter(":prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a SqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
		public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {
			OleDbCommand cmd = new OleDbCommand();

			using (OleDbConnection conn = new OleDbConnection(connString)) {
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				object val = cmd.ExecuteScalar();
				cmd.Parameters.Clear();
				return val;
			}
		}

		/// <summary>
		/// Execute an OleDbCommand that returns the first column of the first record against an existing database connection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  Object obj = ExecuteScalar(conn, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter(":prodid", 24));
		/// </remarks>
		/// <param name="conn">an existing database connection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
		public static object ExecuteScalar(OleDbConnection conn, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) {
			
			OleDbCommand cmd = new OleDbCommand();

			PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
			object val = cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			return val;
		}

		/// <summary>
		/// Add a set of parameters to the cached
		/// </summary>
		/// <param name="cacheKey">Key value to look up the parameters</param>
		/// <param name="cmdParms">Actual parameters to cached</param>
		public static void CacheParameters(string cacheKey, params OleDbParameter[] cmdParms) {
			parmCache[cacheKey] = cmdParms;
		}

		/// <summary>
		/// Fetch parameters from the cache
		/// </summary>
		/// <param name="cacheKey">Key to look up the parameters</param>
		/// <returns></returns>
		public static OleDbParameter[] GetCachedParameters(string cacheKey) {
			OleDbParameter[] cachedParms = (OleDbParameter[])parmCache[cacheKey];
			
			if (cachedParms == null)
				return null;
			
			// If the parameters are in the cache
			OleDbParameter[] clonedParms = new OleDbParameter[cachedParms.Length];

			// return a copy of the parameters
			for (int i = 0, j = cachedParms.Length; i < j; i++)
				clonedParms[i] = (OleDbParameter)((ICloneable)cachedParms[i]).Clone();

			return clonedParms;
		}

		/// <summary>
		/// Internal function to prepare a command for execution by the database
		/// </summary>
		/// <param name="cmd">Existing command object</param>
		/// <param name="conn">Database connection object</param>
		/// <param name="trans">Optional transaction object</param>
		/// <param name="cmdType">Command type, e.g. stored procedure</param>
		/// <param name="cmdText">Command test</param>
		/// <param name="cmdParms">Parameters for the command</param>
		private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms) {
			
			//Open the connection if required
			if (conn.State != ConnectionState.Open)
				conn.Open();

			//Set up the command
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			cmd.CommandType = cmdType;

			//Bind it to the transaction if it exists
			if (trans != null)
				cmd.Transaction = trans;

			// Bind the parameters passed in
			if (cmdParms != null) {
				foreach (OleDbParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}




		/// <summary>
		/// Execute a select query that will return a result set
		/// </summary>
		/// <param name="connString">Connection string</param>
		//// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or PL/SQL command</param>
		/// <param name="commandParameters">an array of OleDbParamters used to execute the command</param>
		/// <returns></returns>
		public static DataSet ExecuteDataSet(string connString, CommandType cmdType, string cmdText, params OleDbParameter[] cmdParms) 
		{
			
			//Create the command and connection
			OleDbCommand cmd = new OleDbCommand();
			OleDbConnection conn = new OleDbConnection(connString);

			try 
			{
				//Prepare the command to execute
				PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
				
				//Execute the query, stating that the connection should close when the resulting datareader has been read
//				OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
//				cmd.Parameters.Clear();
//				return rdr;

				using( OleDbDataAdapter da = new OleDbDataAdapter(cmd) )
				{
					DataSet ds = new DataSet();

					// Fill the DataSet using default values for DataTable names, etc
					da.Fill(ds);
				
					// Detach the SqlParameters from the command object, so they can be used again
					cmd.Parameters.Clear();

					conn.Close();

					// Return the dataset
					return ds;
				}	
			
			}
			catch (Exception e) 
			{

				//If an error occurs close the connection as the reader will not be used and we expect it to close the connection
				conn.Close();
				throw e;
			}
		}
	}
}
