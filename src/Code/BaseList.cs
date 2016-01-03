using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Steve
{
	/// <summary>
	///   Summary description for BaseList.
	/// </summary>
	public class BaseList : BaseUserControl
	{
		protected DataTable _Dt1;
		protected DataGrid dg1;
		protected HyperLink hlAdd;
		protected Label lblNoItem;
		protected eSteps step;

		protected override void OnPreRender(EventArgs e)
		{
			if (_Dt1.Rows.Count > 0)
			{
				dg1.DataSource = _Dt1;
				dg1.DataBind();
				dg1.Visible = true;
				lblNoItem.Visible = false;
			}
			else
			{
				lblNoItem.Visible = true;
				dg1.Visible = false;
			}

			hlAdd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, step);
		}

		protected void Item_Command(object sender, DataGridCommandEventArgs e)
		{
			if (e.CommandName != "Page" && e.CommandName != "Sort")
			{
				var key = dg1.DataKeys[e.Item.ItemIndex].ToString();
				var dr = _Dt1.Rows.Find(new object[] {key});

				Chiave = (int) dr["ID"];

				var sRedirect = "";
				if (e.CommandName == "mostra")
					sRedirect = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Show, step);

				if (e.CommandName == "modifica")
					sRedirect = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Update, step);


				if (sRedirect.Length > 0)
					Response.Redirect(sRedirect);
			}
		}
	}
}