using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelLane;
using ModelUnit;
using ConstantsPlayerType;


namespace ModelLaneTest
{
	/// <summary>
	/// Test class of Lane.
	/// </summary>
	[TestClass]
	public class LaneTest
	{
		private ILane lane;
		private IUnit unit1;

		private int laneLenght;

		[TestInitialize]
		public void InitLane()
		{
			laneLenght = 15;
			lane = new Lane(laneLenght);
			unit1 = new Unit(UnitType.Swordsmen, PlayerType.Player1);
		}

		[TestMethod]
		public void TestAddUnitLane()
		{
			lane.AddUnit(unit1);
			Assert.AreEqual(unit1, lane.GetUnits());
			/*Si possono aggiungere altre unita', ma il test cambierebbe cosi. */
		}
	}
}