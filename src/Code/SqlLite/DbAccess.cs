using System;
using System.Data;
using System.Text;

namespace Steve.SqlLite
{
	/// <summary>
	///   Summary description for DbAccess.
	/// </summary>
	public class GlobalDB
	{
		public static DataTable ListProvince()
		{
			return SqlLiteHelper.GetLookUpDataTable(
				"SELECT sigla, descrizione FROM lkp_provincia ORDER BY descrizione");
		}

		public static bool CheckConn(ref string numPazienti)
		{
			bool bRes;

			try
			{
				var sb = new StringBuilder();
				sb.Append("SELECT ");
				sb.Append("count(ID)");
				sb.Append(" FROM ");
				sb.Append("paziente");

				var res = SqlLiteHelper.ExecuteScalar(sb.ToString());
				numPazienti = res.ToString();

				bRes = true;
			}
			catch (Exception exc)
			{
				bRes = false;
				numPazienti = exc.Message;
			}

			return bRes;
		}
	}
}