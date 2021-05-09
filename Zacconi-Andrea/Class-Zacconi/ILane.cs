using System.Collections.Generic;

using ModelUnit;

namespace ModelLane
{
	/// <summary>
	/// Lane interface.
	/// </summary>
	public interface ILane
	{
		/// <summary>
		/// Add unit in the lane.
		/// </summary>
		/// <param name="unit"></param>
		void AddUnit(IUnit unit);

		/// <summary>
		/// Get units in the lane.
		/// </summary>
		/// <returns></returns>
		IUnit GetUnits();
	}
}