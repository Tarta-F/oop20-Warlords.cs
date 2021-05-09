using System;
using System.Collections.Generic;
using System.Text;

using ConstantsPlayerType;

namespace ModelUnit
{
	/// <summary>
	/// Unit interface.
	/// </summary>
	public interface IUnit
	{
        /// <summary>
        /// Get unit time of spawn.
        /// </summary>
        /// <returns></returns>
        int WaitingTime { get; }

        /// <summary>
        /// Get unit health.
        /// </summary>
        /// <returns></returns>
        int Hp { get; }

        /// <summary>
        /// Get unit movment.
        /// </summary>
        /// <returns></returns>
        int Step { get; }

        /// <summary>
        /// Get unit range attack.
        /// </summary>
        /// <returns></returns>
        int Range { get; }

        /// <summary>
        /// Get unit damaga.
        /// </summary>
        /// <returns></returns>
        int GetDamage();

		/// <summary>
		/// Unit take damage.
		/// </summary>
		/// <param name="damage"></param>
		void Damage(int damage);

        /// <summary>
        /// Get unit player.
        /// </summary>
        /// <returns></returns>
        PlayerType Player { get; }

        /// <summary>
        /// Get unit type.
        /// </summary>
        /// <returns></returns>
        UnitType UnitType { get; }

        /// <summary>
        /// Unit attack to another unit.
        /// </summary>
        /// <param name="unit"></param>
        void Attack(IUnit unit);

		/// <summary>
		/// Unit life status.
		/// </summary>
		/// <returns></returns>
		bool IsAlive();
	}
}
