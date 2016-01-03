using System;
using System.Web.UI;
using Steve.UserControl;

namespace Steve.App
{
	/// <summary>
	///   Summary description for dettagli_paziente.
	/// </summary>
	public partial class dettagli_paziente : Page
	{
		protected ElencoAnamnesiRemote ElencoAnamnesiRemote1;
		protected ElencoConsulti ElencoConsulti1;
		protected UserControl.Paziente Paziente1;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Paziente1.Azione = eAzioni.Show;
			}
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