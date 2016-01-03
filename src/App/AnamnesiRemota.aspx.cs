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
	public class AnamnesiRemota : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.Panel pnMenuContestuale;

		// Per recuperare il valore dallo UC
		protected UserControl.AnamnesiRemota UcAnamnesiRemota;
		delegate void Del_GestioneMenuContestuale(ArrayList arl);

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack){
				UcAnamnesiRemota.Azione = (eAzioni)Enum.Parse( typeof(eAzioni), Request.QueryString["azione"] );
				UcAnamnesiRemota.PopolaOggettiForm();
			}

			// Gestione Delegate -----------------------------------------------------------
			Del_GestioneMenuContestuale del_GestioneMenuContestuale = new Del_GestioneMenuContestuale(this.GestioneMenuContestuale);
			this.UcAnamnesiRemota.GestioneMenuContestuale = del_GestioneMenuContestuale;
		}

		public void GestioneMenuContestuale( ArrayList arl ){
			HyperLink hl;
			Hashtable ht;

			foreach( Object obj in arl ){
				hl = new HyperLink();
				ht = (Hashtable) obj;
				hl.NavigateUrl = ht["Url"].ToString();
				hl.Text = ht["Text"].ToString();

				pnMenuContestuale.Controls.Add(hl);
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
