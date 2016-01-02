namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for ElencoPazienti.
	/// </summary>
	public class ElencoPazienti : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dg1;

		private DataTable _Dt1;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected DataView view;

		private void Page_Load(object sender, System.EventArgs e)
		{
			lblMsg.Visible = false;
			// Put user code to initialize the page here
			if(Session[this.ToString()]!=null){
				_Dt1 = (DataTable)Session[this.ToString()];
				view = _Dt1.DefaultView;
			}
		}

		public void Carica(){
			_Dt1 = PazienteDB.PazientiList();
			Session[this.ToString()] = _Dt1;
			
			view = _Dt1.DefaultView;
			_InitViewParams();

		}


		public void Carica( string nome, string cognome){
			_Dt1 = PazienteDB.PazientiList( nome, cognome);
			Session[this.ToString()] = _Dt1;

			view = _Dt1.DefaultView;
			_InitViewParams();
		}

		protected void Item_Created(object sender, DataGridItemEventArgs e) {
			if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem){
					((Button)e.Item.Cells[7].Controls[0]).Attributes.Add( "onclick", "return confirm('sicuro di voler eliminare?')" );
			}
		}

		protected void Item_Command(object sender, DataGridCommandEventArgs e) {
			if(e.CommandName != "Page" && e.CommandName != "Sort") {
				string key = dg1.DataKeys[e.Item.ItemIndex].ToString();				
				DataRow dr = _Dt1.Rows.Find( new object[] { key } );
				

				string sRedirect = "";

				if(e.CommandName == "modifica")
					sRedirect = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Update, eSteps.Paziente );
				else if(e.CommandName == "dettagli")
					sRedirect = String.Format( "~/App/dettagli_paziente.aspx");
				else if(e.CommandName == "elimina"){
					string msg = "Eliminazione avvenuta con successo";
					bool bRes = PazienteDB.Elimina((int)dr["ID"], ref msg);

					if(bRes)
						dr.Delete();

					lblMsg.Visible = true;
					lblMsg.CssClass = (bRes)? "msgOK" : "msgKO";
					lblMsg.Text = msg;

				}

				if(sRedirect.Length>0){
					Steve.Paziente paziente = PazienteDB.GetPaziente((int)dr["ID"]);
					Session["Paziente"] = paziente;
					
					Response.Redirect(sRedirect);
				}

			}
		}




		private void Page_PreRender(object sender, System.EventArgs e) {
			string[] param = new String[3]{ViewState["LastSortColumn"].ToString(), ViewState["LastSortOrder"].ToString(), ViewState["LastFilter"].ToString()};
			It.Webprofessor.WebControls.PreparaVista( ref view, param );

			dg1.DataBind();
		}



		#region Sort & Pagining

		protected void Dg1_Page(Object sender, DataGridPageChangedEventArgs e) {
			((DataGrid) sender).CurrentPageIndex= e.NewPageIndex;
			((DataGrid) sender).EditItemIndex = -1;
			((DataGrid) sender).SelectedIndex = -1;
			ResetPageIndex(((DataGrid) sender), view);

			((DataGrid) sender).DataBind();
		}


		protected void Dg1_Sort(Object sender, DataGridSortCommandEventArgs e) {
			//settaColonne();

			string newSortColumn= e.SortExpression.ToString();
			//string newSortOrder="ASC";  // default
			string newSortOrder="DESC";  // default
			string lastSortColumn= (string)ViewState["LastSortColumn"];
			string lastSortOrder= (string)ViewState["LastSortOrder"];

			//if (newSortColumn.Equals(lastSortColumn) && lastSortOrder.Equals("ASC"))
			if (newSortColumn.Equals(lastSortColumn) && lastSortOrder.Equals("DESC")) {
				//newSortOrder= "DESC";
				newSortOrder= "ASC";	
			} // else {newSortOrder="ASC";}
			//else {newSortOrder="DESC";}
				

			ViewState["LastSortOrder"]= newSortOrder;
			ViewState["LastSortColumn"]= newSortColumn;

			((DataGrid) sender).EditItemIndex = -1;
			((DataGrid) sender).SelectedIndex = -1;
			((DataGrid) sender).CurrentPageIndex= 0;  // goto first page
			
			((DataGrid) sender).DataBind();
		}


		protected void ResetPageIndex(DataGrid grid, DataView view) {
			// check for invalid page index
			// Page index is zero based
			if ((grid.CurrentPageIndex != 0) && (((grid.CurrentPageIndex)*grid.PageSize)>= view.Count)) {
				// invalid so leave at last page
				if ((view.Count % grid.PageSize)== 0) { // ends on page border
					grid.CurrentPageIndex= (view.Count/grid.PageSize)-1;
				}
				else { // partial page
					grid.CurrentPageIndex= (view.Count/grid.PageSize);
				}
			}
		}


		private void _InitViewParams() {
			// Parametri Standard per la vista
			ViewState["LastSortOrder"] ="ASC";
			ViewState["LastSortColumn"] = "cognome";
			ViewState["LastFilter"] = "";					
		}

		#endregion


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
