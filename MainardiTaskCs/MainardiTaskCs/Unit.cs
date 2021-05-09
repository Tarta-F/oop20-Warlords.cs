using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Unit : IUnit
    {
        private readonly UnitType type;
        private readonly PlayerType player;

        private readonly int waitingTime;
        private int hp;
        private readonly int step;
        private readonly int range;
        private readonly int damage;

        public Unit(UnitType type, PlayerType player)
        {
            this.type = type;
            this.player = player;
            new UnitStatus
            {

            };
            this.waitingTime = UnitStat.GetWaitingTime(type);
            this.hp = UnitStat.GetHp(type);
            this.step = UnitStat.GetStep(type);
            this.range = UnitStat.GetRange(type);
            this.damage = UnitStat.GetDamage(type);
        }

        public int WaitingTime => this.waitingTime;

        public int Hp => this.hp;

        public int Step => this.step;

        public int Range => this.range;

        public int Damage => this.damage;

        public PlayerType Player => this.player;

        public UnitType UnitType => this.type;

        public void Harm(int damage)
        {
            this.hp -= damage;
        }
    }
}
