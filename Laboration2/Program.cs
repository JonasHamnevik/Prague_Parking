using System;
using System.Collections.Generic;

namespace Laboration2
{
    class Program
    {
        static string[] garage = new string[101]; //Ska börja på 1 och sluta på 100 när det hanteras och när det skrivs ut.
        static int vehicleCount = 0;
        static char type;
        static string regNr;
        const int maxReg = 10; //Max antal symboler i regnumret

        static void Initialize()
        {
            for (int i = 1; i < garage.Length; i++)
            {
                garage[i] = "";
            }
        }
        static void Main(string[] args)
        {
            Initialize();
            int parkingSpot;
            string searchReg;
            bool exit = false;
            while (exit != true)
            {

                Console.WriteLine("Main Menu");
                Console.WriteLine("1 - Add Car");
                Console.WriteLine("2 - Add MC");
                Console.WriteLine("3 - Show garage");
                Console.WriteLine("4 - Search");
                Console.WriteLine("5 - Move vehicle");
                Console.WriteLine("6 - Remove vehicle");
                Console.WriteLine("0 - Exit");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1": //Lägga till bil
                        if (vehicleCount == garage.Length - 1)
                        {
                            Console.WriteLine("Garage is full!");
                        }
                        else
                        {
                            AddCar();
                        }
                        break;

                    case "2": //Lägga till MC
                        if (vehicleCount == garage.Length - 1)
                        {
                            Console.WriteLine("Garage is full!");
                        }
                        else
                        {
                            AddMc();
                        }
                        break;

                    case "3": //Visa garaget
                        Console.Clear();
                        for (int i = 1; i < garage.Length; i++)
                        {
                            Console.WriteLine("Parkingspot - {0} {1}", i, garage[i]);
                        }
                        break;

                    case "4": //Söka efter fordon
                        Console.Clear();
                        Console.WriteLine("Enter Reg. number: ");
                        searchReg = Console.ReadLine();
                        if (Search(searchReg, out parkingSpot))
                        {
                            Console.WriteLine("\n\n{0} is on parkingspot: {1}\n", garage[parkingSpot], parkingSpot);
                        }
                        else
                        {
                            Console.WriteLine("{0} is not in the garage", searchReg);
                        }
                        break;

                    case "5": //flytta fordon
                        Console.WriteLine("Enter Reg. number: ");
                        searchReg = Console.ReadLine();
                        MoveVehicle(searchReg);
                        break;

                    case "6": //Ta bort fordon
                        Console.WriteLine("Enter Reg. number: ");
                        searchReg = Console.ReadLine();
                        RemoveVehicle(searchReg);
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Enter a command!");
                        break;
                }
            }
        }
        public static void AddCar()
        {
            for (int i = 1; i < garage.Length; i++)
            {
                type = 'C';

                if (garage[i] == "")
                {
                    Console.Write("Reg. number: ");
                    regNr = Console.ReadLine();

                    if (regNr.Length > maxReg)
                    {
                        Console.WriteLine("The reg. number is to long.");
                        break;
                    }
                    else
                    {
                        garage[i] = type + "+" + regNr;
                        vehicleCount++;
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        public static void AddMc()
        {
            for (int i = 1; i < garage.Length; i++)
            {
                type = 'M';

                if (garage[i] == "")
                {
                    Console.Write("Reg. number: ");
                    regNr = Console.ReadLine();

                    if (regNr.Length > maxReg)
                    {
                        Console.WriteLine("The reg. number is to long.");
                        break;
                    }
                    else
                    {
                        garage[i] = type + "+" + regNr;
                        Console.Clear();
                        break;
                    }
                }
                else if (garage[i].Contains('|'))
                {
                    continue;
                }
                else if (garage[i].Contains("M+"))
                {
                    Console.Write("Reg. number: ");
                    regNr = Console.ReadLine();
                    garage[i] = garage[i] + "|" + type + "+" + regNr;
                    vehicleCount++;
                    Console.Clear();
                    break;
                }
            }
        }
        public static void MoveVehicle(string searchReg)
        {
            Console.Clear();
            int spotNumber;
            Console.WriteLine("These spots are available:");
            for (int i = 1; i < garage.Length; i++)
            {
                if (garage[i] == "" || garage[i].StartsWith("M"))
                {
                    Console.Write("{0}, ", i);
                }
            }

            if (Search(searchReg, out spotNumber))
            {
                Console.WriteLine("\n\n{0} is on parkingspot: {1}\n", searchReg, spotNumber);

                Console.WriteLine("\nWhere do you want to move?");
                int choice = int.Parse(Console.ReadLine());
                if (garage[spotNumber].Contains("|") && garage[spotNumber].StartsWith("M+"))
                {
                    string mc = "M+" + searchReg;
                    string pSpot = garage[spotNumber];
                    string[] mcs = pSpot.Split('|');
                    for (int i = 0; i < mcs.Length; i++)
                    {
                        if (mcs[i] == mc)
                        {
                            if (garage[choice] == "")
                            {
                                garage[choice] = mc;
                                mcs[i] = "";
                            }
                            else if (garage[choice].StartsWith("M+"))
                            {
                                garage[choice] = garage[choice] + "|" + mc;
                                mcs[i] = "";
                            }
                        }
                    }
                    pSpot = mcs[0] + mcs[1];
                    garage[spotNumber] = pSpot;
                }

                else if (garage[choice] == "")
                {
                    for (int i = 1; i < garage.Length; i++)
                    {
                        garage[choice] = garage[spotNumber];
                        garage[spotNumber] = "";
                    }
                }
                else
                {
                    Console.WriteLine("The spot is not available");
                    return;
                }
            }
        }

        public static bool Search(string searchReg, out int spotNumber)
        {
            for (int i = 1; i < garage.Length; i++)
            {
                if (garage[i].Contains(searchReg))
                {
                    spotNumber = i;
                    return true;
                }
            }
            spotNumber = -1;
            return false;
        }

        public static void RemoveVehicle(string searchReg)
        {
            Console.Clear();
            int spotNumber;
            if (Search(searchReg, out spotNumber))
            {
                Console.WriteLine("{0} is on parkingspot {1}\n", searchReg, spotNumber);
                Console.WriteLine("Do you want to remove {0} Y/N", searchReg);
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    if (garage[spotNumber].StartsWith("C+"))
                    {
                        garage[spotNumber] = "";
                    }
                    else if (garage[spotNumber].StartsWith("M+"))
                    {
                        if (garage[spotNumber].Contains("|"))
                        {
                            string mc = "M+" + searchReg;
                            string pSpot = garage[spotNumber];
                            string[] mcs = pSpot.Split('|');
                            for (int i = 0; i < mcs.Length; i++)
                            {
                                if (mcs[i] == mc)
                                {
                                    mcs[i] = "";
                                }
                            }
                            pSpot = mcs[0] + mcs[1];
                            garage[spotNumber] = pSpot;
                        }
                        else
                        {
                            garage[spotNumber] = "";
                        }
                    }
                }
                else if (choice == "N")
                {
                    return;
                }
            }
        }
    }
}