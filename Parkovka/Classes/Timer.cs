using System;
using System.Collections.Generic;
using System.Text;

namespace Parkovka.Classes
{
    class Timer
    {
        public DateTime inTime;
        public DateTime outTime;
        public DateTime buyedTime;
        public int GetMinutes() 
        {
            int sum = 0;

            sum += this.buyedTime.Hour * 60;
            sum += this.buyedTime.Minute;
            sum += this.buyedTime.Second / 60;

            Console.WriteLine(this.buyedTime.Hour * 60);
            Console.WriteLine(this.buyedTime.Minute);
            Console.WriteLine(this.buyedTime.Second / 60);

            return sum;
        }
        public Timer()
        {
            Random r = new Random();
            
            this.inTime = DateTime.Now;
            this.buyedTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, r.Next(inTime.Hour, 24),
                r.Next(inTime.Minute, 60),
                r.Next(inTime.Second, 60));
            this.outTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, r.Next(inTime.Hour, 24),
                           r.Next(inTime.Minute, 60),
                           r.Next(inTime.Second, 60));
        }
        public int PTime() 
        {
            int outRes = 0;
            int buyRes = 0;

            outRes += this.outTime.Hour * 60;
            outRes += this.outTime.Minute;
            outRes += this.outTime.Second / 60;

            buyRes += this.buyedTime.Hour * 60;
            buyRes += this.buyedTime.Minute;
            buyRes += this.buyedTime.Second / 60;

            return outRes - buyRes;

        }

        public DateTime GetPtime()
        {
            int hour = outTime.Hour - buyedTime.Hour;
            int minute = outTime.Minute - buyedTime.Minute;
            int second = outTime.Second - buyedTime.Second;

            if (hour < 0) 
            {
                hour = 0;
                minute = 0;
                second = 0;
            }

            if (minute < 0) 
            {
                minute = 0;
                second = 0;
            }

            if (second < 0) 
            {
                second = 0;
            }

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,hour, 
                minute, 
                second);
            Console.WriteLine("\n\n\n\n"+dt);
            return dt;
        }

    }
}
