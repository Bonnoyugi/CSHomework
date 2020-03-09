using System;

namespace AlarmClock
{
    public delegate void TickHanlder();
    public delegate void AlarmHanlder();

    class ClockShell
    {
        readonly Clock clock;

        public ClockShell()
        {
            clock = new Clock();
            clock.Tick += new TickHanlder(PrintCurrentTime);
            clock.Alarm += new AlarmHanlder(AlarmInScreen);
            clock.Alarm += AlarmInSound;//已经创建委托后直接加方法即可
        }

        public void TurnOn(int TargetTime)
        {
            clock.AlarmTime = TargetTime;
            clock.Run();
        }

        void PrintCurrentTime()
        {
            Console.Out.WriteLine(DateTime.Now.Hour + "时" + DateTime.Now.Minute + "分" + DateTime.Now.Second + "秒");
        }

        void AlarmInScreen()
        {
            Console.Out.WriteLine("时间到！！！");
        }

        void AlarmInSound()
        {
            System.Console.Write("\a");
        }
    }
}
