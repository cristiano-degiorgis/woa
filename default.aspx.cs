using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Steve{
	/// <summary>
	/// Summary description for index.
	/// </summary>
	public class _default : System.Web.UI.Page	{

		protected System.Web.UI.WebControls.TextBox txtNome;
		protected System.Web.UI.WebControls.TextBox txtCognome;
		protected System.Web.UI.WebControls.Button cmdCercaPaziente;
		protected System.Web.UI.WebControls.Panel pnCerca;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Panel pnNuovo;
		protected System.Web.UI.WebControls.Button cmdShowPazienti;
		protected System.Web.UI.WebControls.Panel pnScegli;
		protected System.Web.UI.WebControls.Label lblCheckConn;

		protected UserControl.ElencoPazienti ElencoPazienti1;
	
		private void Page_Load(object sender, System.EventArgs e){	
			
			string numPazienti = String.Empty;
			bool bCheckConn = GlobalDB.CheckConn( ref numPazienti );
			if( bCheckConn ){
				lblCheckConn.Text = "Numero totali pazienti nel DB: " + numPazienti;
				lblCheckConn.CssClass = "msgOK";
			}else{
				lblCheckConn.Text = numPazienti;
				lblCheckConn.CssClass = "msgKO";
			}


			// Sulla Home ripulisco sempre le variabili di sessione 
			// per evitare di avere consulti associati ad altri pazienti precedentemente selezionati
			Session.Remove("Paziente");
			Session.Remove("IdConsulto");
		}


		protected void Show_Pazienti(object sender, System.EventArgs e){
			ElencoPazienti1.Carica();
			pnScegli.Visible = true;
		}


		protected void Cerca_Paziente(object sender, System.EventArgs e){
			
			if( PazienteDB.IsNuovo(txtNome.Text, txtCognome.Text) ){
				pnNuovo.Visible = true;

				HttpContext.Current.Items.Add("NomePaziente", txtNome.Text);
				HttpContext.Current.Items.Add("CognomePaziente", txtCognome.Text);

				Server.Transfer( String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Paziente ) );

			}else{
				ElencoPazienti1.Carica( txtNome.Text, txtCognome.Text );
				pnScegli.Visible = true;
			}
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
