using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Lane : ILane
    {
        private readonly int lenght;
        private readonly IDictionary<IUnit, LimitMultiCounter> units;
        private readonly IDictionary<PlayerType, Counter> scores;

        private const String MESSAGE_OUT_OF_LANE = "The entered position is out of the limits";

        /// <summary>
        /// Creates a Lane of the specified lenght.
        /// </summary>
        /// <param name="lenght">the lenght of the lane.</param>
        public Lane(int lenght)
        {
            this.lenght = lenght;
            this.units = new Dictionary<IUnit, LimitMultiCounter>();
            this.scores = new Dictionary<PlayerType, Counter>
            {
                [PlayerType.PLAYER1] = new Counter(),
                [PlayerType.PLAYER2] = new Counter()
            };
        }

        /// <summary>
        /// Increase the score of the given Player.
        /// </summary>
        /// <param name="player">the player whose score to increase</param>
        private void Score(PlayerType player) => this.scores[player].Increment();

        /// <param name="position">a position of this Lane to verify</param>
        /// <returns>true if the position if within the limits</returns>
        private bool IsLegalPosition(int position) => position >= 0 && position < this.lenght;

        /// <summary>
        /// Search the unit target for the given one.
        /// </summary>
        /// <param name="unit">the unit for which to search the target.</param>
        /// <returns>the unit target if there's any</returns>
        /// <Nullable>enabled</Nullable>
        #nullable enable
        private IUnit? SearchTarget(IUnit unit) => Enumerable
            .Range(this.GetUnits()[unit] - (unit.Player.Equals(PlayerType.PLAYER1) ? 0 : unit.Range), unit.Range + 1)
            .Where(IsLegalPosition)
            .SelectMany(p => this[p].AsEnumerable())
            .Where(u => !u.Player.Equals(unit.Player))
            .FirstOrDefault(null);
        #nullable disable

        /// <summary>
        /// Move the given unit of the quantity of its step.
        /// </summary>
        /// <param name="unit">the unit to move.</param>
        private void Move(IUnit unit) => this.units[unit].MultiIncrement(unit.Step);

        /// <inheritdoc cref="ILane.this"/>
        public ISet<IUnit> this[int position]
        {
            get 
            {
                if (!this.IsLegalPosition(position))
                {
                    throw new IndexOutOfRangeException(MESSAGE_OUT_OF_LANE);
                }
                return this.GetUnits().AsEnumerable()
                .Where(e => e.Value == position)
                .Select(e => e.Key).ToHashSet();
            }
            
        }

        /// <inheritdoc cref="ILane.Lenght"/>
        public int Lenght => this.lenght;

        /// <inheritdoc cref="ILane.AddUnit(IUnit)"/>
        public void AddUnit(IUnit unit) => this.units.Add(unit, new LimitMultiCounter(this.lenght - 1));

        /// <inheritdoc cref="ILane.GetScore(PlayerType)"/>
        public int GetScore(PlayerType player) => this.scores[player].Value;

        /// <inheritdoc cref="ILane.GetUnits"/>
        public IDictionary<IUnit, int> GetUnits() => this.units.AsEnumerable()
            .Where(e => e.Key.IsAlive())
            .Select(e => KeyValuePair.Create(e.Key, e.Value.Value))
            .Select(p => p.Key.Player.Equals(PlayerType.PLAYER1) ? p : KeyValuePair.Create(p.Key, this.Lenght - p.Value - 1))
            .ToDictionary(x => x.Key, y => y.Value);

        /// <inheritdoc cref="ILane.ResetScore"/>
        public void ResetScore()
        {
            this.scores[PlayerType.PLAYER1].Reset();
            this.scores[PlayerType.PLAYER2].Reset();
        }

        /// <summary>
        /// To subclass this method safely dead <see cref="IUnit"/>s need to be removed.
        /// </summary>
        public virtual void Update()
        {
            //IEnumerator<KeyValuePair<IUnit, LimitMultiCounter>> unitsIterator = this.units.GetEnumerator();
            //KeyValuePair<IUnit, LimitMultiCounter> unit;
            foreach (var unit in units)
            {
                if (unit.Key.IsAlive())
                {
                    units.Remove(unit);
                    continue;
                }
                #nullable enable
                IUnit? target = this.SearchTarget(unit.Key);
                if (target != null)
                {
                    unit.Key.Attack(target);
                #nullable disable
                } else if (unit.Value.IsOver())
                {
                    this.Score(unit.Key.Player);
                    this.units.Remove(unit);
                } else
                {
                    this.Move(unit.Key);
                }
            }
        }
    }

    public class LimitMultiCounter : Counter
    {
        private readonly int limit;
        public LimitMultiCounter(int limit) : base()
        {
            this.limit = limit;
        }

        internal bool IsOver() => base.Value >= this.limit;

        public override void Increment()
        {
            if (!this.IsOver())
            {
                base.Increment();
            }
        }

        public void MultiIncrement(int value)
        {
            for (int i = 0; i < value; i++)
            {
                this.Increment();
            }
        }

    }

    public class Counter
    {
        private int value;

        public Counter()
        {
            this.value = 0;
        }

        public int Value { get => this.value; }
        public virtual void Increment() => this.value++;
        public void Reset() => this.value = 0;
    }
}
