using System;
using System.Collections;
using System.Web.UI;
using Steve.UserControl;

namespace Steve.App
{
	/// <summary>
	///   Summary description for AnamnesiRemota1.
	/// </summary>
	public partial class master : Page
	{
		// Per recuperare il valore dallo UC
		private IBaseUserControl _ControlToLoad1;
		protected MenuContestuale MenuContestuale1;
		protected UserControl.Paziente Paziente1;

		protected void Page_Load(object sender, EventArgs e)
		{
			var step = (eSteps) Enum.Parse(typeof (eSteps), Request.QueryString["uc"]);
			_ControlToLoad1 = (IBaseUserControl) LoadControl("~/UserControl/" + step + ".ascx");

			Paziente1.Visible = step != eSteps.Paziente;


			_ControlToLoad1.Azione = (eAzioni) Enum.Parse(typeof (eAzioni), Request.QueryString["azione"]);
			_ControlToLoad1.Chiave = Request.QueryString["chiave"];
			//_ControlToLoad1.PopolaOggettiForm();
			//_ControlToLoad1.CaricaDati();


			// Gestione Delegate -----------------------------------------------------------
			Del_GestioneMenuContestuale del_GestioneMenuContestuale = GestioneMenuContestuale;
			_ControlToLoad1.GestioneMenuContestuale = del_GestioneMenuContestuale;


			pnLoadControl.Controls.Add((Control) _ControlToLoad1);
		}

		public void GestioneMenuContestuale(ArrayList arl)
		{
			MenuContestuale1.Links = arl;
		}

		private delegate void Del_GestioneMenuContestuale(ArrayList arl);

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