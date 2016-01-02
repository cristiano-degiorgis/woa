using System;

namespace Steve
{
	public interface IBaseUserControl {
		Paziente Paziente1{ get; set; }
		//Consulto Consulto1{ get; set; }
		int IdConsulto{ get; set; }
		object Chiave{ get; set; }
		System.Delegate GestioneMenuContestuale{ set; }
		eAzioni Azione{ get; set; }
		//void PopolaOggettiForm();
		void Salva_Dati(object sender, System.EventArgs e);
		void CaricaDati();
	}
}
