using System;

namespace Laboration2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parkings = new string[10];

            for (int i = 1; i < parkings.Length +1; i++)
            {
                Console.WriteLine("{0} ", i);
            }

            Menu();
        }
        static void Menu()
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
        }

        private static void addCar()
        {
            throw new NotImplementedException();
        }

        private static void addMc()
        {
            throw new NotImplementedException();
        }

        private static void moveVehicle()
        {
            throw new NotImplementedException();
        }

        private static void search()
        {
            throw new NotImplementedException();
        }

        private static void removeVehicle()
        {
            throw new NotImplementedException();
        }
    }
}
