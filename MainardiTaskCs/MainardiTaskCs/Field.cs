using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Basic implementation of <see cref="ILane"/>
    /// </summary>
    public class Field : IField
    {
        private readonly IList<ILane> lanes;
        private readonly int cellsNumber;
        private readonly int laneNumber;

        private const String MESSAGE_OUT_OF_FIELD = "The entered lane is out of the limits";

        /// <summary>
        /// Creates a Field from the given dimensions.
        /// </summary>
        /// <param name="cellsNumber">the number of cells for each lane.</param>
        /// <param name="laneNumber">the number of lanes.</param>
       public Field(int cellsNumber, int laneNumber)
        {
            this.cellsNumber = cellsNumber;
            this.laneNumber = laneNumber;
            this.lanes = Enumerable.Repeat(this.cellsNumber, this.laneNumber)
                .Select(l => new Lane(l))
                .ToList<ILane>();
        }

        /// <inheritdoc cref="IField.CellsNumber"/>
        public int CellsNumber => this.cellsNumber;

        /// <inheritdoc cref="IField.LaneNumber"/>
        public int LaneNumber => this.laneNumber;

        /// <summary>
        /// To subclass this method safely a <see cref="IUnit"/> needs to be added to the specified lane number.
        /// </summary>
        public virtual void AddUnit(int laneIndex, IUnit unit)
        {
            if (laneIndex < 0 || laneIndex >= this.lanes.Count)
            {
                throw new IndexOutOfRangeException(MESSAGE_OUT_OF_FIELD);
            }
            this.lanes[laneIndex].AddUnit(unit);
        }

        /// <inheritdoc cref="IField.GetLanes"/>
        public IList<ILane> GetLanes() => new ReadOnlyCollection<ILane>(this.lanes);

        /// <inheritdoc cref="IField.GetScore(PlayerType)"/>
        public int GetScore(PlayerType player) => this.lanes.AsEnumerable()
            .Select(l => l.GetScore(player))
            .Aggregate((s1, s2) => s1 + s2);

        /// <inheritdoc cref="IField.GetUnits"/>
        public IDictionary<IUnit, Tuple<int, int>> GetUnits() => this.lanes.AsEnumerable()
            .SelectMany(l => l.GetUnits().AsEnumerable()
                .Select(e => Tuple.Create(e.Key, Tuple.Create(e.Value, this.lanes.IndexOf(l)))))
            .ToDictionary(e => e.Item1, e => e.Item2);

        /// <inheritdoc cref="IField.ResetScore"/>
        public void ResetScore()
        {
            foreach (var lane in this.lanes)
            {
                lane.ResetScore();
            }
        }

        /// <inheritdoc cref="IField.Update"/>
        public void Update()
        {
            foreach (var lane in this.lanes)
            {
                lane.Update();
            }
        }
    }
}
