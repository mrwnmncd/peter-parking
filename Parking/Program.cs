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
            ParkingSpace parking;

            parking = new ParkingSpace();

            while (true)
            {
                Console.WriteLine(ProgramVariables.name + '\n');
                Console.WriteLine("a. Add Parking Lot");
                Console.WriteLine("b. Assign Parking Lot");
                Console.WriteLine("c. Update Parking Details");
                Console.WriteLine("d. Remove Parking Assignment");
                Console.WriteLine("e. Show Parking Space");
                Console.WriteLine("f. Search Vehicle");
                Console.WriteLine("g. Find Nearest Available Parking");
                Console.WriteLine("h. Exit Application");

                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()!;
                choice = choice.ToLower();

                Console.WriteLine('\n');
                if (choice == "a") { parking.ExtendParkingSpace(); }
                else if (choice == "b") { parking.ParkVehicle(); }
                else if (choice == "c") { parking.UpdateParkingDetails(); }
                else if (choice == "d") { parking.RemoveVehicle(); }
                else if (choice == "e") { parking.ListVehicles(); }
                else if (choice == "f") { parking.SearchVehicle(); }
                else if (choice == "g") { parking.SearchNearestFreeParking(); }
                else if (choice == "h") { Console.WriteLine('\n' + "Goodbye!"); break; }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine("Select from options A to H only!");
                    Console.WriteLine('\n');
                }
                continue;

            }
            System.Environment.Exit(0);
        }
    }
}