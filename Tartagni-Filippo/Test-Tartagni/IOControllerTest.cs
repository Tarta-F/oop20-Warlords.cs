using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using WarlordsCS;

namespace Test_Tartagni
{
    [TestClass]
    public class IOControllerTest
    {
        private readonly string scoreFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
            Path.DirectorySeparatorChar + "scores.json";
        ControllerIO ioController = new ControllerIO();
        Score score = new Score("Filippo", "Leonardo", 6, 1);

        //Printing all scores read.
        //results.ForEach(r => Console.WriteLine(r.ToString()));

        ///Create a file and verify if it's correctly deleted.
        [TestInitialize]
        public void Init()
        {
            if (!File.Exists(scoreFile))
            {
                using (File.Create(scoreFile)) ;
            }
        }

    [TestMethod]
        public void TestClearFile()
        {
            ioController.ClearFile();
            Assert.IsFalse(File.Exists(scoreFile));
        }

        [TestMethod]
        public void TestExists()
        {
            Assert.IsTrue(File.Exists(scoreFile));
        }

        [TestMethod]
        public void TestCountScore()
        {
            ioController.ClearFile();
            ioController.WriteNewScore(score);
            ioController.WriteNewScore(score);
            ioController.WriteNewScore(score);
            List<String> results = new List<string>(ioController.ReadScore());
            Assert.AreEqual(results.Count, 3);
        }
    }
}