using System;
using System.Collections.Generic;
using System.Text;

namespace Parkovka.Classes
{
    class ParkingBook
    {
        //Singleton
        private static ParkingBook parkingBook = new ParkingBook();
        private ParkingBook()
        {

        }

        private const int size = 20;
        private int sizeCars = 0;
        private Car[] cars = new Car[size];
        private List<Ticket> tickets = new List<Ticket>();

        public bool IsNotFull() 
        {
            if (this.sizeCars == size) 
            {
                return false;
            }
            return true;
        }

        public int GetAllStraffs() 
        {
            int sum = 0;
            foreach (var item in tickets) 
            {
                sum += item.GetStraff();
            }
            return sum;
        }
        public void AddCarToParking(Car c) 
        {
            if (IsNotFull())
            {
                for (int i = 0; i < 20; i++) 
                {
                    if (this.cars[i] == null) 
                    {
                        this.cars[i] = c;
                        this.sizeCars++;
                        return;
                    }
                }
            }
            else 
            {
             Console.WriteLine("Parking is full!");
            }
        }

        public Car ReturnFromParking(int id) 
        {
            id--;
            if (this.cars[id] == null) { return null; }
            if (id >= 0 && id < size) 
            {
            Car car = this.cars[id];
            this.cars[id] = null;
            this.sizeCars--;
            return car;
            }
            return null;
        }

        public void AddToTickets(Ticket ticket) 
        {
            this.tickets.Add(ticket);
        }

        public void Statistic() 
        {
            Console.WriteLine($"\nКількість вільних місць - {((double)(size - this.sizeCars) / (double)size)*100}%\n");
            Console.WriteLine($"\nКількість зайнятих місць - {((double)this.sizeCars / (double)size) * 100}%\n");
        }

        public void StatisticTickets() 
        {
            int minutes = 0;
            int straffs = 0;
            int minutesProst = 0;
            foreach (var item in this.tickets) 
            {
                DateTime buyedTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                    item.GetBuyedTime().Hour - item.GetDtIn().Hour,
                    item.GetBuyedTime().Minute - item.GetDtIn().Minute,
                    item.GetBuyedTime().Second - item.GetDtIn().Second);

                int hour = item.GetDtOut().Hour - item.GetBuyedTime().Hour;
                int minute = item.GetDtOut().Minute - item.GetBuyedTime().Minute;
                int second = item.GetDtOut().Second - item.GetBuyedTime().Second;

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

                DateTime PTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    hour,
                    minute,
                    second);

                minutes += buyedTime.Hour * 60;
                minutes += buyedTime.Minute;
                straffs += item.GetStraff();
                minutesProst += PTime.Hour * 60;
                minutesProst += PTime.Minute;
            }

            Console.WriteLine($"Проданий час (хв): {minutes}");
            Console.WriteLine($"Штрафи (грн): {straffs}");
            Console.WriteLine($"Час простою (хв): {minutesProst}");

        }

        public int GetSize() 
        {
            return size;
        }

        public static ParkingBook GetInstance() 
        {
            if (parkingBook == null) { parkingBook = new ParkingBook(); }
            return parkingBook;
        }

        public Car this[int a] 
        {
            get 
            {
                return this.cars[a];
            }
        }
    }
}
