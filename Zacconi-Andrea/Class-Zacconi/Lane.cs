using System.Collections.Generic;

using ModelUnit;

namespace ModelLane
{
	/// <summary>
	/// Lane implementation.
	/// </summary>
	public class Lane : ILane
	{
		/*
			Dato che la Lane non l'ho creata io(bensi' un'altro mio collega), la utilizzo solo per creare l'oggetto Unit su di essa, percio' la classe Lane e' leggermente modificata.
			La modifica essenziale nella Lane e' che al posto di inserire un LimitMultiCounterImpl(Classe del progetto per la conta dei passi) nella Dictionary, inserisco solo la lenght - un dato creato da me.
		*/
		/*Dato creato da me per il funzionamento. */
		private int numberOfUnits;
		private readonly int lenght;
		private readonly Dictionary<IUnit, int> units;

		public Lane(int lenght)
		{
			this.numberOfUnits = 0;
			this.lenght = lenght;
			this.units = new Dictionary<IUnit, int>();
		}

		public void AddUnit(IUnit unit)
		{
			this.units.Add(unit, /*Clase MultiLimitCounter. */this.lenght - this.numberOfUnits);
			this.numberOfUnits++;
		}

		public IUnit GetUnits()
		{
			foreach (KeyValuePair<IUnit, int> pair in this.units)
					return pair.Key;
			return default;
		}
	}
}