using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using CsvHelper;
using Steve.SqlLite;
using Steve.UserControl;

namespace Steve
{
	/// <summary>
	///   Summary description for index.
	/// </summary>
	public partial class _default : Page
	{
		protected ElencoPazienti ElencoPazienti1;

		protected void Page_Load(object sender, EventArgs e)
		{
			var numPazienti = string.Empty;
			var bCheckConn = GlobalDB.CheckConn(ref numPazienti);
			if (bCheckConn)
			{
				lblCheckConn.Text = "Numero totali pazienti nel DB: " + numPazienti;
				lblCheckConn.CssClass += " label-success";
			}
			else
			{
				lblCheckConn.Text = numPazienti;
				lblCheckConn.CssClass = "label-warning";
			}


			// Sulla Home ripulisco sempre le variabili di sessione 
			// per evitare di avere consulti associati ad altri pazienti precedentemente selezionati
			Session.Remove("Paziente");
			Session.Remove("IdConsulto");
		}

		protected void Show_Pazienti(object sender, EventArgs e)
		{
			ElencoPazienti1.Carica();
			pnScegli.Visible = true;
		}

		protected void Export_Pazienti(object sender, EventArgs e)
		{
			var pazienti = PazienteDB.PazientiList();
			//var pathParts = new List<string>(Server.MapPath("~/").Split(Path.DirectorySeparatorChar));
			//pathParts.RemoveAt(pathParts.Count - 1);
			//pathParts.RemoveAt(pathParts.Count - 1);
			//pathParts.Add("exports");
			//pathParts.Add("export_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".csv");
			var fileName = "export_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".csv";
			byte[] buffer;
			//var filePath = String.Join(Path.DirectorySeparatorChar.ToString(), pathParts.ToArray());
			//using (StreamWriter textWriter = File.CreateText(filePath))
			using (var myMemoryStream = new MemoryStream())
			using (StreamWriter textWriter = new StreamWriter(myMemoryStream, Encoding.ASCII))
			{
				var csv = new CsvWriter(textWriter);
				var columnNames = new[] { "ID", "nome", "cognome", "email", "telefono", "cellulare" };
				foreach (var columnName in columnNames)
				{
					csv.WriteField(columnName);
				}
				csv.NextRecord();

				foreach (DataRow row in pazienti.Rows)
				{
					foreach (var columnName in columnNames)
					{
						var val = row[columnName].ToString().Trim();
						if (columnName == "cellulare")
						{
							val = ConvertToCellNumberOrEmpty(val, row["telefono"].ToString().Trim());
						}
						csv.WriteField(val);
					}
					csv.NextRecord();
				}

				textWriter.Flush();
				buffer = myMemoryStream.ToArray();
			}

			Response.Clear();
			Response.ContentType = "text/csv";
			Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
			Response.BinaryWrite(buffer);
			// myMemoryStream.WriteTo(Response.OutputStream); //works too
			Response.Flush();
			Response.Close();
			Response.End();
		}

		private static Regex CellNumeRegex = new Regex(@"^((00|\+)\d{2}[\. ]??)??3\d{2}[\. ]??\d{6,7}([\,\;]((00|\+)\d{2}[\. ]??)??3\d{2}[\. ]??\d{6,7})*$");
		private static bool IsCellNumber(string input)
		{
			return CellNumeRegex.IsMatch(input);
		}

		private static string ConvertToCellNumberOrEmpty(string cellulare, string telefono)
		{
			var input = IsCellNumber(cellulare) ? 
				cellulare 
				: IsCellNumber(telefono) ? 
					telefono 
					: String.Empty;

			if (string.IsNullOrEmpty(input)) return String.Empty;

			if (!input.StartsWith("+"))
			{
				input = "+39" + input;
			}

			return input;
		}



		protected void Cerca_Paziente(object sender, EventArgs e)
		{
			if (PazienteDB.IsNuovo(txtNome.Text, txtCognome.Text))
			{
				pnNuovo.Visible = true;

				HttpContext.Current.Items.Add("NomePaziente", txtNome.Text);
				HttpContext.Current.Items.Add("CognomePaziente", txtCognome.Text);

				Server.Transfer(string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Paziente));
			}
			else
			{
				ElencoPazienti1.Carica(txtNome.Text, txtCognome.Text);
				pnScegli.Visible = true;
			}
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		///   Required method for Designer support - do not modify
		///   the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		#endregion
	}
}