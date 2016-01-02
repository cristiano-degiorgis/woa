namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;


	/// <summary>
	///		Summary description for Esame.
	/// </summary>
	public class Esame : BaseUserControl, IBaseUserControl
	{
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox txtDescrizione;
		protected System.Web.UI.WebControls.Button cmdSalva;
		protected System.Web.UI.WebControls.Panel pnEditing;
		protected System.Web.UI.WebControls.Label lblData;
		protected System.Web.UI.WebControls.Label lblDescrizione;
		protected System.Web.UI.WebControls.Panel pnShow;
		protected System.Web.UI.WebControls.HyperLink hlAdd;
		protected System.Web.UI.WebControls.Panel pnIsNull;
		protected System.Web.UI.WebControls.Label lblTipo;
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
			ddlTipo.DataSource = EsameDB.ListTipi();
			ddlTipo.DataTextField = "descrizione";
			ddlTipo.DataValueField = "ID";

			ListItem li = ddlTipo.Items[0];
			ddlTipo.DataBind();
			ddlTipo.Items.Insert(0,li);
		}

		public void CaricaDati(){
			Steve.Esame esame = EsameDB.GetEsame(Convert.ToInt32(Chiave));

			switch(Azione){
				case eAzioni.Insert:
					txtData.Text = DateTime.Today.ToString("d");
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					ddlTipo.Items.FindByValue(esame.Tipo.ToString()).Selected = true;
					txtDescrizione.Text = HttpUtility.HtmlDecode( esame.Descrizione );
					txtData.Text = esame.Data.ToString("d");

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if(esame == null){
						hlAdd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota );
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}else{
						lblData.Text = esame.Data.ToString("d");
						lblDescrizione.Text = esame.Descrizione;
						lblTipo.Text = ddlTipo.Items.FindByValue(esame.Tipo.ToString()).Text;

						hlUpd.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update, eSteps.Esame );

						pnShow.Visible = true;
					}
					break;
			}
		}


		public void Salva_Dati(object sender, System.EventArgs e) {

			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);
			Steve.Esame esame = null;
			if(Azione == eAzioni.Insert){
				esame = new Steve.Esame();
				esame.IdPaziente = Paziente1.ID;
				esame.IdConsulto = IdConsulto;
			}else if(Azione == eAzioni.Update){
				esame = EsameDB.GetEsame( Convert.ToInt32(Chiave) );
			}

			esame.Data = DateTime.Parse( txtData.Text );
			esame.Descrizione = HttpUtility.HtmlEncode(txtDescrizione.Text);
			esame.Tipo = Int32.Parse(ddlTipo.SelectedItem.Value);

			string sMsg = "Operazione avvenuta con successo";

			if( EsameDB.SalvaDati( ref esame, ref sMsg) ){
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

//				if(Azione == eAzioni.Insert){
//					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
//					System.Collections.ArrayList arl = new System.Collections.ArrayList();
//					System.Collections.Hashtable ht = new System.Collections.Hashtable();
//
//					ht["Url"] = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Trattamento );
//					ht["Text"] = "Add Trattamento";
//					arl.Add(ht);
//
//					ht = new System.Collections.Hashtable();
//					ht["Url"] = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione );
//					ht["Text"] = "Add Valutazione";
//					arl.Add(ht);
//
//					Object[] aObj = new Object[1];
//					aObj[0] = arl;
//			
//					_DelMenuContestuale.DynamicInvoke(aObj);
//				}

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
