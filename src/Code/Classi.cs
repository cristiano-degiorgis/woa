using System;

namespace Steve
{
	/// <summary>
	///   Summary description for Classi.
	/// </summary>
	public class Paziente
	{
		public string Cap;
		public string Cellulare;
		public string Citta;
		public string Cognome;
		public DateTime DataNascita;
		public string Email;

		#region Chiave

		public int ID;

		#endregion

		public string Indirizzo;
		public string Nome;
		public string Professione;
		public string Provincia;
		public string Telefono;

		public Paziente()
		{
			ID = -1;
			DataNascita = DateTime.MinValue;
		}
	}

	public class Consulto
	{
		public DateTime Data;

		#region Chiave

		public int ID;

		#endregion

		public int IdPaziente;
		public string ProblemaIniziale;

		public Consulto()
		{
			ID = -1;
			IdPaziente = -1;
			Data = DateTime.MinValue;
		}
	}


	public class AnamnesiRemota
	{
		public DateTime Data;
		public string Descrizione;
		public int ID;
		public int IdPaziente;
		public int Tipo;

		public AnamnesiRemota()
		{
			ID = -1;
			IdPaziente = -1;
			Data = DateTime.MinValue;
		}
	}


	public class AnamnesiProssima : BaseConsultoChild
	{
		public string AltreTerapie;
		public string Durata;
		public string Familiarita;
		public string Irradiazione;
		public string Localizzazione;
		public string PeriodoInsorgenza;
		public string PrimaVolta;
		public string Tipologia;
		public string Varie;
	}


	public class Esame : BaseConsultoChild
	{
	}


	public class Trattamento : BaseConsultoChild
	{
	}


	public class Valutazione : BaseConsultoChild
	{
		public string AkOrtodontica;
		public string CranioSacrale;
		public string Strutturale;
	}


	public class BaseConsultoChild
	{
		public DateTime Data;
		public string Descrizione;

		#region Chiave

		public int ID;

		#endregion

		public int IdConsulto;
		public int IdPaziente;
		public int Tipo;

		public BaseConsultoChild()
		{
			IdConsulto = -1;
			IdPaziente = -1;
			ID = -1;
			Data = DateTime.MinValue;
		}
	}
}