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
                Console.WriteLine("c. Update Parking Details");
                Console.WriteLine("d. Remove Parking Assignment");
                Console.WriteLine("e. Show Parking Space");
                Console.WriteLine("f. Search Vehicle [UNFINISHED]");
                Console.WriteLine("g. Find Nearest Available Parking");
                Console.WriteLine("h. Exit Application");

                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()!;
                choice = choice.ToLower();

                Console.WriteLine('\n');
                if (choice == "a") { parking.ExtendParkingSpace(); continue; }
                if (choice == "b") { parking.ParkVehicle(); continue; }
                if (choice == "c") { parking.UpdateParkingDetails(); continue; }
                if (choice == "d") { parking.RemoveVehicle(); continue; }
                if (choice == "e") { parking.ListVehicles(); continue; }
                if (choice == "f") { continue; }
                if (choice == "g") { parking.SearchNearestFreeParking(); continue; }
                if (choice == "h") { Console.WriteLine('\n' + "Goodbye!"); break; }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("Select from optiona A to H only!");
                    Console.WriteLine('\n');
                    continue;
                }
            }
            Console.WriteLine('\n' + "Goodbye!");
            System.Environment.Exit(0);
        }
    }
}