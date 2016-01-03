using System;
using System.Data;

namespace It.Webprofessor
{
	public class WebControls {
		public static void PreparaVista( ref System.Data.DataView view, string[] param ) {
			if( view.Count>0 ) {
				string lastSortColumn= param[0];
				string lastSortOrder= param[1];
				string lastFilter= param[2];
				view.RowFilter= lastFilter;
				view.Sort= lastSortColumn+ " "+ lastSortOrder;
			}	
		}
	}
}
