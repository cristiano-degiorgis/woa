using Steve.SqlLite;

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
	public partial class Consulto : BaseUserControl, IBaseUserControl
	{
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox taDescrizione;


		private System.Delegate _DelMenuContestuale;

		public System.Delegate GestioneMenuContestuale {
			set{ _DelMenuContestuale = value;}
		}



		protected void Page_Load(object sender, System.EventArgs e)
		{	
			CaricaDati();
		}


		public void PopolaOggettiForm(){}


		public void CaricaDati(){

			Steve.Consulto consulto = ConsultoDB.GetConsulto(Convert.ToInt32(Chiave));

			switch(Azione){
				case eAzioni.Insert:
					txtData.Text = DateTime.Today.ToString("d");

					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtData.Text = consulto.Data.ToString("d");
					txtProblema.Text = HttpUtility.HtmlDecode( consulto.ProblemaIniziale );

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if(consulto == null){
						hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Consulto );
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}else{
						lblData.Text = consulto.Data.ToString("d");
						lblProblema.Text = consulto.ProblemaIniziale;

						hlUpd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update, eSteps.Consulto );

						pnShow.Visible = true;
					}
					break;
			}
		}


		public void Salva_Dati(object sender, System.EventArgs e) {

			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);

			Steve.Consulto consulto = null;

			if(Azione == eAzioni.Insert ){
				consulto = new Steve.Consulto();
				consulto.IdPaziente = Paziente1.ID;
			}else if( Azione == eAzioni.Update ){
				consulto = ConsultoDB.GetConsulto(Convert.ToInt32(Chiave));
			}
			
			consulto.Data = DateTime.Parse( txtData.Text );
			consulto.ProblemaIniziale = HttpUtility.HtmlEncode(txtProblema.Text);

			string sMsg = "Operazione avvenuta con successo";
			if( ConsultoDB.SalvaDati( ref consulto, ref sMsg ) ){
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;
				
				if(Azione == eAzioni.Insert){

					IdConsulto = consulto.ID;

					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					ArrayList arl = new ArrayList();
					LinkContestuale lc;
					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave={0}&azione={1}&uc={2}", consulto.ID, eAzioni.Insert, eSteps.AnamnesiProssima, Request.ApplicationPath ), "Add Anamnesi Prossima" );
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

		}
		#endregion
	}
}
