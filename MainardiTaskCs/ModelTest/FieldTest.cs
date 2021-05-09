using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Linq;

namespace ModelTest
{
    [TestClass]
    public class FieldTest
    {
        private IField field;
        private IUnit unit1;
        private IUnit unit2;

        public const int CELLS_NUM = 20;

        [TestInitialize]
        public void TestInitialize()
        {
            field = new Field(CELLS_NUM, 3);
            unit1 = new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER1);
            unit2 = new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER2);

            field.AddUnit(0, unit1);
            field.AddUnit(1, unit2);
        }

        [TestMethod]
        public void TestAddAndGetUnit()
        {
            int unitCounter = 2;

            Assert.AreEqual(Tuple.Create(0, 0), field.GetUnits()[unit1]);
            Assert.AreEqual(Tuple.Create(CELLS_NUM - 1, 1), field.GetUnits()[unit2]);

            field.Update();
            field.Update();

            Assert.AreEqual(Tuple.Create(2, 0), field.GetUnits()[unit1]);
            Assert.AreEqual(Tuple.Create(CELLS_NUM - 3, 1), field.GetUnits()[unit2]);

            unit1 = new Unit(UnitType.ARCHER, PlayerType.PLAYER1);
            unit2 = new Unit(UnitType.ARCHER, PlayerType.PLAYER1);

            field.AddUnit(1, unit1);
            unitCounter++;
            field.AddUnit(2, unit2);
            unitCounter++;

            Assert.AreEqual(Tuple.Create(0, 1), field.GetUnits()[unit1]);
            Assert.AreEqual(Tuple.Create(0, 2), field.GetUnits()[unit2]);

            unit1 = new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER1);

            try
            {
                field.AddUnit(4, unit1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
                Assert.IsNotNull(e.Message);
                Assert.IsFalse(e.Message.Length <= 0);
            }

            for (int i = 0; i < field.LaneNumber; i++)
            {
                field.AddUnit(i, new Unit(UnitType.SWORDSMEN, PlayerType.PLAYER1));
            }
            unitCounter += field.LaneNumber;

            Assert.AreEqual(field.GetUnits().Count, unitCounter);
        }

        [TestMethod]
        public void TestGetScore()
        {
            for (int i = 0; i < field.CellsNumber - 1; i++)
            {
                field.Update();
            }
            Assert.AreEqual(Tuple.Create(CELLS_NUM - 1, 0), field.GetUnits()[unit1]);
            Assert.AreEqual(Tuple.Create(0, 1), field.GetUnits()[unit2]);

            field.Update();

            Assert.AreEqual(1, field.GetScore(PlayerType.PLAYER1));
        }
    }

}
