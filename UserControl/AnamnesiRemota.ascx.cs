namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	/// <summary>
	///		Summary description for AnamnesiRemota.
	/// </summary>
	public class AnamnesiRemota : BaseUserControl, IBaseUserControl
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox taDescrizione;
		protected System.Web.UI.WebControls.Button cmdSalva;
		protected System.Web.UI.WebControls.Panel pnEditing;
		protected System.Web.UI.WebControls.Label lblData;
		protected System.Web.UI.WebControls.Panel pnShow;
		protected System.Web.UI.WebControls.Label lblTipo;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected System.Web.UI.WebControls.HyperLink hlAdd;
		protected System.Web.UI.WebControls.Panel pnIsNull;
		protected System.Web.UI.WebControls.HyperLink hlUpd;


		private System.Delegate _DelMenuContestuale;

		public System.Delegate GestioneMenuContestuale {
			set{ _DelMenuContestuale = value;}
		}



		private void Page_Load(object sender, System.EventArgs e){
			if(!Page.IsPostBack)
				PopolaOggettiForm();

			CaricaDati();
		}

		public void PopolaOggettiForm(){
			ddlTipo.DataSource = AnamnesiDB.ListTipiAnamnesiRemota();
			ddlTipo.DataTextField = "descrizione";
			ddlTipo.DataValueField = "ID";

			ListItem li = ddlTipo.Items[0];
			ddlTipo.DataBind();
			ddlTipo.Items.Insert(0,li);
		}

		public void CaricaDati(){
			Steve.AnamnesiRemota ar = AnamnesiDB.GetRemota(Convert.ToInt32(Chiave));

			switch(Azione){
				case eAzioni.Insert:
					txtData.Text = DateTime.Today.ToString("d");
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					ddlTipo.Items.FindByValue(ar.Tipo.ToString()).Selected = true;
					taDescrizione.Text = HttpUtility.HtmlDecode( ar.Descrizione );
					txtData.Text =ar.Data.ToString("d");

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if(ar == null){
						hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota );
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}else{
						lblData.Text = ar.Data.ToString("d");
						lblDescrizione.Text = ar.Descrizione;
						lblTipo.Text = ddlTipo.Items.FindByValue(ar.Tipo.ToString()).Text;

						hlUpd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update, eSteps.AnamnesiRemota );

						pnShow.Visible = true;
					}
					break;
			}
		}


		public void Salva_Dati(object sender, System.EventArgs e) {

			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);

			Steve.AnamnesiRemota AnamnesiRemota1 = null;

			if( Azione == eAzioni.Insert ){			
				AnamnesiRemota1 = new Steve.AnamnesiRemota();
				AnamnesiRemota1.IdPaziente = Paziente1.ID;
			}else{
				AnamnesiRemota1 = AnamnesiDB.GetRemota(Convert.ToInt32(Chiave));
			}


			
			AnamnesiRemota1.Data = DateTime.Parse( txtData.Text );
			AnamnesiRemota1.Descrizione = HttpUtility.HtmlEncode(taDescrizione.Text);
			AnamnesiRemota1.Tipo = Int32.Parse(ddlTipo.SelectedItem.Value);

			string sMsg = "Operazione avvenuta con successo";

			if( AnamnesiDB.SalvaDati( AnamnesiRemota1, ref sMsg, Azione ) ){
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

				if(Azione == eAzioni.Insert){
					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					ArrayList arl = new ArrayList();LinkContestuale lc;
					lc = new LinkContestuale( String.Format( "{3}/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota, Request.ApplicationPath ), "Add Anamnesi Remota" );
					arl.Add(lc);

					Object[] aObj = new Object[1];
					aObj[0] = arl;
			
					_DelMenuContestuale.DynamicInvoke(aObj);
				}

			}else{
				lblMsg.CssClass = "msgKO";
			}

			lblMsg.Text = sMsg;
			lblMsg.Visible  = true;

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

		}
		#endregion
	}
}
