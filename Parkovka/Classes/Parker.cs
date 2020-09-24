using System;
using System.Collections.Generic;
using System.Text;

namespace Parkovka.Classes
{
    class Parker
    {
        public static string parkerName;
        ParkingBook pb = ParkingBook.GetInstance();

        public void ShowHistory() 
        {
            pb.StatisticTickets();
        }
        public bool AddCar()
        {
            if (pb.IsNotFull())
            {
                Car car = new Car();
                pb.AddCarToParking(car);
                return true;
            }
            return false;
        }

        public int GetAllStraffs() 
        {
            return pb.GetAllStraffs();
        }

        public void Statistic() 
        {
            pb.Statistic();
        }

        public void RemoveFromParking(int id)
        {
            Car car = pb.ReturnFromParking(id);
            if (car == null)
            {
                Console.WriteLine("Автомобіля не знайдено!");
                return;
            }
            Ticket ticket = new Ticket(car);
            ticket.ShowTicket();
            pb.AddToTickets(ticket);
        }

        public void ShowAllCars() 
        {
            for (int i = 0; i < pb.GetSize(); i++) 
            {
                if (pb[i] != null) 
                {
                    Console.WriteLine($"Parking place {i+1}");
                    Console.WriteLine(pb[i].GetColor());
                    Console.WriteLine(pb[i].GetModel());
                    Console.WriteLine(pb[i].GetNumber());
                    Console.WriteLine($"Parker: {Parker.parkerName}");
                    Console.WriteLine("\t***");
                }
            }
        }
        public Car this[string str] 
        {
            get 
            {
                for (int i = 0; i < pb.GetSize(); i++) 
                {
                    if (pb[i].GetModel() == str || pb[i].GetNumber() == str || pb[i].GetColor() == str) 
                    {
                        return pb[i];
                    }
                }
                return null;
            }
        }

        public Car this[string mark, string color, string numer]
        {
            get
            {
                for (int i = 0; i < pb.GetSize(); i++)
                {
                    if (pb[i].GetModel() == mark && pb[i].GetNumber() == numer && pb[i].GetColor() == color)
                    {
                        return pb[i];
                    }
                }
                return null;
            }
        }
    }
}
