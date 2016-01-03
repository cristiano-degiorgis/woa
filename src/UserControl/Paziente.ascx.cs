using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Steve.SqlLite;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for AnagraficaPaziente.
	/// </summary>
	public partial class Paziente : BaseUserControl, IBaseUserControl
	{
		private Delegate _DelMenuContestuale;
		protected Button Button1;
		protected HyperLink hlDetails;

		public int IdPaziente
		{
			get { return (ViewState["IdPaziente"] != null) ? (int) ViewState["IdPaziente"] : -1; }
			set { ViewState["IdPaziente"] = value; }
		}

		public Delegate GestioneMenuContestuale
		{
			set { _DelMenuContestuale = value; }
		}

		public void CaricaDati()
		{
			switch (Azione)
			{
				case eAzioni.Insert:
					txtCognome.Text = (HttpContext.Current.Items["CognomePaziente"] != null)
						? HttpContext.Current.Items["CognomePaziente"].ToString()
						: "";
					txtNome.Text = (HttpContext.Current.Items["NomePaziente"] != null)
						? HttpContext.Current.Items["NomePaziente"].ToString()
						: "";

					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtNome.Text = HttpUtility.HtmlDecode(Paziente1.Nome);
					txtCognome.Text = HttpUtility.HtmlDecode(Paziente1.Cognome);
					txtDataNascita.Text = Paziente1.DataNascita.ToString("d");
					txtProfesione.Text = HttpUtility.HtmlDecode(Paziente1.Professione);
					txtIndirizzo.Text = HttpUtility.HtmlDecode(Paziente1.Indirizzo);
					txtCitta.Text = HttpUtility.HtmlDecode(Paziente1.Citta);
					txtCap.Text = Paziente1.Cap;
					ddlProv.Items.FindByValue(Paziente1.Provincia).Selected = true;
					txtTel.Text = HttpUtility.HtmlDecode(Paziente1.Telefono);
					txtCell.Text = HttpUtility.HtmlDecode(Paziente1.Cellulare);
					txtEmail.Text = HttpUtility.HtmlDecode(Paziente1.Email);

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;
			}
		}

		public void Salva_Dati(object sender, EventArgs e)
		{
			var azione = (eAzioni) Enum.Parse(typeof (eAzioni), ((Button) sender).CommandArgument);
			Steve.Paziente paziente1;

			if (azione == eAzioni.Insert)
				paziente1 = new Steve.Paziente();
			else
				paziente1 = Paziente1;

			paziente1.Nome = HttpUtility.HtmlEncode(txtNome.Text);
			paziente1.Cognome = HttpUtility.HtmlEncode(txtCognome.Text);
			try
			{
				paziente1.DataNascita = DateTime.Parse(txtDataNascita.Text);
			}
			catch
			{
			}

			paziente1.Provincia = ddlProv.SelectedItem.Value;
			paziente1.Indirizzo = HttpUtility.HtmlEncode(txtIndirizzo.Text);
			paziente1.Citta = HttpUtility.HtmlEncode(txtCitta.Text);
			paziente1.Cap = txtCap.Text;
			paziente1.Telefono = HttpUtility.HtmlEncode(txtTel.Text);
			paziente1.Cellulare = HttpUtility.HtmlEncode(txtCell.Text);
			paziente1.Professione = HttpUtility.HtmlEncode(txtProfesione.Text);
			paziente1.Email = HttpUtility.HtmlEncode(txtEmail.Text);

			var sMsg = "Operazione avvenuta con successo";
			if (PazienteDB.SalvaDati(ref paziente1, ref sMsg))
			{
				lblMsg.CssClass = "msgOK";

				Paziente1 = paziente1;

				pnEditing.Visible = false;

				if (azione == eAzioni.Insert)
				{
					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					var arl = new ArrayList();
					LinkContestuale lc;
					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Consulto,
								Request.ApplicationPath), "Add Consulto");
					arl.Add(lc);

					var aObj = new object[1];
					aObj[0] = arl;

					_DelMenuContestuale.DynamicInvoke(aObj);
				}

				Paziente1 = paziente1;
			}
			else
			{
				lblMsg.CssClass = "msgKO";
			}

			lblMsg.Text = sMsg;
			lblMsg.Visible = true;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			lblMsg.Visible = false;

			if (!Page.IsPostBack)
				PopolaOggettiForm();

			CaricaDati();
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			if (Azione == eAzioni.Show)
				_ShowDati();
		}

		public void Carica(int idPaziente)
		{
		}

		public void Carica(string nome, string cognome)
		{
			txtCognome.Text = cognome;
			txtNome.Text = nome;
		}

		public void PopolaOggettiForm()
		{
			ddlProv.DataSource = GlobalDB.ListProvince();
			ddlProv.DataTextField = "descrizione";
			ddlProv.DataValueField = "sigla";
			var li = ddlProv.Items[0];
			ddlProv.DataBind();
			ddlProv.Items.Insert(0, li);
		}

		private void _ShowDati()
		{
			if (Paziente1 != null)
			{
				lblNome.Text = Paziente1.Nome;
				lblCognome.Text = Paziente1.Cognome;
				lblDataNascita.Text = Paziente1.DataNascita.ToString("d");
				lblProfessione.Text = Paziente1.Professione;
				lblIndirizzo.Text = Paziente1.Indirizzo;
				lblCitta.Text = Paziente1.Citta;
				lblCap.Text = Paziente1.Cap;
				lblProv.Text = Paziente1.Provincia;
				lblTel.Text = Paziente1.Telefono;
				lblCell.Text = Paziente1.Cellulare;
				lblEmail.Text = Paziente1.Email;

				hlUpd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Paziente1.ID, eAzioni.Update,
					eSteps.Paziente);


				pnShow.Visible = true;
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