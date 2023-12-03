using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
            Console.WriteLine(Environment.name);

            ParkingSpace parking = new ParkingSpace();

            while (true)
            {
                Console.WriteLine("1. Add Parking Space");
                Console.WriteLine("2. Assign Parking Space");
                Console.WriteLine("3. Show Parking Space");
                Console.WriteLine("4. Remove Parking Space");
                Console.WriteLine("5. Exit Application");

                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()!;
                int option = int.Parse(choice);

                Console.WriteLine('\n');
                if (option == 1)
                {
                    Console.Write("Enter parking space capacity: ");
                    int capacity = int.Parse(Console.ReadLine()!);
                    parking.ExtendParkingSpace(capacity);
                    continue;
                }
                else if (option == 2)
                {
                    (string? make, string? model, string plateNumber, int slot) car = Vehicle.PromptUser();
                    parking.ParkVehicle(car.make, car.model, car.plateNumber, car.slot);
                    continue;
                }
                else if (option == 3) parking.ListVehicles();
                else if (option == 4)
                {
                    Console.Write("Enter plate number: ");
                    string plateNumber = Console.ReadLine()!;
                    parking.RemoveVehicle(plateNumber);
                }
                else if (option == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    Console.WriteLine('\n');
                    continue;
                }
            }
            System.Environment.Exit(0);
        }
    }
}