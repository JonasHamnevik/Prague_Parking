using System;
using System.Collections.Generic;

namespace Laboration2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] garage = new string[11]; //Ska börja på 1 och sluta på 10 när det hanteras och när det skrivs ut.
            int carCount = 0;
            int mcCount = 0;

            string type;
            string regNr;
            bool exit = false;
            while (exit != true)
            {
                int vehicleCount = carCount + mcCount;

                Console.WriteLine("Main Menu");
                Console.WriteLine("1 - Add Car");
                Console.WriteLine("2 - Add MC");
                Console.WriteLine("3 - Show garage");
                Console.WriteLine("4 - Move vehicle");
                Console.WriteLine("5 - Search");
                Console.WriteLine("6 - Remove vehicle");
                Console.WriteLine("0 - Exit");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1": //Lägga till bil
                        if (vehicleCount == garage.Length)
                        {
                            Console.WriteLine("Garage is full!");
                        }
                        else
                        {
                            addCar();
                        }
                        break;

                    case "2": //Lägga till MC
                        if (vehicleCount == garage.Length)
                        {
                            Console.WriteLine("Garage is full!");
                        }
                        else
                        {
                            addMc();
                        }
                        break;

                    case "3": //Visa garaget
                        Console.Clear();
                        for (int i = 1; i < garage.Length; i++)
                        {
                            Console.WriteLine("Parkingspot - {0} {1}", i, garage[i]);
                        }
                        Console.WriteLine("\nAmount of cars: {0}", carCount);
                        Console.WriteLine("\nAmount of MC: {0}", mcCount);
                        Console.WriteLine("\nThe garage has {0} free spots of {1} spots\n", (garage.Length -1) - vehicleCount, garage.Length -1);
                        break;

                    case "4": //flytta fordon
                        moveVehicle();
                        break;

                    case "5": //Söka efter fordon
                        Console.Clear();
                        Console.WriteLine("Enter Reg. number: ");
                        string searchReg = Console.ReadLine();

                        for (int i = 1; i < garage.Length; i++)
                        {
                            if (garage[i] == null)
                            {
                                break;
                            }
                            else if (garage[i].Contains(searchReg)) //Blir fel när jag söker efter att jag har flyttat ett fordon
                            {
                                Console.WriteLine("\n\n{0} is on parkingspot: {1}\n", garage[i], i);
                                break;
                            }
                        }
                        break;

                    case "6": //Ta bort fordon
                        removeVehicle();
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Enter a command!");
                        break;
                }

            }

            void addCar()
            {
                for (int i = 1; i < garage.Length; i++)
                {
                    type = "CAR";

                    if (garage[i] == null)
                    {
                        Console.Write("Reg. number: ");
                        regNr = Console.ReadLine();
                        garage[i] = type + "+" + regNr;
                        carCount++;
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
                for (int i = 1; i < garage.Length; i++)
                {
                    type = "MC";

                    if (garage[i] == null)
                    {
                        Console.Write("Reg. number: ");
                        regNr = Console.ReadLine();
                        garage[i] = type + "+" + regNr;
                        Console.Clear();
                        break;
                    }
                    else if (garage[i].Contains('|'))
                    {
                        continue;
                    }
                    else if (garage[i].Contains("MC"))
                    {
                        Console.Write("Reg. number: ");
                        regNr = Console.ReadLine();
                        garage[i] = garage[i] + "|" + type + "+" + regNr;
                        mcCount++;
                        Console.Clear();
                        break;
                    }
                }
            }

            void moveVehicle()
            {
                Console.Clear();
                Console.WriteLine("Enter Reg. number: ");
                string searchReg = Console.ReadLine();

                for (int i = 1; i < garage.Length; i++)
                {
                    //if (garage[i].Contains(searchReg) && garage[i].Contains('|')) //Om det är två motorcyklar
                    //{
                    //    //string.Split(garage[i], '|') //Har inte fått det att funka än

                    //    string tmp = garage[i];
                    //    Console.WriteLine("{0} is on parkingspot: {1}", tmp, i);
                    //    garage[i] = "";
                    //    Console.WriteLine("These spots are available:");
                    //    for (i = 1; i < garage.Length; i++)
                    //    {
                    //        if (garage[i] == null)
                    //        {
                    //            Console.WriteLine("{0}, \n", i);
                    //        }
                    //    }
                    //    Console.WriteLine("Where do you want to move?");
                    //    int choice = int.Parse(Console.ReadLine());
                    //    for (i = 0; i < garage.Length; i++)
                    //    {
                    //        if (garage[choice] == null)
                    //        {
                    //            garage[choice] = tmp;
                    //            break;
                    //        }
                    //    }
                    //    break;
                    //}
                    /*else*/ if (garage[i].Contains(searchReg)) //Om det bara är ett regnummer på platsen
                    {
                        string tmp = garage[i];
                        Console.WriteLine("{0} is on parkingspot: {1}", tmp, i);
                        garage[i] = "";
                        Console.WriteLine("These spots are available:");
                        for (i = 1; i < garage.Length; i++)
                        {
                            if (garage[i] == null)
                            {
                                Console.Write("{0}, ", i);
                            }
                        }
                        Console.WriteLine("\nWhere do you want to move?");
                        int choice = int.Parse(Console.ReadLine());
                        for (i = 0; i < garage.Length; i++)
                        {
                            if (garage[choice] == null)
                            {
                                garage[choice] = tmp;
                                break;
                            }
                        }
                        break;
                    }
                }

            }

            void removeVehicle()
            {
                Console.Clear();
                Console.WriteLine("Enter Reg. number: ");
                string searchReg = Console.ReadLine();

                for (int i = 1; i < garage.Length; i++)
                {
                    if (garage[i].Contains(searchReg))
                    {
                        Console.WriteLine("\n\nWould you like to remove {0} Y/N?", garage[i]);
                        string choice = Console.ReadLine().ToUpper();
                        if (choice == "Y")
                        {
                            garage[i] = "";
                            break;
                        }
                        else if (choice == "N")
                        {
                            Console.Clear();
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0} doesn't exist", searchReg);
                    }
                }
            }
        }
    }
}