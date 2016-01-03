using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Steve
{
	/// <summary>
	/// Summary description for BaseList.
	/// </summary>
	public class BaseList : BaseUserControl
	{
		protected System.Web.UI.WebControls.Label lblNoItem;
		protected System.Web.UI.WebControls.HyperLink hlAdd;
		protected System.Web.UI.WebControls.DataGrid dg1;

		protected DataTable _Dt1;
		protected eSteps step;

		protected override void OnPreRender(System.EventArgs e) {
			if(_Dt1.Rows.Count > 0){
				dg1.DataSource = _Dt1;
				dg1.DataBind();
				dg1.Visible = true;
				lblNoItem.Visible = false;
			}else{
				lblNoItem.Visible = true;
				dg1.Visible = false;
			}

			hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, step );
		}


		protected void Item_Command(object sender, DataGridCommandEventArgs e) {
			if(e.CommandName != "Page" && e.CommandName != "Sort") {
				string key = dg1.DataKeys[e.Item.ItemIndex].ToString();				
				DataRow dr = _Dt1.Rows.Find( new object[] { key } );				
				
				Chiave = (int)dr["ID"];

				string sRedirect = "";
				if(e.CommandName == "mostra")
					sRedirect = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Show, step );

				if(e.CommandName == "modifica")
					sRedirect = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Update, step );


				if(sRedirect.Length>0)
					Response.Redirect(sRedirect);

			}
		}
	}
}
