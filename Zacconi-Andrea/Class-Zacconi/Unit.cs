using System;
using System.Collections.Generic;
using System.Text;

using ConstantsPlayerType;

namespace ModelUnit
{
    /// <summary>
    /// Unit implementation.
    /// </summary>
	public class Unit : IUnit
    {
        private int hp;
        private readonly int dmg;
        private readonly int range;
        private readonly int timer;
        private readonly int step;
        private bool alive;
        private readonly UnitType unitType;
        private readonly PlayerType player;

        public int WaitingTime => this.timer;

        public int Hp => this.hp;

        public int Step => this.step;

        public int Range => this.range;

        public PlayerType Player => this.player;

        public UnitType UnitType => this.unitType;

        public Unit(UnitType unitType, PlayerType player)
        {
            this.unitType = unitType;
            this.hp = unitType.Health;
            this.dmg = unitType.Damage;
            this.range = unitType.Range;
            this.timer = unitType.Timer;
            this.step = unitType.Step;
            this.player = player;
            this.alive = true;
        }

        /*Non implementata come proprieta' per non renderla ambigua con il nome della funzione sottostante Damage. */
        public int GetDamage()
        {
            return this.dmg;
        }

        public void Damage(int damage)
        {
            this.hp -= damage;
            if (this.hp <= 0)
                this.alive = false;
        }

        public void Attack(IUnit unit)
        {
            unit.Damage(this.dmg);
        }

        public bool IsAlive()
        {
            return this.alive;
        }
    }
}
