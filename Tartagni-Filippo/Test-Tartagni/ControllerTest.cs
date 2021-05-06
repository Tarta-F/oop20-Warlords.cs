using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarlordsCS;

namespace Test_Tartagni
{
    [TestClass]
    public class ControllerTest
    {
        private readonly Controller contr = new Controller();

        /// <summary>
        /// Controls if lane selected by players works in the right way.
        /// </summary>
        [TestMethod]
        public void TestLane()
        {
            contr.ControlNextLane(1);
            contr.ControlNextLane(1);
            contr.ControlNextLane(1);
            contr.ControlPrevLane(1);
            contr.ControlPrevLane(1);
            contr.ControlNextLane(1);
            contr.ControlNextLane(1);
            Assert.AreEqual(contr.GetMapUtil(1), 0);
        }
    }
}
