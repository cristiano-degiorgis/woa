namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;


	/// <summary>
	///		Summary description for Esame.
	/// </summary>
	public partial class Valutazione : BaseUserControl, IBaseUserControl
	{
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.Label lblData;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected System.Web.UI.WebControls.Label lblTipo;

		private System.Delegate _DelMenuContestuale;

		public System.Delegate GestioneMenuContestuale {
			set{ _DelMenuContestuale = value;}
		}

		protected void Page_Load(object sender, System.EventArgs e){
//			if(!Page.IsPostBack)
//				PopolaOggettiForm();

			CaricaDati();
		}

		public void PopolaOggettiForm(){}

		public void CaricaDati(){
			Steve.Valutazione valutazione = ValutazioneDB.GetValutazione(Convert.ToInt32(Chiave));

			switch(Azione){
				case eAzioni.Insert:
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtStrutturale.Text = HttpUtility.HtmlDecode( valutazione.Strutturale );
					txtCranioSacrale.Text = HttpUtility.HtmlDecode( valutazione.CranioSacrale );
					txtAkOrtodontica.Text = HttpUtility.HtmlDecode( valutazione.AkOrtodontica );

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if(valutazione == null){
						hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione );
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}else{
						lblStrutturale.Text = valutazione.Strutturale;
						lblCranioSacrale.Text = valutazione.CranioSacrale;
						lblAkOrtodontica.Text = valutazione.AkOrtodontica;

						hlUpd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update, eSteps.Valutazione );

						pnShow.Visible = true;
					}
					break;
			}
		}


		public void Salva_Dati(object sender, System.EventArgs e) {
			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);
			Steve.Valutazione valutazione = null;

			if(Azione == eAzioni.Insert){
				valutazione = new Steve.Valutazione();
				valutazione.IdPaziente = Paziente1.ID;
				valutazione.IdConsulto = IdConsulto;
			}else if(Azione == eAzioni.Update){
				valutazione = ValutazioneDB.GetValutazione( Convert.ToInt32(Chiave) );
			}

			valutazione.Strutturale = HttpUtility.HtmlEncode(txtStrutturale.Text);
			valutazione.CranioSacrale = HttpUtility.HtmlEncode(txtCranioSacrale.Text);
			valutazione.AkOrtodontica = HttpUtility.HtmlEncode(txtAkOrtodontica.Text);

			string sMsg = "Operazione avvenuta con successo";

			if( ValutazioneDB.SalvaDati( ref valutazione, ref sMsg) ){
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

			}else{
				lblMsg.CssClass = "msgKO";
			}

			lblMsg.Text = sMsg;
			lblMsg.Visible  = true;

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
