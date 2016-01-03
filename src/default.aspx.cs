using System;
using System.Web;
using SqlLite = Steve.SqlLite;

namespace Steve{
	/// <summary>
	/// Summary description for index.
	/// </summary>
	public partial class _default : System.Web.UI.Page	{


		protected UserControl.ElencoPazienti ElencoPazienti1;
	
		protected void Page_Load(object sender, System.EventArgs e){	
			
			string numPazienti = String.Empty;
			bool bCheckConn = SqlLite.GlobalDB.CheckConn(ref numPazienti);
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
			
			if( SqlLite.PazienteDB.IsNuovo(txtNome.Text, txtCognome.Text) ){
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

		}
		#endregion
	}
}
