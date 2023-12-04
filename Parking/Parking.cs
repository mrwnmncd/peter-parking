using System;
using System.Collections.Generic;
public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public Vehicle[] parkingspace { get; set; }
    public int Capacity { get; }

    public ParkingSpace(int capacity = 50)
    {
        this.Capacity = capacity;
        this.parkingspace = new Vehicle[capacity]; ;
    }

    public void ParkVehicle()
    {
        string parkingSlot;
        int slot;
        string plateNumber;
        string? make;
        string? model;
        Vehicle vehicle;

        Console.WriteLine("Park Vehicle");

        Console.Write("Enter vehicle make (manufacturer) [enter to skip]: ");
        make = Console.ReadLine();
        Console.Write("Enter vehicle model [enter to skip]: ");
        model = Console.ReadLine();
        Console.Write("Enter vehicle plate number [required]: ");
        plateNumber = Console.ReadLine()!;
        Console.Write("Enter parking lot [required]: ");
        parkingSlot = Console.ReadLine()!;

        if (string.IsNullOrEmpty(parkingSlot) || string.IsNullOrWhiteSpace(parkingSlot))
            Console.WriteLine("Parking lot is required!");

            // TODO: handle not int input

        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            Console.WriteLine("Plate number is required!");

        slot = int.Parse(parkingSlot) - 1;

        if (slot > this.parkingspace.Length)
        {
            Console.WriteLine($"Parking lot {parkingSlot + 1} is not available.\n");
            {
                SearchNearestFreeParking();
                Console.Write($"Park vehicle there instead? [y/N]: ");
                string choice = Console.ReadLine()!;
                if (choice == "y") ParkVehicle();
            }
            return;
        }

        vehicle = new Vehicle()
        { Make = make, Model = model, PlateNumber = plateNumber };

        if (this.parkingspace[slot] is null || this.parkingspace[slot].PlateNumber == null)
        {
            Console.WriteLine($"Parking lot {parkingSlot + 1} reserved "
            + "for vehicle with plate number \"{vehicle.PlateNumber}\".\n");

            this.parkingspace[slot] = vehicle;
            return;
        }
        else
        {
            Console.WriteLine($"\nParking lot is already taken "
            + "for vehicle with plate number \"{this.parkingspace[slot].PlateNumber}\".");

            {
                SearchNearestFreeParking();
                Console.Write($"Park vehicle there instead? [y/N]: ");
                string choice = Console.ReadLine()!;
                if (choice == "y") ParkVehicle();
            }
        }
    }

    public void RemoveVehicle()
    {

        // TODO: handle missing plate number
        string plateNumber;
        int slot;

        Console.WriteLine("Unpark Vehicle");

        Console.Write("Enter plate number: ");
        plateNumber = Console.ReadLine()!;

        slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        this.parkingspace[slot] = new Vehicle();

        Console.WriteLine($"Vehicle with plate number \"{plateNumber}\" removed from parking {slot}.\n");
    }

    public void ListVehicles()
    {

        Console.WriteLine("Enumerate Parking");

        Console.WriteLine($"\nTotal parking space: {this.parkingspace.Length}");
        Console.WriteLine("Vehicles in parking space:");

        for (int i = 0; i < this.parkingspace.Length; i++)
        {
            if (this.parkingspace[i] is not null && this.parkingspace[i].PlateNumber != null)
                Console.WriteLine($"\tParking slot {i + 1}: {this.parkingspace[i].ToString()}");
        }
    }

    public int SearchNearestFreeParking()
    {
        int availableSlot = Array.IndexOf(this.parkingspace, null) + 1;
        Console.WriteLine($"Nearest parking lot available is lot number {availableSlot}.\n");
        Console.WriteLine();
        return availableSlot;
    }
    public void ExtendParkingSpace()
    {
        int capacity;
        Vehicle[] space;

        Console.WriteLine("Add Parking Lots");

        Console.Write("Enter parking space capacity: ");
        capacity = int.Parse(Console.ReadLine()!);
        Console.WriteLine();

        space = this.parkingspace;
        Array.Resize(ref space, this.parkingspace.Length + capacity);
        this.parkingspace = space;

        Console.WriteLine($"Parking space extended by {capacity} lots. Total of {space.Length} parking lots.");
        Console.WriteLine('\n');
    }
}
public class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? PlateNumber { get; set; }

    public override string ToString()
    {
        return $"{this.PlateNumber} {this.Make} {this.Model}";
    }
}