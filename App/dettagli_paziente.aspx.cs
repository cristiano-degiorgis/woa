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
	/// Summary description for dettagli_paziente.
	/// </summary>
	public class dettagli_paziente : System.Web.UI.Page
	{
		protected UserControl.Paziente Paziente1;
		protected UserControl.ElencoAnamnesiRemote ElencoAnamnesiRemote1;
		protected UserControl.ElencoConsulti ElencoConsulti1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack){
				
				Paziente1.Azione = eAzioni.Show;
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
