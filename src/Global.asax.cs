using System;
using System.ComponentModel;
using System.Web;

namespace Steve
{
	/// <summary>
	///   Summary description for Global.
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		///   Required designer variable.
		/// </summary>
		private IContainer components;

		public Global()
		{
			InitializeComponent();
		}

		protected void Application_Start(object sender, EventArgs e)
		{
		}

		protected void Session_Start(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Session_End(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}

		#region Web Form Designer generated code

		/// <summary>
		///   Required method for Designer support - do not modify
		///   the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		#endregion
	}
}