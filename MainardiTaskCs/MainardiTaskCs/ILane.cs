using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

    /// <summary>
    /// Route where units walk and fight to reach the opponent player.
    /// </summary>
    public interface ILane
    {
        /// <summary>
        /// Gets the lenght of the lane.
        /// </summary>
        int Lenght { get; }

        /// <param name="player">the player whose score to get</param>
        /// <returns>the numbers of units that have received the enemy base by this lane</returns>
        int GetScore(PlayerType player);

        /// <param name="unit"> the Unit to be added</param>
        void AddUnit(IUnit unit);

        /// <summary>
        /// The indexer used to access units of the lane.
        /// </summary>
        /// <param name="position">the position for which the units are required.</param>
        /// <returns>a set of the units in this position.</returns>
        ISet<IUnit> this[int position] { get; }

        /// <summary>
        /// Get all the units contained in this lane with the corresponding position.
        /// </summary>
        /// <returns>the dictionary that contains the units</returns>
        IDictionary<IUnit, int> GetUnits();

        /// <summary>
        /// Updates every {@link IUnit} in this lane with attack, score or move.
        /// </summary>
        void Update();

        /// <summary>
        /// Resets the score of the players earned in this {@link Lane}
        ///  </summary>
        void ResetScore();

    }
}