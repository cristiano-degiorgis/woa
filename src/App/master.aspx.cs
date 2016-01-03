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

namespace Steve.App
{
	/// <summary>
	/// Summary description for AnamnesiRemota1.
	/// </summary>
	public partial class master : System.Web.UI.Page
	{

		protected UserControl.MenuContestuale MenuContestuale1;	

		protected UserControl.Paziente Paziente1;

		// Per recuperare il valore dallo UC
		IBaseUserControl _ControlToLoad1;
		delegate void Del_GestioneMenuContestuale(ArrayList arl);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			eSteps step = (eSteps)Enum.Parse( typeof(eSteps), Request.QueryString["uc"] );
			_ControlToLoad1 = (IBaseUserControl)LoadControl("~/UserControl/" + step.ToString() + ".ascx" ); 
				

			_ControlToLoad1.Azione = (eAzioni)Enum.Parse( typeof(eAzioni), Request.QueryString["azione"] );
			_ControlToLoad1.Chiave = Request.QueryString["chiave"];
			//_ControlToLoad1.PopolaOggettiForm();
			//_ControlToLoad1.CaricaDati();


			// Gestione Delegate -----------------------------------------------------------
			Del_GestioneMenuContestuale del_GestioneMenuContestuale = new Del_GestioneMenuContestuale(this.GestioneMenuContestuale);
			_ControlToLoad1.GestioneMenuContestuale = del_GestioneMenuContestuale;


			pnLoadControl.Controls.Add((System.Web.UI.Control)_ControlToLoad1);

		}


		public void GestioneMenuContestuale( ArrayList arl ){
			MenuContestuale1.Links = arl;
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
