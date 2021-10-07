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
            const int maxCount = 11;
            string[] garage = new string[maxCount];
            int vehicleCount = 0;
            string type;
            string regNr;
            bool exit = false;
            while (exit != true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1 - Add vehicle");
                Console.WriteLine("2 - Show garage");
                Console.WriteLine("3 - Move vehicle");
                Console.WriteLine("4 - Search");
                Console.WriteLine("5 - Remove vehicle");
                Console.WriteLine("0 - Exit");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        if (vehicleCount == maxCount)
                        {
                            Console.WriteLine("Garage is full!");
                        }
                        else
                        {
                            addVehicle();
                        }
                        break;
                    case "2":
                        for (int i = 1; i < garage.Length; i++)
                        {
                            Console.WriteLine("Parkingspot - {0} {1}", i, garage[i]);
                        }
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
                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Enter a command!");
                        break;
                }
            }

            void addVehicle()
            {
                for (int i = 1; i < garage.Length; i++)
                {
                    Console.WriteLine("Enter type:");
                    type = Console.ReadLine();

                    if (garage[i] == null)
                    {
                        Console.Write("Reg. number: ");
                        regNr = Console.ReadLine();
                        garage[i] = type + "+" + regNr;
                        vehicleCount++;
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            void moveVehicle()
            {
                throw new NotImplementedException();
            }

            void search()
            {
                Console.WriteLine("Enter Reg. number: ");
                string searchReg = Console.ReadLine();

                for (int i = 1; i < garage.Length; i++)
                {
                    if (searchReg == garage[i])
                    {
                        Console.WriteLine("{0} is on parkingspot: {1}", searchReg, i);
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