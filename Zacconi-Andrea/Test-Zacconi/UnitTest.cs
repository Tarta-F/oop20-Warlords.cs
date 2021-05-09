using Microsoft.VisualStudio.TestTools.UnitTesting;

using ModelLane;
using ModelUnit;
using ConstantsPlayerType;

/// <summary>
/// Unit test.
/// </summary>
namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private IUnit unit1;
        private IUnit unit2;
        private IUnit unit3;

        [TestInitialize]
        public void InitUnits()
        {
            unit1 = new Unit(UnitType.Swordsmen, PlayerType.Player1);
            unit2 = new Unit(UnitType.Spearmen, PlayerType.Player2);
            unit3 = new Unit(UnitType.Archer, PlayerType.Player1);
        }

        [TestMethod]
        public void TestGetUnitStatistics()
        {
            /*Unit 1 statistics. */
            Assert.AreEqual(UnitConstants.SwordsmenHealth, unit1.Hp);
            Assert.AreEqual(UnitConstants.SwordsmenDamage, unit1.GetDamage());
            Assert.AreEqual(UnitConstants.SwordsmenRange, unit1.Range);
            Assert.AreEqual(UnitConstants.SwordsmenTimer, unit1.WaitingTime);
            Assert.AreEqual(UnitConstants.Step, unit1.Step);
            Assert.AreEqual(PlayerType.Player1, unit1.Player);
            Assert.AreEqual(UnitType.Swordsmen, unit1.UnitType);
            Assert.IsTrue(unit1.IsAlive());

            /*Unit 2 statistics. */
            Assert.AreEqual(UnitConstants.SpearmenHealth, unit2.Hp);
            Assert.AreEqual(UnitConstants.SpearmenDamage, unit2.GetDamage());
            Assert.AreEqual(UnitConstants.SpearmenRange, unit2.Range);
            Assert.AreEqual(UnitConstants.SpearmenTimer, unit2.WaitingTime);
            Assert.AreEqual(UnitConstants.Step, unit2.Step);
            Assert.AreEqual(PlayerType.Player2, unit2.Player);
            Assert.AreEqual(UnitType.Spearmen, unit2.UnitType);
            Assert.IsTrue(unit2.IsAlive());

            /*Unit 3 statistics. */
            Assert.AreEqual(UnitConstants.ArcherHealth, unit3.Hp);
            Assert.AreEqual(UnitConstants.ArcherDamage, unit3.GetDamage());
            Assert.AreEqual(UnitConstants.ArcherRange, unit3.Range);
            Assert.AreEqual(UnitConstants.ArcherTimer, unit3.WaitingTime);
            Assert.AreEqual(UnitConstants.Step, unit3.Step);
            Assert.AreEqual(PlayerType.Player1, unit3.Player);
            Assert.AreEqual(UnitType.Archer, unit3.UnitType);
            Assert.IsTrue(unit3.IsAlive());
        }

        [TestMethod]
        public void TestAttackAndGetDamage()
        {
            /*Unit 1 attack Unit 2, Unit 2 health should be equal to his max health - the Unit 1 damage. */
            unit1.Attack(unit2);
            Assert.AreEqual(UnitConstants.SpearmenHealth - UnitConstants.SwordsmenDamage, unit2.Hp);

            /*Unit 3 take damage equal to his mx health, Unit 3 should be dead. */
            unit3.Damage(UnitConstants.ArcherHealth);
            Assert.IsFalse(unit3.IsAlive());
        }
    }
}
