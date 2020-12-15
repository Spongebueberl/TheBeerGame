using System;
using System.Collections.Generic;


namespace The_Beer_Game
{
	public class CardDeck
	{
		List<string> Cards = new List<string>();
        Random rand = new Random();
		// constructor (might not needed)
		public CardDeck()
		{
			string[] c = {	"Lagerbrand in der Fabrik! Gesamtes Lager vernichtet!",
							"Lagerbrand in dem Einzelhandel! Gesamtes Lager vernichtet!",
							"Lagerbrand in dem Großhandel! Gesamtes Lager vernichtet!",
							"Lagerbrand in dem Regionallager! Gesamtes Lager vernichtet!",
							"Kosteneinsparung! Regionallager zahlt eine Runde keine Lagerkosten ",
							"Kosteneinsparung! Großhandel zahlt eine Runde keine Lagerkosten ",
							"Kosteneinsparung! Einzelhandel zahlt eine Runde keine Lagerkosten ",
							"Kosteneinsparung! Fabrik zahlt eine Runde keine Lagerkosten ",
							"Kosteneinsparung! Alle zahlen eine Runde keine Lagerkosten",
							"Neues Lager errichtet! Regionallager zahlt eine Runde doppelte Lagerkosten ",
							"Neues Lager errichtet! Großhandel zahlt eine Runde doppelte Lagerkosten ",
							"Neues Lager errichtet! Einzelhandel zahlt eine Runde doppelte Lagerkosten ",
							"Neues Lager errichtet! Fabrik zahlt eine Runde doppelte Lagerkosten ",
							"Neues Lager errichtet! Alle zahlen eine Runde doppelte Lagerkosten ",
							"Mitarbeiter fällt Krankheitsbedingt aus! Regionallager darf eine Runde nichts Ausliefern",
							"Mitarbeiter fällt Krankheitsbedingt aus! Großhandel darf eine Runde nichts Ausliefern",
							"Mitarbeiter fällt Krankheitsbedingt aus! Einzelhandel darf eine Runde nichts Ausliefern",
							"Mitarbeiter fällt Krankheitsbedingt aus! Fabrik darf eine Runde nichts Ausliefern ",
							"Mitarbeiter fällt Krankheitsbedingt aus! Alle dürfen eine Runde nichts Ausliefern",
							"Nichterfüllungskosten verdoppeln sich für alle ",
							"Zusätzliche Joker Expresslieferung möglich! ",
							"Regionallager darf max. fünf Einheiten ausliefern ",
							"Großhandel darf max. fünf Einheiten ausliefern ",
							"Einzelhandel darf max. fünf Einheiten ausliefern ",
							"Fabrik darf max. fünf Einheiten ausliefern ",
							"Alle dürfen max. fünf Einheiten Ausliefern"};
            foreach (string i in c)
			{
				Cards.Add(i);
            }
		}

		// method to draw card
		public (int, string) DrawCard()
		{
			if (this.Cards.Count > 0)
			{
				int i = rand.Next(0, this.Cards.Count);
				string str = Cards[i];
				Cards.RemoveAt(i);
				return (i, str);
			}
			else
			{
				return (0, "Keine Actioncards mehr verfügbar.");
			}
		}

		/*
		// method to execute a specific action card
		public void ExecuteCard(Participant fb, Participant rl, Participant gl, Participant eh, int i)
        {
			switch(i)
            {
				case 0:
					fb.set_inventory(0);
				case 1;
					rl.set_inventory(0);
				case 2;
					gl.set_inventory(0);
				case 3;
					eh.set_inventory(0);
				case 4:
					fb.set_invetoryCost(0);
				case 5;
					rl.set_invetoryCost(0);
				case 6;
					gl.set_invetoryCost(0);
				case 7;
					eh.set_invetoryCost(0);
			}
		}
		*/
	}
}