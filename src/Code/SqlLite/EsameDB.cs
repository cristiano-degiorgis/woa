using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Steve.SqlLite
{
	public class EsameDB
	{
		public static DataTable ListTipi()
		{
			return SqlLiteHelper.GetLookUpDataTable("lkp_esame");
		}

		public static bool SalvaDati(ref Esame esame, ref string sMsg)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@data", DbType.DateTime, esame.Data),
					new MySqlLiteParameter("@descrizione", DbType.String, esame.Descrizione),
					new MySqlLiteParameter("@tipo", DbType.Int32, esame.Tipo),
					new MySqlLiteParameter("@id_paziente", DbType.Int32, esame.IdPaziente),
					new MySqlLiteParameter("@id_consulto", DbType.Int32, esame.IdConsulto)
				};


				if (esame.ID == -1)
				{
					sb.Append("INSERT INTO ");
					sb.Append("esame");
					sb.Append("( data, descrizione, tipo, id_paziente, id_consulto, ID )");
					sb.Append(" VALUES ");
					sb.Append("( @data, @descrizione, @tipo, @id_paziente, @id_consulto, @ID )");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					esame.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@ID", DbType.Int32, esame.ID));


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

		public static Esame GetEsame(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("esame");
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			Esame esame = null;
			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				esame = new Esame();
				esame.ID = id;
				esame.Data = (DateTime) reader["data"];
				esame.Descrizione = reader["descrizione"].ToString();
				esame.Tipo = (int) (long) reader["tipo"];
				esame.IdPaziente = (int) (long) reader["ID_paziente"];
				esame.IdConsulto = (int) (long) reader["ID_consulto"];
			});

			return esame;
		}

		public static DataTable EsamiList(int idConsulto)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("esame.ID,");
			sb.Append("esame.data,");
			sb.Append("substr(esame.descrizione,1,100) as descrizione,");
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

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}
	}
}