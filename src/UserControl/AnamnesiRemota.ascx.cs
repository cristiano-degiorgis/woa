using System;
using System.Collections;
using System.Web;
using Steve.SqlLite;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for AnamnesiRemota.
	/// </summary>
	public partial class AnamnesiRemota : BaseUserControl, IBaseUserControl
	{
		private Delegate _DelMenuContestuale;

		public Delegate GestioneMenuContestuale
		{
			set { _DelMenuContestuale = value; }
		}

		public void CaricaDati()
		{
			var ar = AnamnesiDB.GetRemota(Convert.ToInt32(Chiave));

			switch (Azione)
			{
				case eAzioni.Insert:
					txtData.Text = DateTime.Today.ToString("d");
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					ddlTipo.Items.FindByValue(ar.Tipo.ToString()).Selected = true;
					taDescrizione.Text = HttpUtility.HtmlDecode(ar.Descrizione);
					txtData.Text = ar.Data.ToString("d");

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if (ar == null)
					{
						hlAdd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert,
							eSteps.AnamnesiRemota);
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}
					else
					{
						lblData.Text = ar.Data.ToString("d");
						lblDescrizione.Text = ar.Descrizione;
						lblTipo.Text = ddlTipo.Items.FindByValue(ar.Tipo.ToString()).Text;

						hlUpd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update,
							eSteps.AnamnesiRemota);

						pnShow.Visible = true;
					}
					break;
			}
		}

		public void Salva_Dati(object sender, EventArgs e)
		{
			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);

			Steve.AnamnesiRemota AnamnesiRemota1 = null;

			if (Azione == eAzioni.Insert)
			{
				AnamnesiRemota1 = new Steve.AnamnesiRemota();
				AnamnesiRemota1.IdPaziente = Paziente1.ID;
			}
			else
			{
				AnamnesiRemota1 = AnamnesiDB.GetRemota(Convert.ToInt32(Chiave));
			}


			AnamnesiRemota1.Data = DateTime.Parse(txtData.Text);
			AnamnesiRemota1.Descrizione = HttpUtility.HtmlEncode(taDescrizione.Text);
			AnamnesiRemota1.Tipo = int.Parse(ddlTipo.SelectedItem.Value);

			var sMsg = "Operazione avvenuta con successo";

			if (AnamnesiDB.SalvaDati(AnamnesiRemota1, ref sMsg, Azione))
			{
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

				if (Azione == eAzioni.Insert)
				{
					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					var arl = new ArrayList();
					LinkContestuale lc;
					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota,
								Request.ApplicationPath), "Add Anamnesi Remota");
					arl.Add(lc);

					var aObj = new object[1];
					aObj[0] = arl;

					_DelMenuContestuale.DynamicInvoke(aObj);
				}
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
			if (!Page.IsPostBack)
				PopolaOggettiForm();

			CaricaDati();
		}

		public void PopolaOggettiForm()
		{
			ddlTipo.DataSource = AnamnesiDB.ListTipiAnamnesiRemota();
			ddlTipo.DataTextField = "descrizione";
			ddlTipo.DataValueField = "ID";

			var li = ddlTipo.Items[0];
			ddlTipo.DataBind();
			ddlTipo.Items.Insert(0, li);
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