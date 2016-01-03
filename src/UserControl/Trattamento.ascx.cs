using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for Esame.
	/// </summary>
	public partial class Trattamento : BaseUserControl, IBaseUserControl
	{
		private Delegate _DelMenuContestuale;
		protected DropDownList ddlTipo;
		protected Label lblTipo;

		public Delegate GestioneMenuContestuale
		{
			set { _DelMenuContestuale = value; }
		}

		public void CaricaDati()
		{
			var trattamento = TrattamentoDB.GetTrattamento(Convert.ToInt32(Chiave));

			switch (Azione)
			{
				case eAzioni.Insert:
					txtData.Text = DateTime.Today.ToString("d");
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtDescrizione.Text = HttpUtility.HtmlDecode(trattamento.Descrizione);
					txtData.Text = trattamento.Data.ToString("d");

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if (trattamento == null)
					{
						hlAdd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert,
							eSteps.Trattamento);
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}
					else
					{
						lblData.Text = trattamento.Data.ToString("d");
						lblDescrizione.Text = trattamento.Descrizione;

						hlUpd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update,
							eSteps.Trattamento);

						pnShow.Visible = true;
					}
					break;
			}
		}

		public void Salva_Dati(object sender, EventArgs e)
		{
			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);
			Steve.Trattamento trattamento = null;

			if (Azione == eAzioni.Insert)
			{
				trattamento = new Steve.Trattamento();
				trattamento.IdPaziente = Paziente1.ID;
				trattamento.IdConsulto = IdConsulto;
			}
			else if (Azione == eAzioni.Update)
			{
				trattamento = TrattamentoDB.GetTrattamento(Convert.ToInt32(Chiave));
			}

			trattamento.Data = DateTime.Parse(txtData.Text);
			trattamento.Descrizione = HttpUtility.HtmlEncode(txtDescrizione.Text);

			var sMsg = "Operazione avvenuta con successo";

			if (TrattamentoDB.SalvaDati(ref trattamento, ref sMsg))
			{
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

//				if(Azione == eAzioni.Insert){
//					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
//					System.Collections.ArrayList arl = new System.Collections.ArrayList();
//					System.Collections.Hashtable ht = new System.Collections.Hashtable();
//					ht["Url"] = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione );
//					ht["Text"] = "Add Valutazione";
//					arl.Add(ht);
//
//					Object[] aObj = new Object[1];
//					aObj[0] = arl;
//			
//					_DelMenuContestuale.DynamicInvoke(aObj);
//				}
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
//			if(!Page.IsPostBack)
//				PopolaOggettiForm();

			CaricaDati();
		}

		public void PopolaOggettiForm()
		{
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