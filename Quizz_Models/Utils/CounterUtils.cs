using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Quizz_Models.Utils
{
    class CounterUtils
    {
        /// <summary>
        /// Class qui gerent un chronometre 
        /// 
        /// </summary>

        private static Stopwatch stopWatch { get; set; }
        private TimeSpan Counter_Q { get; set; }



        private Boolean Isrestart { get; set; }
        public CounterUtils()
        {
            stopWatch = new Stopwatch();
            Thread.Sleep(10000);
        }


        public void StartCounter()
        {
            stopWatch.Start();

        }

        /// <summary>
        /// methode qui gerent un chronometre 
        /// 
        /// </summary>
        public TimeSpan RestartCounter(DateTime DatetimeSpan)
        {
            Counter_Q = DatetimeSpan.TimeOfDay;
            Counter_Q = stopWatch.Elapsed + Counter_Q;
            stopWatch.Start();
            return Counter_Q;
        }
        public TimeSpan StopCounter()
        {
            stopWatch.Stop();
            Counter_Q = Counter_Q + stopWatch.Elapsed;
            return Counter_Q;
        }
        public void ResetCounter()
        {
            stopWatch.Reset();
            Counter_Q = stopWatch.Elapsed;
        }

        public string DisplayCounter()
        {
            string DisplayCnt = Convert.ToString(Counter_Q + stopWatch.Elapsed);
            return DisplayCnt;

        }


    }
}
