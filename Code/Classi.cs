using System;

namespace Steve
{
	/// <summary>
	/// Summary description for Classi.
	/// </summary>
	public class Paziente
	{
		#region Chiave
		public int ID;
		#endregion

		public string Nome;
		public string Cognome;
		public DateTime DataNascita;
		public string Professione;
		public string Indirizzo;
		public string Citta;
		public string Provincia;
		public string Cap;
		public string Telefono;
		public string Cellulare;
		public string Email;


		public Paziente()
		{
			this.ID = -1;
			this.DataNascita = DateTime.MinValue;
		}
	}

	public class Consulto {
		#region Chiave
		public int ID;
		#endregion

		public int IdPaziente;
		public DateTime Data;
		public string ProblemaIniziale;

		public Consulto() {
			this.ID = -1;
			this.IdPaziente = -1;
			this.Data = DateTime.MinValue;
		}
	}


	public class AnamnesiRemota {
		public int ID;
		public int IdPaziente;
		public DateTime Data;
		public int Tipo;
		public string Descrizione;

		public AnamnesiRemota() {
			this.ID = -1;
			this.IdPaziente = -1;
			this.Data = DateTime.MinValue;
		}
	}


	public class AnamnesiProssima : BaseConsultoChild {
	
		public string PrimaVolta;
		public string Tipologia;
		public string Localizzazione;
		public string Irradiazione;
		public string PeriodoInsorgenza;
		public string Durata;
		public string Familiarita;
		public string Varie;
		public string AltreTerapie;

		public AnamnesiProssima() : base() {
			//
			// TODO: Add constructor logic here
			//
		}
	}


	public class Esame : BaseConsultoChild {

		public Esame() : base() {
			//
			// TODO: Add constructor logic here
			//
		}
	}


	public class Trattamento : BaseConsultoChild {

		public Trattamento() : base() {
			//
			// TODO: Add constructor logic here
			//
		}
	}


	public class Valutazione : BaseConsultoChild {

		public string Strutturale;
		public string CranioSacrale;
		public string AkOrtodontica;

		public Valutazione() : base() {
			//
			// TODO: Add constructor logic here
			//
		}
	}





	public class BaseConsultoChild {
		#region Chiave
		public int ID;
		#endregion

		public int IdConsulto;
		public int IdPaziente;
		public DateTime Data;
		public int Tipo;
		public string Descrizione;
		

		public BaseConsultoChild() {
			this.IdConsulto = -1;
			this.IdPaziente = -1;
			this.ID  = -1;
			this.Data = DateTime.MinValue;
		}
	}
}
