using System;

namespace Steve
{
	/// <summary>
	/// Summary description for OggettiTmp.
	/// </summary>
	public class LinkContestuale
	{
		private string _Url;
		private string _Text;

		public string Url{
			get{ return _Url; }
		}

		public string Text{
			get{ return _Text; }
		}

		public LinkContestuale()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public LinkContestuale( string url, string text ) {
			_Url = url;
			_Text = text;
		}
	}
}
