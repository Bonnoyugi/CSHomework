using System;
using System.Threading;

namespace AlarmClock
{
    public class Clock
    {
        public event TickHanlder Tick;
        public event AlarmHanlder Alarm;
        public int AlarmTime { set; get; }

        public void Run()
        {
            int currentTime = 0;
            while (true)
            {
                Thread.Sleep(1000);
                currentTime++;
                Tick();
                if (currentTime == AlarmTime)
                    Alarm();
            }
        }
    }
}
