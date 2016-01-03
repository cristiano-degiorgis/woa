using System.Data;

namespace It.Webprofessor
{
	public class WebControls
	{
		public static void PreparaVista(ref DataView view, string[] param)
		{
			if (view.Count > 0)
			{
				var lastSortColumn = param[0];
				var lastSortOrder = param[1];
				var lastFilter = param[2];
				view.RowFilter = lastFilter;
				view.Sort = lastSortColumn + " " + lastSortOrder;
			}
		}
	}
}