using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// A collection of lanes that tracks players scores.
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// Gets the number of lanes.
        /// </summary>
        int LaneNumber { get; }


        /// <summary>
        /// Gets the lenght of each lane.
        /// </summary>
        int CellsNumber { get; }

        /// <param name="laneIndex">the lane in which insert the unit.</param>
        /// <param name="unit">the unit to be inserted.</param>
        /// <exception cref="IndexOutOfRangeException">if the lanIndex doesn't exist.</exception>
        void AddUnit(int laneIndex, IUnit unit);

        /// <returns>a list of the lanes of the field.</returns>
        IList<ILane> GetLanes();

        /// <param name="player">the player whose score to get.</param>
        /// <returns>the numbers of units that have reached the enemy base.</returns>
        int GetScore(PlayerType player);

        /// <returns>a map of the units with theri corresponding position, rappresented by a <see cref="Tuple"/>.</returns>
        IDictionary<IUnit, Tuple<int, int>> GetUnits();

        /// <summary>Update all the lanes.</summary>
        void Update();

        /// <summary>Resets the score of each player to 0.</summary>
        void ResetScore();

    }
}
