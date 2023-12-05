using System;
using System.Collections.Generic;
using System.Data;
public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public Vehicle[] parkingspace { get; set; }
    public int Capacity { get; }

    public ParkingSpace(int capacity = 50)
    {
        this.Capacity = capacity;
        this.parkingspace = Vehicle.ListVehicles();
    }

    public void ParkVehicle()
    {
        Console.WriteLine("Park Vehicle");
        string parkingSlot;
        int slot;

        Vehicle vehicle = UserInterface.InputVehicle();

        while (true)
        {
            Console.Write("Enter parking lot [required]: ");
            parkingSlot = Console.ReadLine()!;

            if (string.IsNullOrEmpty(parkingSlot) || string.IsNullOrWhiteSpace(parkingSlot))
            { Console.WriteLine("Parking lot is required!\n"); continue; }

            if (!int.TryParse(parkingSlot, out slot))
            { Console.WriteLine("Parking lot must be a valid number!\n"); continue; }
            break;
        }

        if (slot > this.parkingspace.Length)
        {
            Console.WriteLine($"Parking lot {slot + 1} is not available.\n");
            {
                SearchNearestFreeParking();
                Console.Write($"Park vehicle there instead? [y/N]: ");
                string choice = Console.ReadLine()!;
                if (choice == "y") ParkVehicle();
            }
            return;
        }

        vehicle = new Vehicle()
        { Make = vehicle.Make, Model = vehicle.Model, PlateNumber = vehicle.PlateNumber! };
        vehicle.SaveToFile();

        if (this.parkingspace[slot] is null || this.parkingspace[slot].PlateNumber == null)
        {
            Console.WriteLine($"Parking lot {parkingSlot + 1} reserved "
            + $"for vehicle with plate number \"{vehicle.PlateNumber!}\".\n");

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
        string plateNumber;
        int slot;
        Vehicle? vehicle;

        Console.WriteLine("Unpark Vehicle");

        Console.Write("Enter plate number: ");
        plateNumber = Console.ReadLine()!;

        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            Console.WriteLine("Plate number is required!");

        vehicle = SearchVehicle();
        if (vehicle is null) return;

        slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        this.parkingspace[slot] = new Vehicle();

        Console.WriteLine($"Vehicle with plate number \"{plateNumber}\" removed from parking {slot}.\n");
    }

    public void UpdateParkingDetails()
    {
        string plateNumber;
        int slot;
        string vehicleString;
        Vehicle vehicle;

        Console.WriteLine("Update Parking Details");

        plateNumber = UserInterface.InputPlateNumber();
        vehicle = UserInterface.InputVehicle();

        slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        vehicle = this.parkingspace[slot];

        Console.WriteLine($"Parking details for vehicle with plate number \"{plateNumber}\":");
        vehicleString = $"Make: {vehicle.Make} " +
            $"Model: {vehicle.Model} " +
            $"Plate Number: {vehicle.PlateNumber}";
        Console.WriteLine(vehicleString);
        Console.WriteLine();


        vehicle.Make = UserInterface.InputMake();
        vehicle.Model = UserInterface.InputModel();

        Console.WriteLine("Enter vehicle plate number [enter to skip]: ");
        plateNumber = Console.ReadLine()!;

        if (!string.IsNullOrEmpty(plateNumber) || !string.IsNullOrWhiteSpace(plateNumber))
            vehicle.PlateNumber = plateNumber;


        Console.WriteLine($"Parking details updated for vehicle with plate number \"{plateNumber}\".\n");
    }

    public void ListVehicles()
    {

        Console.WriteLine("Enumerate Occupied Parking");

        Console.WriteLine($"\nTotal parking space: {this.parkingspace.Length}");
        Console.WriteLine("Vehicles in parking space:");

        for (int i = 0; i < this.parkingspace.Length; i++)
        {
            if (this.parkingspace[i] is not null && this.parkingspace[i].PlateNumber != null)
                Console.WriteLine($"\tParking slot {i + 1}: {this.parkingspace[i].ToString()}");
        }
        Console.WriteLine('\n');
    }

    public Vehicle? SearchVehicle()
    {
        Vehicle vehicle = new Vehicle();
        int slot;
        string plateNumber;

        Console.Write("Enter plate number: ");
        plateNumber = Console.ReadLine()!;

        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            Console.WriteLine("Plate number is required!");

        if (!Array.Exists(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber))
        {
            Console.WriteLine($"No parking match found for vehicle with plate number \"{plateNumber}\".\n");
            return null;
        }

        slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        vehicle = this.parkingspace[slot];

        return vehicle;
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
        string inputCapacity;
        int capacity;

        Vehicle[] space;

        Console.WriteLine("Add Parking Lots");

        Console.Write("Enter parking space capacity: ");

        inputCapacity = Console.ReadLine()!;
        if (!int.TryParse(inputCapacity, out capacity))
        {
            Console.WriteLine("Parking space capacity must be a valid number!\n");
            return;
        };
        Console.WriteLine();

        space = this.parkingspace;
        Array.Resize(ref space, this.parkingspace.Length + capacity);
        this.parkingspace = space;

        Console.WriteLine($"Parking space extended by {capacity} lots. Total of {space.Length} parking lots.");
        Console.WriteLine('\n');
    }
}


