using System;
using System.Collections.Generic;
using System.Threading;

namespace WarlordsCS
{
    /// <summary>
    /// Utility class to write on output Scores and Currently Selected lanes of both players.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ///Creating a new Score.
            var score = new Score("Filippo", "Leonardo", 6, 1);

            var ioController = new ControllerIO();
            
            ///Clearing file, if it already exists.
            //ioController.ClearFile();

            //Writing 3 times a new score.
            ioController.WriteNewScore(score);

            //Reading scores from file...
            List<String> results = new List<string>(ioController.ReadScore());

            //Printing all scores read.
            results.ForEach(r => Console.WriteLine(r.ToString()));

            var contr = new Controller();
            foreach (KeyValuePair<int, int> v in contr.SelectedLane)
            {
                Console.WriteLine("P1: " + v.Key.ToString() + " P2: " + v.Value.ToString());
            }
        }
    }
}
