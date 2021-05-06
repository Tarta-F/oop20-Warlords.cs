using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using WarlordsCS;

namespace Test_Tartagni
{
    [TestClass]
    public class TimerTest
    {
        private readonly AbstractTimer gameTimer = new GameTimer(0, 5);

        //Create a GameTimer and verify if it ends correctly.
        [TestMethod]
        public void TestTimer()
        {
            ThreadStart action = delegate { gameTimer.Run(); };
            new Thread(action).Start();
            Assert.IsFalse(gameTimer.Stop);
            Thread.Sleep(6000);
            Assert.IsTrue(gameTimer.Stop);
        }
    }
}