using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using Steve.SqlLite;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for AnamnesiRemota.
	/// </summary>
	public partial class AnamnesiProssima : BaseUserControl, IBaseUserControl
	{
		private Delegate _DelMenuContestuale;
		protected DropDownList ddlTipo;
		protected TextBox taDescrizione;
		protected TextBox txtData;

		public Delegate GestioneMenuContestuale
		{
			set { _DelMenuContestuale = value; }
		}

		public void CaricaDati()
		{
			var ar = AnamnesiDB.GetProssima(Convert.ToInt32(Chiave));

			switch (Azione)
			{
				case eAzioni.Insert:
					cmdSalva.Text = "Inserisci >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Update:
					txtPrimaVolta.Text = HttpUtility.HtmlDecode(ar.PrimaVolta);
					txtTipologia.Text = HttpUtility.HtmlDecode(ar.Tipologia);
					txtLocalizzazione.Text = HttpUtility.HtmlDecode(ar.Localizzazione);
					txtIrradiazione.Text = HttpUtility.HtmlDecode(ar.Irradiazione);
					txtPeriodoInsorgenza.Text = HttpUtility.HtmlDecode(ar.PeriodoInsorgenza);
					txtDurata.Text = HttpUtility.HtmlDecode(ar.Durata);
					txtFamiliarita.Text = HttpUtility.HtmlDecode(ar.Familiarita);
					txtAltreTerapie.Text = HttpUtility.HtmlDecode(ar.AltreTerapie);
					txtVarie.Text = HttpUtility.HtmlDecode(ar.Varie);

					cmdSalva.Text = "Aggiorna >>";
					cmdSalva.CommandArgument = Azione.ToString();

					pnEditing.Visible = true;
					break;

				case eAzioni.Show:
					if (ar == null)
					{
						hlAdd.NavigateUrl = string.Format("{3}/App/master.aspx?chiave={0}&azione={1}&uc={2}", Convert.ToInt32(Chiave),
							eAzioni.Insert, eSteps.AnamnesiProssima, Request.ApplicationPath);
						pnIsNull.Visible = true;
						//Server.Transfer(  );
					}
					else
					{
						lblPrimaVolta.Text = ar.PrimaVolta;
						lblTipologia.Text = ar.Tipologia;
						lblLocalizzazione.Text = ar.Localizzazione;
						lblIrradiazione.Text = ar.Irradiazione;
						lblPeriodoInsorgenza.Text = ar.PeriodoInsorgenza;
						lblDurata.Text = ar.Durata;
						lblFamiliarita.Text = ar.Familiarita;
						lblAltreTerapie.Text = ar.AltreTerapie;
						lblVarie.Text = ar.Varie;

						hlUpd.NavigateUrl = string.Format("~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Chiave, eAzioni.Update,
							eSteps.AnamnesiProssima);

						pnShow.Visible = true;
					}
					break;
			}
		}

		public void Salva_Dati(object sender, EventArgs e)
		{
			//eAzioni azione = (eAzioni)Enum.Parse(typeof(eAzioni),((Button)sender).CommandArgument);
			Steve.AnamnesiProssima AnamnesiProssima1 = null;
			if (Azione == eAzioni.Insert)
			{
				AnamnesiProssima1 = new Steve.AnamnesiProssima();
				AnamnesiProssima1.IdPaziente = Paziente1.ID;
				AnamnesiProssima1.IdConsulto = Convert.ToInt32(Chiave);
			}
			else if (Azione == eAzioni.Update)
			{
				AnamnesiProssima1 = AnamnesiDB.GetProssima(IdConsulto);
			}


			AnamnesiProssima1.PrimaVolta = HttpUtility.HtmlEncode(txtPrimaVolta.Text);
			AnamnesiProssima1.Tipologia = HttpUtility.HtmlEncode(txtTipologia.Text);
			AnamnesiProssima1.Localizzazione = HttpUtility.HtmlEncode(txtLocalizzazione.Text);
			AnamnesiProssima1.Irradiazione = HttpUtility.HtmlEncode(txtIrradiazione.Text);
			AnamnesiProssima1.Durata = HttpUtility.HtmlEncode(txtDurata.Text);
			AnamnesiProssima1.PeriodoInsorgenza = HttpUtility.HtmlEncode(txtPeriodoInsorgenza.Text);
			AnamnesiProssima1.Familiarita = HttpUtility.HtmlEncode(txtFamiliarita.Text);
			AnamnesiProssima1.AltreTerapie = HttpUtility.HtmlEncode(txtAltreTerapie.Text);
			AnamnesiProssima1.Varie = HttpUtility.HtmlEncode(txtVarie.Text);

			var sMsg = "Operazione avvenuta con successo";
			if (AnamnesiDB.SalvaDati(AnamnesiProssima1, ref sMsg, Azione))
			{
				lblMsg.CssClass = "msgOK";

				pnEditing.Visible = false;

				if (Azione == eAzioni.Insert)
				{
					// Richiamo con il Delegato il metodo della pagina padre per gestire il menu contestuale
					var arl = new ArrayList();
					LinkContestuale lc;
					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.AnamnesiRemota,
								Request.ApplicationPath), "Add Anamnesi Remota");
					arl.Add(lc);

					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Esame,
								Request.ApplicationPath), "Add Esame");
					arl.Add(lc);

					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Trattamento,
								Request.ApplicationPath), "Add Trattamento");
					arl.Add(lc);

					lc =
						new LinkContestuale(
							string.Format("{3}/App/master.aspx?chiave=-1&azione={1}&uc={2}", -1, eAzioni.Insert, eSteps.Valutazione,
								Request.ApplicationPath), "Add Valutazione");
					arl.Add(lc);

					var aObj = new object[1];
					aObj[0] = arl;

					_DelMenuContestuale.DynamicInvoke(aObj);
				}
			}
			else
			{
				lblMsg.CssClass = "msgKO";
			}

			lblMsg.Text = sMsg;
			lblMsg.Visible = true;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			CaricaDati();
		}

		public void PopolaOggettiForm()
		{
		}

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