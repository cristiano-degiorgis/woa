namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	/// <summary>
	///		Summary description for AnamnesiRemota.
	/// </summary>
	public class AnamnesiProssima : BaseUserControl, IBaseUserControl
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox taDescrizione;
		protected System.Web.UI.WebControls.Button cmdSalva;
		protected System.Web.UI.WebControls.Panel pnEditing;
		protected System.Web.UI.WebControls.TextBox txtPrimaVolta;
		protected System.Web.UI.WebControls.TextBox txtTipologia;
		protected System.Web.UI.WebControls.TextBox txtLocalizzazione;
		protected System.Web.UI.WebControls.TextBox txtIrradiazione;
		protected System.Web.UI.WebControls.Label lblPeriodoInsorgenza;
		protected System.Web.UI.WebControls.Label lblDurata;
		protected System.Web.UI.WebControls.Label lblFamiliarita;
		protected System.Web.UI.WebControls.Label lblAltreTerapie;
		protected System.Web.UI.WebControls.Label lblVarie;
		protected System.Web.UI.WebControls.TextBox txtPeriodoInsorgenza;
		protected System.Web.UI.WebControls.TextBox txtDurata;
		protected System.Web.UI.WebControls.TextBox txtFamiliarita;
		protected System.Web.UI.WebControls.TextBox txtAltreTerapie;
		protected System.Web.UI.WebControls.TextBox txtVarie;
		protected System.Web.UI.WebControls.Label lblPrimaVolta;
		protected System.Web.UI.WebControls.Label lblTipologia;
		protected System.Web.UI.WebControls.Label lblLocalizzazione;
		protected System.Web.UI.WebControls.Label lblIrradiazione;
		protected System.Web.UI.WebControls.Panel pnShow;
		protected System.Web.UI.WebControls.HyperLink hlAdd;
		protected System.Web.UI.WebControls.Panel pnIsNull;
		protected System.Web.UI.WebControls.HyperLink hlUpd;


		private System.Delegate _DelMenuContestuale;

		public System.Delegate GestioneMenuContestuale {
			set{ _DelMenuContestuale = value;}
		}



		private void Page_Load(object sender, System.EventArgs e)
		{

			CaricaDati();
		}

		public void PopolaOggettiForm(){}

		public void CaricaDati(){

			Steve.AnamnesiProssima ar = AnamnesiDB.GetProssima(Convert.ToInt32(Chiave));

			switch(Azione){
				case eAzioni.Insert:
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtPrimaVolta.Text =  HttpUtility.HtmlDecode( ar.PrimaVolta );
					txtTipologia.Text = HttpUtility.HtmlDecode( ar.Tipologia );
					txtLocalizzazione.Text  = HttpUtility.HtmlDecode( ar.Localizzazione );
					txtIrradiazione.Text = HttpUtility.HtmlDecode( ar.Irradiazione );
					txtPeriodoInsorgenza.Text = HttpUtility.HtmlDecode( ar.PeriodoInsorgenza );
					txtDurata.Text  = HttpUtility.HtmlDecode( ar.Durata );
					txtFamiliarita.Text = HttpUtility.HtmlDecode( ar.Familiarita );
					txtAltreTerapie.Text = HttpUtility.HtmlDecode( ar.AltreTerapie );
					txtVarie.Text = HttpUtility.HtmlDecode( ar.Varie );

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if(ar == null){
						hlAdd.NavigateUrl = String.Format( "{3}/App/master.aspx?chiave={0}&azione={1}&uc={2}", Convert.ToInt32(Chiave), eAzioni.Insert, eSteps.AnamnesiProssima, Request.ApplicationPath );
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}else{
						lblPrimaVolta.Text = ar.PrimaVolta;
						lblTipologia.Text = ar.Tipologia;
						lblLocalizzazione.Text  =ar.Localizzazione;
						lblIrradiazione.Text = ar.Irradiazione;
						lblPeriodoInsorgenza.Text = ar.PeriodoInsorgenza;
						lblDurata.Text  = ar.Durata;
						lblFamiliarita.Text = ar.Familiarita;
						lblAltreTerapie.Text = ar.AltreTerapie;
						lblVarie.Text = ar.Varie;

						hlUpd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update, eSteps.AnamnesiProssima );

						pnShow.Visible = true;
					}
					break;
			}
		}


		public void Salva_Dati(object sender, System.EventArgs e) {

			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);
			Steve.AnamnesiProssima AnamnesiProssima1 = null;
			if(Azione == eAzioni.Insert){
				AnamnesiProssima1 = new Steve.AnamnesiProssima();
				AnamnesiProssima1.IdPaziente = Paziente1.ID;
				AnamnesiProssima1.IdConsulto = Convert.ToInt32(Chiave);
			}else if( Azione == eAzioni.Update ){
				AnamnesiProssima1 = AnamnesiDB.GetProssima(IdConsulto);
			}


			AnamnesiProssima1.PrimaVolta = HttpUtility.HtmlEncode(txtPrimaVolta.Text);
			AnamnesiProssima1.Tipologia = HttpUtility.HtmlEncode(txtTipologia.Text);            
			AnamnesiProssima1.Localizzazione = HttpUtility.HtmlEncode(txtLocalizzazione.Text);
			AnamnesiProssima1.Irradiazione = HttpUtility.HtmlEncode(txtIrradiazione.Text);
			AnamnesiProssima1.Durata = HttpUtility.HtmlEncode(txtDurata.Text);
			AnamnesiProssima1.PeriodoInsorgenza = HttpUtility.HtmlEncode(txtPeriodoInsorgenza.Text);
			AnamnesiProssima1.Familiarita = HttpUtility.HtmlEncode(txtFamiliarita.Text);
			AnamnesiProssima1.AltreTerapie = HttpUtility.HtmlEncode(txtAltreTerapie.Text);
			AnamnesiProssima1.Varie = HttpUtility.HtmlEncode(txtVarie.Text);

			string sMsg = "Operazione avvenuta con successo";
			if( AnamnesiDB.SalvaDati( AnamnesiProssima1, ref sMsg, Azione ) ){
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

				if(Azione == eAzioni.Insert){
					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					ArrayList arl = new ArrayList();
					LinkContestuale lc;
					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota, Request.ApplicationPath ), "Add Anamnesi Remota" );
					arl.Add(lc);

					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Esame, Request.ApplicationPath ), "Add Esame" );
					arl.Add(lc);

					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Trattamento, Request.ApplicationPath ), "Add Trattamento" );
					arl.Add(lc);

					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione, Request.ApplicationPath ), "Add Valutazione" );
					arl.Add(lc);

					Object[] aObj = new Object[1];
					aObj[0] = arl;
			
					_DelMenuContestuale.DynamicInvoke(aObj);
				}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
