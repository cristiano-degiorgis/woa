using System;
using System.Data;
using System.Web.UI.WebControls;
using It.Webprofessor;
using Steve.SqlLite;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for ElencoPazienti.
	/// </summary>
	public partial class ElencoPazienti : System.Web.UI.UserControl
	{
		private DataTable _Dt1;
		protected DataView view;

		protected void Page_Load(object sender, EventArgs e)
		{
			lblMsg.Visible = false;
			// Put user code to initialize the page here
			if (Session[ToString()] != null)
			{
				_Dt1 = (DataTable) Session[ToString()];
				view = _Dt1.DefaultView;
			}
		}

		public void Carica()
		{
			_Dt1 = PazienteDB.PazientiList();

			Session[ToString()] = _Dt1;

			view = _Dt1.DefaultView;
			_InitViewParams();
		}

		public void Carica(string nome, string cognome)
		{
			_Dt1 = PazienteDB.PazientiList(nome, cognome);
			Session[ToString()] = _Dt1;

			view = _Dt1.DefaultView;
			_InitViewParams();
		}

		protected void Item_Created(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				((Button) e.Item.Cells[7].Controls[0]).Attributes.Add("onclick", "return confirm('sicuro di voler eliminare?')");
			}
		}

		protected void Item_Command(object sender, DataGridCommandEventArgs e)
		{
			if (e.CommandName != "Page" && e.CommandName != "Sort")
			{
				var key = dg1.DataKeys[e.Item.ItemIndex].ToString();
				var dr = _Dt1.Rows.Find(new object[] {key});


				var sRedirect = "";

				if (e.CommandName == "modifica")
					sRedirect = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", dr["ID"], eAzioni.Update,
						eSteps.Paziente);
				else if (e.CommandName == "dettagli")
					sRedirect = "~/App/dettagli_paziente.aspx";
				else if (e.CommandName == "elimina")
				{
					var msg = "Eliminazione avvenuta con successo";
					var bRes = PazienteDB.Elimina((int) dr["ID"], ref msg);

					if (bRes)
						dr.Delete();

					lblMsg.Visible = true;
					lblMsg.CssClass = (bRes) ? "msgOK" : "msgKO";
					lblMsg.Text = msg;
				}

				if (sRedirect.Length > 0)
				{
					var id = (int) dr["ID"];
					var paziente = PazienteDB.GetPaziente(id);
					Session["Paziente"] = paziente;

					Response.Redirect(sRedirect);
				}
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			var param = new string[3]
			{ViewState["LastSortColumn"].ToString(), ViewState["LastSortOrder"].ToString(), ViewState["LastFilter"].ToString()};
			WebControls.PreparaVista(ref view, param);

			dg1.DataBind();
		}

		#region Sort & Pagining

		protected void Dg1_Page(object sender, DataGridPageChangedEventArgs e)
		{
			((DataGrid) sender).CurrentPageIndex = e.NewPageIndex;
			((DataGrid) sender).EditItemIndex = -1;
			((DataGrid) sender).SelectedIndex = -1;
			ResetPageIndex(((DataGrid) sender), view);

			((DataGrid) sender).DataBind();
		}


		protected void Dg1_Sort(object sender, DataGridSortCommandEventArgs e)
		{
			//settaColonne();

			var newSortColumn = e.SortExpression;
			//string newSortOrder="ASC";  // default
			var newSortOrder = "DESC"; // default
			var lastSortColumn = (string) ViewState["LastSortColumn"];
			var lastSortOrder = (string) ViewState["LastSortOrder"];

			//if (newSortColumn.Equals(lastSortColumn) && lastSortOrder.Equals("ASC"))
			if (newSortColumn.Equals(lastSortColumn) && lastSortOrder.Equals("DESC"))
			{
				//newSortOrder= "DESC";
				newSortOrder = "ASC";
			} // else {newSortOrder="ASC";}
			//else {newSortOrder="DESC";}


			ViewState["LastSortOrder"] = newSortOrder;
			ViewState["LastSortColumn"] = newSortColumn;

			((DataGrid) sender).EditItemIndex = -1;
			((DataGrid) sender).SelectedIndex = -1;
			((DataGrid) sender).CurrentPageIndex = 0; // goto first page

			((DataGrid) sender).DataBind();
		}


		protected void ResetPageIndex(DataGrid grid, DataView view)
		{
			// check for invalid page index
			// Page index is zero based
			if ((grid.CurrentPageIndex != 0) && (((grid.CurrentPageIndex)*grid.PageSize) >= view.Count))
			{
				// invalid so leave at last page
				if ((view.Count%grid.PageSize) == 0)
				{
					// ends on page border
					grid.CurrentPageIndex = (view.Count/grid.PageSize) - 1;
				}
				else
				{
					// partial page
					grid.CurrentPageIndex = (view.Count/grid.PageSize);
				}
			}
		}


		private void _InitViewParams()
		{
			// Parametri Standard per la vista
			ViewState["LastSortOrder"] = "ASC";
			ViewState["LastSortColumn"] = "cognome";
			ViewState["LastFilter"] = "";
		}

		#endregion

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		///   Required method for Designer support - do not modify
		///   the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		#endregion
	}
}