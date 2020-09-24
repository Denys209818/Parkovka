using System;
using System.Collections.Generic;
using System.Text;

namespace Parkovka.Classes
{
    public enum Nummers { BK, BC, AA, AC }
    public enum Mark { Lexus, Audi, Bmw, Volkswagen }

    class Car
    {
        private string model;
        private string color;
        private string number;
        private Timer timer = new Timer();

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

        public Timer GetTimer() 
        {
            return this.timer;
        }

        
        public Car()
        {
            Random r = new Random();
            int numer = r.Next(0,3);
            string numerStr = Enum.GetName(typeof(Nummers), numer);
            int randNum = r.Next(1111, 9999);
            this.number += numerStr;
            this.number += randNum;
            this.number += numerStr;

            numer = r.Next(0, 3);
            numerStr = Enum.GetName(typeof(Mark), numer);
            this.model = numerStr;

            numer = r.Next(1,3);
            switch (numer) 
            {
                case 1: this.color = "Red"; break;
                case 2: this.color = "Blue"; break;
                case 3: this.color = "Green"; break;
            }
        }


    }
}
