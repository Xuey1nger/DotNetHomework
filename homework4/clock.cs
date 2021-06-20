using System;
using System.Collections.Generic;
using System.Text;

namespace homework4
{
    public delegate void A();
    class clock
    {
        int second;
        int minute;
        int hour;
        int alarms;
        int alarmm;
        int alarmh;
        public clock(int alarms,int alarmm,int alarmh)
        {
            this.alarms = alarms;
            this.alarmm = alarmm;
            this.alarmm = alarmh;
            second = 0;
            minute = 0;
            hour = 0;
        }

        public event A tick;
        public event A alarm;

        public void add()
        {
            second++;
            if(second==60)
            {
                minute++;
                second = 0;
            }
            if(minute==60)
            {
                hour++;
                minute = 0;
            }
            if(hour==24)
            {
                hour = 0;
            }
        }

        public void start()
        {
            while(true)
            {
                tick();
                add();
                if (second == alarms && minute == alarmm && hour == alarmh)
                {
                    alarm();
                    break;
                }
            }
        }
    }

    class tick
    {
        public tick(clock Clock)
        {
            Clock.tick += Tick;
        }

        public void Tick()
        {
            Console.Write("滴答 ");
        }
    }

    class alarm
    {
        public alarm(clock Clock)
        {
            Clock.alarm += Alarm;
        }

        public void Alarm()
        {
            Console.Write("响铃 ");
        }
    }
}

