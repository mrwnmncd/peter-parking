using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gw = 0, gg;
            string[] carname = new string[gw];
            string input;

            Console.WriteLine("~~~~~~~~~~~~~~~~");
            Console.WriteLine("Peter Parking");
            Console.WriteLine("~~~~~~~~~~~~~~~~");

            do
            {
                Console.WriteLine("Parking Slot or Space Reservation");
                Console.WriteLine("a. Add b. Assign c. Show slots d. Remove e. Exit");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                        gw++;
                        Console.WriteLine("Parking Slot # " + gw);
                        Array.Resize(ref carname, gw);
                        break;

                    case "b":
                        Console.WriteLine("Choose Slot 1-" + gw);
                        gg = Convert.ToInt32(Console.ReadLine());
                        if (gg >= 1 && gg <= gw)
                        {
                            Console.WriteLine("You chose # " + gg);
                            Console.WriteLine("Input Plate# to slot # " + gg);
                            carname[gg - 1] = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number/slot already taken");
                        }
                        break;

                    case "c":
                        Console.WriteLine("Show Slots:");
                        for (int i = 0; i < gw; i++)
                        {
                            if (carname[i] != "")
                            {
                                Console.WriteLine("Slot # " + (i + 1) +" " + carname[i]);
                            }
                            else
                            {
                                Console.WriteLine("Slot # " + (i + 1) );
                            }
                        }
                        break;

                    case "d":
                        Console.WriteLine("Choose Slot 1-" + gw);
                        int slotToRemove = Convert.ToInt32(Console.ReadLine());
                        if (slotToRemove >= 1 && slotToRemove <= gw)
                        {
                            Console.WriteLine("Removing car from Slot # " + slotToRemove);
                            carname[slotToRemove - 1] = "";
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number.");
                        }
                        break;

                    case "e":
                        Console.WriteLine("Exiting the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (input != "e");

            Console.ReadKey();
        }
    }
}

