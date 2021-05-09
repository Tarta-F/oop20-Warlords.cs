using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum UnitType
    {
        /**SWORDSMEN unit and his statistics. */
        SWORDSMEN,

        /**SPEARMEN unit and his statistics. */
        SPEARMEN,

        /**ARCHER unit and his statistics. */
        ARCHER
    }

    internal class UnitStatus
    {
        internal int WaitingTime { get; set; }
        internal int Hp { get; set; }
        internal int Step { get; set; }
        internal int Range { get; set; }
        internal int Damage { get; set; }
    }

    public class UnitStat
    {
        private static IDictionary<UnitType, UnitStatus> status = new Dictionary<UnitType, UnitStatus>()
        {
            [UnitType.SWORDSMEN] = new UnitStatus()
            {
                WaitingTime = 2000,
                Hp = 14,
                Step = 1,
                Range = 1,
                Damage = 4
            }
                ,
            [UnitType.SPEARMEN] = new UnitStatus()
            {
                WaitingTime = 2000,
                Hp = 23,
                Step = 1,
                Range = 2,
                Damage = 2
            }
                ,
            [UnitType.ARCHER] = new UnitStatus()
            {
                WaitingTime = 3000,
                Hp = 8,
                Step = 1,
                Range = 5,
                Damage = 2
            }
        };

        public static int GetWaitingTime(UnitType type) => status[type].WaitingTime;
        public static int GetHp(UnitType type) => status[type].Hp;
        public static int GetStep(UnitType type) => status[type].Step;
        public static int GetRange(UnitType type) => status[type].Range;
        public static int GetDamage(UnitType type) => status[type].Damage;

    }
}
