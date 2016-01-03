using System;
using System.Data;
using Steve.SqlLite;

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for ElencoAnamnesiRemote.
	/// </summary>
	public class ElencoAnamnesiRemote : BaseList
	{
		private void Page_Load(object sender, EventArgs e)
		{
			step = eSteps.AnamnesiRemota;

			if (Session[ToString()] == null)
				_Dt1 = AnamnesiDB.AnamnesiRemoteList(Paziente1.ID);
			else
				_Dt1 = (DataTable) Session[ToString()];
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
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for ElencoEsami.
	/// </summary>
	public class ElencoEsami : BaseList
	{
		//		protected System.Web.UI.WebControls.Label lblNoItem;
		//		protected System.Web.UI.WebControls.DataGrid dg1;
		//
		//		private DataTable _Dt1;

		private void Page_Load(object sender, EventArgs e)
		{
			step = eSteps.Esame;

			if (Session[ToString()] == null)
				_Dt1 = EsameDB.EsamiList(IdConsulto);
			else
				_Dt1 = (DataTable) Session[ToString()];
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
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for ElencoTrattamenti.
	/// </summary>
	public class ElencoTrattamenti : BaseList
	{
		private void Page_Load(object sender, EventArgs e)
		{
			step = eSteps.Trattamento;

			if (Session[ToString()] == null)
				_Dt1 = TrattamentoDB.TrattamentiList(IdConsulto);
			else
				_Dt1 = (DataTable) Session[ToString()];
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
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}

namespace Steve.UserControl
{
	/// <summary>
	///   Summary description for ElencoEsami.
	/// </summary>
	public class ElencoValutazioni : BaseList
	{
		private void Page_Load(object sender, EventArgs e)
		{
			step = eSteps.Valutazione;

			if (Session[ToString()] == null)
				_Dt1 = ValutazioneDB.ValutazioniList(IdConsulto);
			else
				_Dt1 = (DataTable) Session[ToString()];
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
			this.Load += new System.EventHandler(this.Page_Load);
		}

		#endregion
	}
}