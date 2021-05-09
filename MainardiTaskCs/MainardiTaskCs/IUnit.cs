using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IUnit
    {
        int WaitingTime { get; }

        int Hp { get; }

        int Step { get; }

        int Range { get; }

        int Damage { get; }

        PlayerType Player { get; }

        UnitType UnitType { get; }

        /// <summary>
        /// Reduce this unit's hp by the given quantity.
        /// </summary>
        /// <param name="damage">the hp to be reduced</param>
        void Harm(int damage);

        public bool IsAlive() => true;

        public void Attack(IUnit target) => Console.WriteLine();
    }
}
