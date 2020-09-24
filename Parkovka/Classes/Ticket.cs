using System;
using System.Collections.Generic;
using System.Text;

namespace Parkovka.Classes
{
    class Ticket
    {
        private string model;
        private string color;
        private string number;
        private DateTime dtIn;
        private DateTime dtOut;
        private DateTime buyedTime;
        private DateTime pTime;
        private int straff;

        private string parkerName;

        public string GetParkerName()
        {
            return this.parkerName;
        }
        public string GetModel() 
        {
            return this.model;
        }

        public string GetColor() 
        {
            return this.color;
        }

        public string GetNumber() 
        {
            return this.number;
        }

        public DateTime GetDtIn() 
        {
            return this.dtIn;
        }

        public DateTime GetDtOut()
        {
            return this.dtOut;
        }

        public DateTime GetBuyedTime() 
        {
            return this.buyedTime;
        }

        

        public DateTime GetPTime() 
        {
            return this.pTime;
        }

        public int GetStraff() 
        {
            return this.straff;
        }

        public Ticket(Car car)
        {
            this.buyedTime = car.GetTimer().buyedTime;
            this.color = car.GetColor();
            this.dtIn = car.GetTimer().inTime;
            this.dtOut = car.GetTimer().outTime;
            this.model = car.GetModel();
            this.number = car.GetNumber();
            this.parkerName = Parker.parkerName;
            this.pTime = car.GetTimer().GetPtime();

            int sum = this.pTime.Hour * 60;
            sum += this.pTime.Minute;
            int i = 0;
            while (sum > 0) 
            {
                if (sum < 60 && sum > 0) 
                {
                    if (i == 0)
                    {
                        sum += StraffOfFirstHour;
                    }
                    else 
                    {
                        sum += StraffOfNextHour;
                    }
                }
                if (i == 0)
                {
                    straff += StraffOfFirstHour;
                }
                else 
                {
                    straff += StraffOfNextHour;
                }
                sum -= 60;
                i++;
            }
        }

        public void ShowTicket() 
        {
            Console.WriteLine("*** Ticket ***");
            Console.WriteLine($"Модель: {this.model}");
            Console.WriteLine($"Колір: {this.color}");
            Console.WriteLine($"Номер: {this.number}");
            Console.WriteLine($"Час в'їзду: {this.dtIn.Hour}:{this.dtIn.Minute}:{this.dtIn.Second}");
            Console.WriteLine($"Час виїзду: {this.dtOut.Hour}:{this.dtOut.Minute}:{this.dtOut.Second}");
            Console.WriteLine($"Куплений час: {this.buyedTime.Hour}:{this.buyedTime.Minute}:{this.buyedTime.Second}");
            Console.WriteLine($"Час перестою: {this.pTime.Hour}:{this.pTime.Minute}:{this.pTime.Second}");
            Console.WriteLine($"Штраф: {this.straff}");
            Console.WriteLine($"Парковщик: {this.parkerName}");
            Console.WriteLine("**************");
        }

        static public int StraffOfFirstHour { get; set; } = 25;
        static public int StraffOfNextHour { get; set; } = 10;



    }
}
