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
	/// Summary description for dettagli_consulto.
	/// </summary>
	public class dettagli_consulto : System.Web.UI.Page
	{
		protected UserControl.Consulto Consulto1;
		protected UserControl.AnamnesiProssima AnamnesiProssima1;
		protected UserControl.MenuContestuale MenuContestuale1;	
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			Consulto1.Chiave = Request.QueryString["id_consulto"];
			AnamnesiProssima1.Chiave = Request.QueryString["id_consulto"];
			
			ArrayList arlLinks = new ArrayList();
			//LinkContestuale[] arlLinks = new LinkContestuale[3];
			LinkContestuale lc;
			lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Esame, Request.ApplicationPath  ), "Add Esame" );
			arlLinks.Add(lc);

			lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Trattamento, Request.ApplicationPath  ), "Add Trattamento" );
			arlLinks.Add(lc);

			lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione, Request.ApplicationPath  ), "Add Valutazione" );
			arlLinks.Add(lc);

			MenuContestuale1.Links = arlLinks;
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
