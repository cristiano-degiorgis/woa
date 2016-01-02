namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ElencoConsulti.
	/// </summary>
	public class ElencoConsulti : BaseUserControl
	{
		protected System.Web.UI.WebControls.DataGrid dg1;
		protected System.Web.UI.WebControls.HyperLink hlAdd;
		protected System.Web.UI.WebControls.Panel pnConsulti;
		protected System.Web.UI.WebControls.Label lblNoConsulti;

		private const int _COL_DETTAGLI = 2;
		private const int _COL_UPDATE = 3;
		private const int _COL_ADD_AP = 4;
		private const int _COL_PROBLEMA_INIZIALE = 1;

		private DataTable _Dt1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Session[this.ToString()] == null)
				 _Dt1 = ConsultoDB.ConsultiList(Paziente1.ID);
			else
				_Dt1 = (DataTable)Session[this.ToString()];
		}

		private void Page_PreRender(object sender, System.EventArgs e) {

			if(_Dt1.Rows.Count > 0){
				dg1.DataSource = _Dt1;
				dg1.DataBind();
				dg1.Visible = true;
				lblNoConsulti.Visible = false;
			}else{
				lblNoConsulti.Visible = true;
				dg1.Visible = false;
			}

			hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Consulto );

		}



		protected void Item_Command(object sender, DataGridCommandEventArgs e) {
			if(e.CommandName != "Page" && e.CommandName != "Sort") {
				string key = dg1.DataKeys[e.Item.ItemIndex].ToString();				
				DataRow dr = _Dt1.Rows.Find( new object[] { key } );				
				
				Chiave = (int)dr["ID"];

				IdConsulto = (int)dr["ID"];

				string sRedirect = "";

				if(e.CommandName == "dettagli")
					sRedirect = String.Format( "~/App/dettagli_consulto.aspx?id_consulto={0}", dr["ID"] );
				else if(e.CommandName == "modifica")
					sRedirect = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Update, eSteps.Consulto );
				else if(e.CommandName == "add_ap")
					sRedirect = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Insert, eSteps.AnamnesiProssima );


				if(sRedirect.Length>0)
					Response.Redirect(sRedirect);

			}
		}


		protected void Item_Data_Bound(object sender, DataGridItemEventArgs e) {
			string key;
			DataRow dr;
			bool bHideAddAP  = true;

			if( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem ){

				key = dg1.DataKeys[e.Item.ItemIndex].ToString();				
				dr = _Dt1.Rows.Find( new object[] { key } );				
				
				if(dr["ID_consulto"] == DBNull.Value)
					bHideAddAP = false;
				
				if( dr["problema_iniziale"].ToString().Length > 100 )
					e.Item.Cells[_COL_PROBLEMA_INIZIALE].Text = dr["problema_iniziale"].ToString().Substring(0,100) + "...";

				if(bHideAddAP)
					foreach( System.Web.UI.Control ctrl in e.Item.Cells[_COL_ADD_AP].Controls )
						e.Item.Cells[_COL_ADD_AP].Controls.Remove(ctrl);				
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);

		}
		#endregion
	}
}
