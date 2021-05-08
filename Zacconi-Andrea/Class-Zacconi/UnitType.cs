using System;
using System.Collections.Generic;
using System.Text;

namespace ModelUnit
{
	/// <summary>
	/// UnitType implementstion.
	/// </summary>
	public sealed class UnitType
	{
		/// <summary>
		/// Sowrdsmen unit type and his statistics.
		/// </summary>
		public static UnitType Swordsmen { get; } = new UnitType(UnitConstants.SwordsmenHealth, UnitConstants.SwordsmenDamage,
			UnitConstants.SwordsmenRange, UnitConstants.SwordsmenTimer, UnitConstants.Step);
		/// <summary>
		/// Spearmen unit type and his statistics.
		/// </summary>
		public static UnitType Spearmen { get; } = new UnitType(UnitConstants.SpearmenHealth, UnitConstants.SpearmenDamage,
			UnitConstants.SpearmenRange, UnitConstants.SpearmenTimer, UnitConstants.Step);
		/// <summary>
		/// Arhcer unit type and his statistics.
		/// </summary>
		public static UnitType Archer { get; } = new UnitType(UnitConstants.ArcherHealth, UnitConstants.ArcherDamage,
			UnitConstants.ArcherRange, UnitConstants.ArcherTimer, UnitConstants.Step);

		private readonly int health;
		private readonly int damage;
		private readonly int range;
		private readonly int timer;
		private readonly int step;

		/// <summary>
		/// Get unit type health.
		/// </summary>
		/// <returns></returns>
		public int Health => this.health;

		/// <summary>
		/// Get unit type damage.
		/// </summary>
		/// <returns></returns>
		public int Damage => this.damage;

		/// <summary>
		/// Get unit type range.
		/// </summary>
		/// <returns></returns>
		public int Range => this.range;

		/// <summary>
		/// Get unit type time of spawn.
		/// </summary>
		/// <returns></returns>
		public int Timer => this.timer;

		/// <summary>
		/// Get unit type movment.
		/// </summary>
		/// <returns></returns>
		public int Step => this.step;

		private UnitType(int health, int damage, int range, int timer, int step)
		{
			this.health = health;
			this.damage = damage;
			this.range = range;
			this.timer = timer;
			this.step = step;
		}
    }
}
