using System;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for MainMenu.
	/// </summary>
	public partial class MainMenu : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			//hlHome.Attributes.Add("onMouseOver", "mOvItemMainMenu(this);");
			//hlHome.Attributes.Add("onMouseOut", "mOutItemMainMenu(this);");

			if (Paziente1 != null)
			{
				hlPaziente.NavigateUrl = "~/App/dettagli_paziente.aspx";
				//hlPaziente.Attributes.Add("onMouseOver", "mOvItemMainMenu(this);");
				//hlPaziente.Attributes.Add("onMouseOut", "mOutItemMainMenu(this);");
			}
			//hlPaziente.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", Paziente1.ID, eAzioni.Show, eSteps.Paziente );

			if (IdConsulto > 0)
			{
				hlConsulto.NavigateUrl = string.Format("~/App/dettagli_consulto.aspx?id_consulto={0}", IdConsulto);
				//hlConsulto.Attributes.Add("onMouseOver", "mOvItemMainMenu(this);");
				//hlConsulto.Attributes.Add("onMouseOut", "mOutItemMainMenu(this);");
			}
				//hlConsulto.NavigateUrl = String.Format( "~/App/master.aspx?chiave={0}&azione={1}&uc={2}", IdConsulto, eAzioni.Show, eSteps.Consulto );
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