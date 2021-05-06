using System;
using System.Threading;

namespace WarlordsCS
{
	public abstract class AbstractTimer : Timer
	{
        public bool Stop { get; set; }
        public int TotSec { get; set; }
        private IController contr;
		public AbstractTimer()
		{
            this.contr = new Controller();
            TotSec = 0;
            Stop = false;
		}

        public void Reset()
        {
            TotSec = 0;
        }

        public void Run()
        {
            while (TotSec > 0 && !Stop)
            {
                Cycle();
                Thread.Sleep(1000);
            }
            TimeOut();
        }

        public void StopTimer()
        {
            Stop = true;
            contr.TimeIsOver();
        }

        protected abstract void Cycle();

        protected abstract void TimeOut();
    }
}