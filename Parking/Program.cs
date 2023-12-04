using System;
using System.Collections.Generic;

namespace PeterParking
{
    class Program
    {

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            ParkingSpace parking = new ParkingSpace();

            while (true)
            {
                Console.WriteLine(Environment.name + '\n');
                Console.WriteLine("a. Add Parking Lot");
                Console.WriteLine("b. Assign Parking Lot");
                Console.WriteLine("c. Remove Parking Assignment");
                Console.WriteLine("d. Show Parking Space");
                Console.WriteLine("e. Find Nearest Parking Lot");
                Console.WriteLine("f. Exit Application");

                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()!;
                choice = choice.ToLower();

                Console.WriteLine('\n');
                // TODO: car type
                // TODO: update parking deetsd
                if (choice == "a") { parking.ExtendParkingSpace(); continue; }
                if (choice == "b") { parking.ParkVehicle(); continue; }
                if (choice == "c") { parking.RemoveVehicle(); continue; }
                if (choice == "d") { parking.ListVehicles(); continue; }
                if (choice == "e") { parking.SearchNearestFreeParking(); continue; }
                if (choice == "f") { Console.WriteLine('\n' + "Goodbye!"); break; }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("Select from optiona A to E only!");
                    Console.WriteLine('\n');
                    continue;
                }
            }
            Console.WriteLine('\n' + "Goodbye!");
            System.Environment.Exit(0);
        }
    }
}