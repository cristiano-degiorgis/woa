namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for MenuContestuale.
	/// </summary>
	public partial class MenuContestuale : System.Web.UI.UserControl
	{


		private System.Collections.ArrayList _Links;
		public System.Collections.ArrayList Links{
			set{ _Links = value; }
		}



		protected void Page_Load(object sender, System.EventArgs e)
		{
		}

		protected void Page_PreRender(object sender, System.EventArgs e) {

			if(_Links != null){


				rptLinks.DataSource = _Links;
				rptLinks.DataBind();

				divMenuContestuale.Visible = true;



//				foreach( Object obj in arl ){
//					hl = new HyperLink();
//					ht = (Hashtable) obj;
//					hl.NavigateUrl = ht["Url"].ToString();
//					hl.Text = ht["Text"].ToString();
//
//					pnMenuContestuale.Controls.Add( new LiteralControl("  [") );
//					pnMenuContestuale.Controls.Add(hl);
//					pnMenuContestuale.Controls.Add( new LiteralControl("]  ") );
//				}
			}else{
				divMenuContestuale.Visible = false;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
	}
}
