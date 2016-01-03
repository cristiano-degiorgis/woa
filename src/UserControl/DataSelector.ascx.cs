namespace Steve.UserControl
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for DataSelector.
	/// </summary>
	public partial class DataSelector : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal ltImgDa;
		protected System.Web.UI.WebControls.Literal ltImgA;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hfDataDa;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hfDataA;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblDataDa;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblDataA;

		private int _NumCampi = 2;
		private string _LblCampo = "";
		private bool _IsModificabile = true;

		private DateTime[] _Date;

		public DateTime[] Date {
			set{ _Date = value; }
		}

		public int NumCampi
		{
			set{ _NumCampi = value; }
		}

		public string LblCampo
		{
			set{ _LblCampo = value; }
		}

		public bool IsModificabile
		{
			get{ return _IsModificabile; }
			set{ _IsModificabile = value; }
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(_NumCampi == 1)
			{
				lblData1.InnerText = "";
			}
			else if(_NumCampi == 2)
			{
				lblData1.InnerText = "Dal ";
				lblData2.InnerText = "al ";
			}
		}

		protected void Page_PreRender(object sender, System.EventArgs e)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			if(_NumCampi == 2)
			{

				
				if(_IsModificabile)
				{
					sb.Append( String.Format("<A href=\"javascript:OpenCalendar('','{0}','{1}',false)\">",lblData1.ClientID,hfData1.ClientID) );
					sb.Append( "<IMG src=\"" + Request.ApplicationPath + "/img/icon-calendar.gif\" align=\"absMiddle\" border=\"0\">" );
					sb.Append( "</A>" );
				}
				ltImg1.Text = sb.ToString();

				sb.Remove(0,sb.Length);

				if(_IsModificabile)
				{
					sb.Append( String.Format("<A href=\"javascript:OpenCalendar('','{0}','{1}',false)\">",lblData2.ClientID,hfData2.ClientID) );
					sb.Append( "<IMG src=\"" + Request.ApplicationPath + "/img/icon-calendar.gif\" align=\"absMiddle\" border=\"0\">" );
					sb.Append( "</A>" );
				}
				ltImg2.Text = sb.ToString();
				
				
				lblData2.Visible = true;
				ltImg2.Visible = true;

				_DataPersistente( hfData1, lblData1 );
				_DataPersistente( hfData2, lblData2 );
			}

			if(_NumCampi == 1)
			{
//				lblData1.InnerText = "";
				if(_IsModificabile)
				{
					sb.Append( String.Format("<A href=\"javascript:OpenCalendar('','{0}','{1}',false)\">",lblData1.ClientID,hfData1.ClientID) );
					sb.Append( "<IMG src=\"" + Request.ApplicationPath + "/img/icon-calendar.gif\" align=\"absMiddle\" border=\"0\">" );
					sb.Append( "</A>" );
				}
				ltImg1.Text = sb.ToString();

				_DataPersistente( hfData1, lblData1 );
			}


		}

		public DateTime DammiData(string idHF)
		{
			DateTime dtReturn;
			try
			{
//				string[] arr = ( (HtmlInputHidden) FindControl(idHF) ).Value.Split('/');
//				dtReturn = new DateTime( Int32.Parse(arr[2]), Int32.Parse(arr[1]), Int32.Parse(arr[0]) );
				dtReturn = DateTime.Parse( ( (HtmlInputHidden) FindControl(idHF) ).Value );
			}
			catch
			{
				dtReturn = DateTime.MinValue;
			}

			return dtReturn;
		}


		private void _DataPersistente( HtmlInputHidden hf, HtmlGenericControl lb )
		{
			DateTime dtTmp;
			try
			{
				string[] arr = hf.Value.Split('/');
				dtTmp = new DateTime( Int32.Parse(arr[2]), Int32.Parse(arr[1]), Int32.Parse(arr[0]) );

				lb.InnerHtml += dtTmp.ToString("d");
			}
			catch
			{
				//lblData1.InnerHtml = "";
			}			
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

		}
		#endregion
	}
}
