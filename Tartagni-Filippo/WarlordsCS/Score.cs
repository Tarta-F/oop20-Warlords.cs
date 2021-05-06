using System;

namespace WarlordsCS
{
	public class Score
	{
		public string Player1Name { get;}
		public string Player2Name { get; }
		public int ScoreP1 { get; }
		public int ScoreP2 { get; }
		public Score(string player1Name, string player2Name, int scoreP1, int scoreP2)
        {
			this.Player1Name = player1Name;
			this.Player2Name = player2Name;
			this.ScoreP1 = scoreP1;
            this.ScoreP2 = scoreP2;
        }
        public override string ToString()
        {
            return "P1: " + Player1Name + " P2: " + Player2Name + " Score: " + ScoreP1.ToString() + " - " + ScoreP2.ToString();
        }
	}
}
