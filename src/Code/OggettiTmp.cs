namespace Steve
{
	/// <summary>
	///   Summary description for OggettiTmp.
	/// </summary>
	public class LinkContestuale
	{
		public LinkContestuale()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public LinkContestuale(string url, string text)
		{
			Url = url;
			Text = text;
		}

		public string Url { get; private set; }
		public string Text { get; private set; }
	}
}