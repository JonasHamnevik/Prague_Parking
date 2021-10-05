using System;
using System.Collections.Generic;

namespace Laboration2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            string[] garage = new string[10];

            List<string> vehicles = new List<string>(garage);
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1 - Add car");
                Console.WriteLine("2 - Add MC");
                Console.WriteLine("3 - Move vehicle");
                Console.WriteLine("4 - Search");
                Console.WriteLine("5 - Remove vehicle");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        addCar();
                        break;
                    case "2":
                        addMc();
                        break;
                    case "3":
                        moveVehicle();
                        break;
                    case "4":
                        search();
                        break;
                    case "5":
                        removeVehicle();
                        break;
                    default:
                        break;
                }

                for (int i = 0; i < garage.Length; i++)
                {
                    Console.WriteLine("Parkinglot - {0} {1}", i + 1, garage[i]);
                }

            }

            void addCar()
            {
                for (int i = 0; i < garage.Length; i++)
                {
                    string type = "Car";

                    if (garage[i] == null)
                    {
                        Console.Write("Reg. number: ");
                        string regNr = Console.ReadLine();
                        garage[i] = type + " - " + regNr;
                        vehicles.Add(garage[i]);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            void addMc()
            {
                string type = "MC";

                for (int i = 0; i < garage.Length; i++)
                {
                    if (garage[i] == null)
                    {
                        Console.Write("Reg. number: ");
                        string regNr = Console.ReadLine();
                        garage[i] = type + " - " + regNr;
                        vehicles.Add(garage[i]);
                        Console.Clear();
                        break;
                    }

                    for (int j = i; j < garage.Length; j++)
                    {
                        if (garage[i] != null && garage[i] == "MC")
                        {
                            Console.Write("Reg. number: ");
                            string regNr = Console.ReadLine();
                            garage[i] = " | " + type + " - " + regNr;
                            vehicles.Add(garage[i]);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            void moveVehicle()
            {
                throw new NotImplementedException();
            }

            void search()
            {
                Console.WriteLine("1 - Car");
                Console.WriteLine("2 - Mc");
                string search = Console.ReadLine();
                if (search == "1")
                {
                    Console.Write("Reg. number: ");
                    string searchReg = Console.ReadLine().ToLower();

                    for (int i = 0; i < garage.Length; i++)
                    {
                        if ("Car - " + searchReg == garage[i])
                        {
                            Console.Write("{0} is on parkinglot number: {1}\n\n", search, i);
                            break;
                        }
                        else
                        {
                            Console.Write("{0} doesn't exist", search);
                            break;
                        }
                    }
                }
                else if (search == "2")
                {
                    Console.Write("Reg. number: ");
                    string searchReg = Console.ReadLine().ToLower();

                    for (int i = 0; i < garage.Length; i++)
                    {
                        if ("MC - " + searchReg == garage[i])
                        {
                            Console.Write("{0} is on parkinglot number: {1}\n\n", search, i);
                            break;
                        }
                        else
                        {
                            Console.Write("{0} doesn't exist", search);
                            break;
                        }
                    }
                }

            }

            static void removeVehicle()
            {
                throw new NotImplementedException();
            }
        }
    }
}