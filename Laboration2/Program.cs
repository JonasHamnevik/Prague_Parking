using System;

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
                    if (garage[i] == null)
                    {
                        Console.WriteLine("Reg. number: ");
                        string regNr = Console.ReadLine();
                        string type = "Car";
                        garage[i] = type + ", " + regNr;
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
                for (int i = 0; i < garage.Length; i++)
                {
                    Console.WriteLine("Reg. number: ");
                    string regNr = Console.ReadLine();
                    string type = "MC";
                    garage[i] = type + ", " + regNr;
                    break;
                }

            }

            static void moveVehicle()
            {
                throw new NotImplementedException();
            }

            static void search()
            {
                throw new NotImplementedException();
            }

            static void removeVehicle()
            {
                throw new NotImplementedException();
            }

        }
    }
}
