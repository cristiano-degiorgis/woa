using System;
using System.Web;

namespace Steve
{
	public class BaseUserControl : System.Web.UI.UserControl
	{
		private int _IdConsulto;
		private Paziente _Paziente1;
//		private Consulto	_Consulto1;


		public Paziente Paziente1
		{
			//get { return (Paziente)HttpContext.Current.Session["Paziente"];}
			get
			{
				if (_Paziente1 == null && HttpContext.Current.Session["Paziente"] != null)
					_Paziente1 = (Paziente) HttpContext.Current.Session["Paziente"];
				return _Paziente1;
			}
			set
			{
				_Paziente1 = value;
				HttpContext.Current.Session["Paziente"] = value;
			}
		}

		public int IdConsulto
		{
			get
			{
				// Cosi torno sempre l'ultimo consulto
				if (HttpContext.Current.Session["IdConsulto"] != null)
					_IdConsulto = (int) HttpContext.Current.Session["IdConsulto"];
				return _IdConsulto;
			}
			set
			{
				_IdConsulto = value;
				HttpContext.Current.Session["IdConsulto"] = value;
			}
		}

//		public Consulto Consulto1 {
//			get { return _Consulto1;}
//			set {  _Consulto1 = value;; HttpContext.Current.Session["Consulto"] = value;}
//		}

		public eAzioni Azione
		{
			get { return (ViewState["Azione"] != null) ? (eAzioni) ViewState["Azione"] : eAzioni.Indefinita; }
			set { ViewState["Azione"] = value; }
		}

		public object Chiave
		{
			get { return ViewState["Chiave"]; }
			set { ViewState["Chiave"] = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			object oTmp1, oTmp2;

			oTmp1 = HttpContext.Current.Session["Paziente"];
			oTmp2 = HttpContext.Current.Session["IdConsulto"];
			if (oTmp1 != null)
			{
				_Paziente1 = (Paziente) oTmp1;
			}

			if (oTmp2 != null)
			{
				_IdConsulto = (int) oTmp2;
			}
			else
				_IdConsulto = -1;

//			if ( oTmp2 != null) {
//				this._Consulto1 = (Consulto) oTmp2;
//			}

//			else {
//				// Significa che è scaduta la sessione
//				Response.Redirect( "~/logout.aspx" );
//
//				_Utente = null;
//			}
		}

		protected override void OnUnload(EventArgs e)
		{
		}
	}
}