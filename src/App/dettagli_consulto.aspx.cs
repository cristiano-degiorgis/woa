using System;
using System.Collections;
using System.Web.UI;
using Steve.UserControl;

namespace Steve.App
{
	/// <summary>
	///   Summary description for dettagli_consulto.
	/// </summary>
	public partial class dettagli_consulto : Page
	{
		protected UserControl.AnamnesiProssima AnamnesiProssima1;
		protected UserControl.Consulto Consulto1;

		protected void Page_Load(object sender, EventArgs e)
		{
			Consulto1.Chiave = Request.QueryString["id_consulto"];
			AnamnesiProssima1.Chiave = Request.QueryString["id_consulto"];
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