using Parkovka.Classes;
using System;
using System.Text;

namespace Parkovka
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            Parker parker = new Parker();
            Parker.parkerName = "";
            while (true) 
            {
                Console.Clear();

                int counter = 1;
            ConsoleKey key = ConsoleKey.Escape;
            do
            {
                Console.Clear();
                if (counter == 1) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Авторизуватись");
                Console.ResetColor();
                if (counter == 2) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Поставити автомобіль на парковку");
                Console.ResetColor();
                if (counter == 3) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3. випустити автомобіль з конкретного парковочного місця");
                Console.ResetColor();
                if (counter == 4) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4. подивитися стан парковки");
                Console.ResetColor();
                if (counter == 5) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("5. подивитися статистику штрафів");
                Console.ResetColor();
                if (counter == 6) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("6. Вийти");
                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;

                switch (key)
                {
                    case (ConsoleKey)ConsoleKey.DownArrow: 
                        {
                            if (counter < 6) { counter++; }
                            else { counter = 1; }
                            break;
                        }
                    case (ConsoleKey)ConsoleKey.UpArrow:
                        {
                            if (counter > 1) { counter--; }
                            else { counter = 6; }
                            break;
                        }
            }

            } while (key != ConsoleKey.Enter);
                Console.Clear();
                if (Parker.parkerName != "" || counter == 1 || counter == 6)
                {
                    switch (counter)
                    {
                        case 1:
                            {
                                string pName;
                                Console.Write("Ведіть ім'я:");
                                pName = Console.ReadLine();
                                Parker.parkerName = pName;
                                break;
                            }
                        case 2:
                            {
                                parker.AddCar();
                                break;
                            }
                        case 3:
                            {
                                Console.Write($"Ведіть номер місця (1-20): ");
                                try
                                {
                                    int num = int.Parse(Console.ReadLine());
                                    parker.RemoveFromParking(num);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.ReadKey();

                                break;
                            }
                        case 4:
                            {
                                parker.Statistic();
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine($"Штрафи: {parker.GetAllStraffs()}");
                                Console.ReadKey();
                                break;
                            }
                        case 6:
                            {
                                return;
                                break;
                            }
                    }
                }
                else 
                {
                    Console.WriteLine("Авторизуйтесь!");
                    Console.ReadKey();
                }

            

            }


        }
    }
}
