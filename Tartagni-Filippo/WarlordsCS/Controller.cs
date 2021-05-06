using System;
using System.Collections.Generic;

namespace WarlordsCS
{
	public class Controller : IController
	{
        private static readonly int numLane = 5;
        public IDictionary<int, int> SelectedLane { get; }
        public bool IsTimeOver { get; set; }
        public enum Player { P1, P2 };
		public Controller()
		{
            IsTimeOver = false;
            this.SelectedLane = new Dictionary<int, int> {
                { 1, (int) numLane / 2 },
                { 2, (int) numLane / 2 }
            };
		}

        public void ControlNextLane(int playerIndex)
        {
            var currLane = GetMapUtil(playerIndex);
            SelectedLane.Remove(playerIndex);
            var nextLane = (currLane + 1) % numLane;
            SelectedLane.Add(playerIndex, nextLane);
        }

        public void ControlPrevLane(int playerIndex)
        {
            var currLane = GetMapUtil(playerIndex);
            SelectedLane.Remove(playerIndex);
            var prevLane = (currLane == 0 ? numLane - 1 : (currLane - 1) % numLane);
            SelectedLane.Add(playerIndex, prevLane);
        }

        public bool TimeIsOver()
        {
            return this.IsTimeOver;
        }

        public int GetMapUtil(int player)
        {
            int val;
            return (SelectedLane.TryGetValue(player, out val)) ? val : 0;
        }
    }
}
