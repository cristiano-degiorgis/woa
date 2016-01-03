using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Steve.SqlLite
{
	public class PazienteDB
	{
		public static bool IsNuovo(string nome, string cognome)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("count(*)");
			sb.Append(" FROM ");
			sb.Append("paziente");
			sb.Append(" WHERE ");
			//sb.Append(" LCase(cognome) ='"+ cognome.ToLower() +"'");
			sb.Append("cognome LIKE '%" + cognome + "%'");

			if (nome.Length > 0)
			{
				sb.Append(" AND ");
				sb.Append(" lower(nome) ='" + nome.ToLower() + "'");
			}

			//Object res = OleDbHelper.ExecuteScalar(ConfigurationSettings.AppSettings["strConn"], CommandType.Text, sb.ToString(), null);

			using (var dbConnection = new SQLiteConnection(ConfigurationSettings.AppSettings["strConn"]))
			{
				dbConnection.Open();
				var sql = sb.ToString();
				using (var command = new SQLiteCommand(sql, dbConnection))
				{
					var res = command.ExecuteScalar(CommandBehavior.CloseConnection);

					return (Convert.ToInt32(res) == 0) ? true : false;
				}
			}
		}

		public static DataTable PazientiList()
		{
			return PazientiList("", "");
		}

		public static Paziente GetPaziente(int id)
		{
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("paziente");
			sb.Append(" WHERE ");
			sb.Append("ID=" + id);

			Paziente paziente = null;
			SqlLiteHelper.FillEntity(sb.ToString(), reader =>
			{
				paziente = new Paziente();
				paziente.ID = id;
				paziente.Nome = reader["nome"].ToString();
				paziente.Cognome = reader["cognome"].ToString();
				paziente.DataNascita = (DateTime) reader["data_nascita"];
				paziente.Professione = reader["professione"].ToString();
				paziente.Indirizzo = reader["indirizzo"].ToString();
				paziente.Citta = reader["citta"].ToString();
				paziente.Cap = reader["cap"].ToString().Trim();
				paziente.Provincia = reader["prov"].ToString();
				paziente.Telefono = reader["telefono"].ToString();
				paziente.Cellulare = reader["cellulare"].ToString();
				paziente.Email = reader["email"].ToString();
			});


			return paziente;
		}

		public static DataTable PazientiList(string nome, string cognome)
		{
			bool bNome = false, bCognome = false;
			var sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("*");
			sb.Append(" FROM ");
			sb.Append("paziente");

			if (nome.Length > 0)
				bNome = true;

			if (cognome.Length > 0)
				bCognome = true;

			if (bNome || bCognome)
				sb.Append(" WHERE ");

			if (bNome)
				sb.Append("lower(nome) = '" + nome.Replace("'", "''").ToLower() + "'");

			if (bNome && bCognome)
				sb.Append(" AND ");

			if (bCognome)
				sb.Append("cognome LIKE '%" + cognome.Replace("'", "''") + "%'");

			var dt = SqlLiteHelper.GetDataTable(sb.ToString());
			return dt;
		}

		public static bool SalvaDati(ref Paziente paziente, ref string sMsg)
		{
			bool bResult;
			try
			{
				var sb = new StringBuilder();

				var arParams = new List<MySqlLiteParameter>
				{
					new MySqlLiteParameter("@nome", DbType.String, paziente.Nome),
					new MySqlLiteParameter("@cognome", DbType.String, paziente.Cognome),
					new MySqlLiteParameter("@data_nascita", DbType.DateTime, paziente.DataNascita),
					new MySqlLiteParameter("@professione", DbType.String, paziente.Professione),
					new MySqlLiteParameter("@indirizzo", DbType.String, paziente.Indirizzo),
					new MySqlLiteParameter("@citta", DbType.String, paziente.Citta),
					new MySqlLiteParameter("@provincia", DbType.String, paziente.Provincia),
					new MySqlLiteParameter("@cap", DbType.String, paziente.Cap),
					new MySqlLiteParameter("@telefono", DbType.String, paziente.Telefono),
					new MySqlLiteParameter("@cellulare", DbType.String, paziente.Cellulare),
					new MySqlLiteParameter("@email", DbType.String, paziente.Email)
				};


				if (paziente.ID == -1)
				{
					sb.Append("INSERT INTO ");
					sb.Append("paziente");
					sb.Append(
						"( nome, cognome, data_nascita, professione, indirizzo, citta, prov, cap, telefono, cellulare, email )");
					sb.Append(" VALUES ");
					sb.Append(
						"( @nome, @cognome, @data_nascita, @professione, @indirizzo, @citta, @provincia, @cap, @telefono, @cellulare, @email )");

					int newID;
					SqlLiteHelper.Insert(sb.ToString(), arParams, out newID);
					paziente.ID = newID;
				}
				else
				{
					arParams.Add(new MySqlLiteParameter("@ID", DbType.Int32, paziente.ID));

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
					sb.Append("cellulare=@cellulare,");
					sb.Append("email=@email");

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

		public static bool Elimina(int idPaziente, ref string sMsg)
		{
			var bResult = false;
			try
			{
				SqlLiteHelper.Delete(idPaziente);
				bResult = true;
			}
			catch (Exception ex)
			{
				bResult = false;
				sMsg = ex.Message;
			}

			return bResult;
		}
	}
}