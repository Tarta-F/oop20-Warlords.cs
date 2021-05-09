using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ModelTest
{
    [TestClass]
    public class LaneTest
    {
        private ILane lane;
        private IUnit unit1;
        private IUnit unit2;

        private const int CLASH_POSITION = FieldTest.CELLS_NUM / 2 - 1;

        [TestInitialize]
        public void TestInitialize()
        {
            lane = new Lane(FieldTest.CELLS_NUM);
            unit1 = new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER1);
            unit2 = new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER2);

            lane.AddUnit(unit1);
            lane.AddUnit(unit2);
        }

        [TestMethod]
        public void TestAddUnitAndGetLenght()
        {
            Assert.AreEqual(0, lane.GetUnits()[unit1]);
            Assert.AreEqual(FieldTest.CELLS_NUM - 1, lane.GetUnits()[unit2]);
        }

        [TestMethod]
        public void TestMovement()
        {
            lane.Update();
            lane.Update();

            Assert.AreEqual(2, lane.GetUnits()[unit1]);
            Assert.AreEqual(FieldTest.CELLS_NUM - 3, lane.GetUnits()[unit2]);

            lane.Update();

            Assert.AreEqual(3, lane.GetUnits()[unit1]);
            Assert.AreEqual(FieldTest.CELLS_NUM - 4, lane.GetUnits()[unit2]);
        }

        [TestMethod]
        public void TestIndexers()
        {
            Assert.IsTrue(lane[0].SetEquals(new HashSet<IUnit> { unit1 }));
            Assert.IsTrue(lane[FieldTest.CELLS_NUM - 1].SetEquals(new HashSet<IUnit> { unit2 }));

            lane.Update();

            Assert.IsTrue(lane[1].SetEquals(new HashSet<IUnit> { unit1 }));
            Assert.IsTrue(lane[FieldTest.CELLS_NUM - 2].SetEquals(new HashSet<IUnit> { unit2 }));

            unit1 = new Unit(UnitType.ARCHER, PlayerType.PLAYER1);
            unit2 = new Unit(UnitType.SPEARMEN, PlayerType.PLAYER1);
            lane.AddUnit(unit1);
            lane.AddUnit(unit2);

            Assert.IsTrue(lane[0].SetEquals(new HashSet<IUnit> { unit1, unit2 }));

            try
            {
                var test = this.lane[FieldTest.CELLS_NUM];
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.IsNotNull(e.Message);
                Assert.IsFalse(e.Message.Length <= 0);
            }
        }

        [TestMethod]
        public void TestAttackAndDespawn()
        {
            for (int i = 0; i<CLASH_POSITION; i++)
            {
                Assert.AreEqual(i, lane.GetUnits()[unit1]);
                Assert.AreEqual(FieldTest.CELLS_NUM - 1 - i, lane.GetUnits()[unit2]);
                lane.Update();
            }

            Assert.AreEqual(CLASH_POSITION, lane.GetUnits()[unit1]);
            Assert.AreEqual(FieldTest.CELLS_NUM - 1 - CLASH_POSITION, lane.GetUnits()[unit2]);

            lane.Update();

            /*
             * The behaviour of the units from here on is undefined as you do not know which one will move first 
             * and consequently attack second.
             */
            for (int i = 0; i <= CLASH_POSITION; i++)
            {
                lane.Update();
            }
        }

        [TestMethod]
        public void TestScoreAndDespawn()
        {
            lane = new Lane(FieldTest.CELLS_NUM);
            lane.AddUnit(unit1);

            for (int i = 0; i < FieldTest.CELLS_NUM; i++)
            {
                Assert.AreEqual(i, lane.GetUnits()[unit1]);
                lane.Update();
            }

            Assert.AreEqual(1, lane.GetScore(PlayerType.PLAYER1));
            Assert.IsFalse(lane.GetUnits().ContainsKey(unit1));
        }

    }
}
