using System;
namespace WarlordsCS
{
	public class GameTimer : AbstractTimer
	{
        public int mins;
        public int seconds;
        private readonly IController controller;
		public GameTimer(int mins, int seconds)
		{
            this.mins = mins;
            this.seconds = seconds;
            base.TotSec = (this.mins * 60) + this.seconds;
            this.controller = new Controller();
		}

        protected override void Cycle()
        {
            this.seconds = base.TotSec % 60;
            this.mins = (base.TotSec - this.seconds) / 60;
            base.TotSec--;
            Console.WriteLine(TotSec.ToString());
        }

        protected override void TimeOut()
        {
            base.StopTimer();
            controller.TimeIsOver();
        }
    }
}