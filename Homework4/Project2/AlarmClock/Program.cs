using System;

namespace AlarmClock
{
    class Program
    {
        static void Main()
        {
            ClockShell MyClock = new ClockShell();
            MyClock.TurnOn(10);//以10秒的目标时间设置闹钟启动
        }
    }
}
