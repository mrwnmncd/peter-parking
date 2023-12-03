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

            ParkingSpace parking = new ParkingSpace();
            (string? make, string? model, string plateNumber) car = Vehicle.PromptUser();
            parking.ParkVehicle(car.make, car.model, car.plateNumber);
            parking.ListVehicles();
        }

        static void MainMenu()
        {
            Console.WriteLine(Environment.name);

            Console.WriteLine("1. Login User");
            Console.WriteLine("2. Exit Application");

            while (true)
            {
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine()!;
                int option = int.Parse(choice);
                Console.WriteLine(option); // TODO: remove console log


                if (option == 1)
                {
                    (bool isAuthenticated, string username, string password) auth = Authenticator.AuthenticateUser();
                    Console.WriteLine($"Greetings, {auth.username}!");
                    if (auth.isAuthenticated == true) break;
                }
                else if (option == 2)
                {
                    System.Environment.Exit(0);
                    // TODO: print a goodbye message
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }
            }
        }
    }
}