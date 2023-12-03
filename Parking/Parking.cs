using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public Vehicle[] parkingspace { get; set; }
    public int Capacity { get; }

    public ParkingSpace(int capacity = 50)
    {
        this.Capacity = capacity;
        Vehicle[] parkingspace = new Vehicle[capacity];
        this.parkingspace = parkingspace;
    }

    public void ParkVehicle(string? make, string? model, string plateNumber, int parkingSlot)
    {
        parkingSlot -= 1;
        Vehicle vehicle = new Vehicle()
        { Make = make, Model = model, PlateNumber = plateNumber };
        if (this.parkingspace[parkingSlot] is null || this.parkingspace[parkingSlot].PlateNumber == null)
        {
            Console.WriteLine($"Parking slot {parkingSlot + 1} reserved for vehicle with plate number \"{vehicle.PlateNumber}\".\n");
            this.parkingspace[parkingSlot] = vehicle;
        }
        else
        {
            int availableSlot = Array.IndexOf(this.parkingspace, null) + 1;
            Console.WriteLine($"\nParking slot is already taken for vehicle with plate number \"{this.parkingspace[parkingSlot].PlateNumber}\".");
            {
                Console.Write($"Parking slot {availableSlot} is available. Would you like to park there instead? [y/N]: ");
                string choice = Console.ReadLine()!;
                if (choice == "y")
                    ParkVehicle(make, model, plateNumber, availableSlot);
            }
        }
    }

    public void RemoveVehicle(string plateNumber)
    {
        int slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        this.parkingspace[slot] = new Vehicle();
        Console.WriteLine($"Vehicle with plate number \"{plateNumber}\" removed from parking {slot}.\n");
    }

    public void ListVehicles()
    {
        Console.WriteLine($"\nTotal parking space: {this.parkingspace.Length}");
        Console.WriteLine("Vehicles in parking space:"); // TODO: remove console log
        for (int i = 0; i < this.parkingspace.Length; i++)
        {
            if (this.parkingspace[i] is not null && this.parkingspace[i].PlateNumber != null)
                Console.WriteLine($"Parking Slot {i + 1}: {this.parkingspace[i].ToString()}");
        }
    }
    public void ExtendParkingSpace(int capacity)
    {
        Vehicle[] space = this.parkingspace;
        Array.Resize(ref space, this.parkingspace.Length + capacity);
        this.parkingspace = space;
        Console.WriteLine($"Parking space extended by {capacity} slots. Total of {space.Length} slots.");
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

    public static (string? make, string? model, string plateNumber, int slot) PromptUser()
    {
        string parkingSlot;
        int slot;
        string plateNumber;
        string? make;
        string? model;

        Console.Write("Enter vehicle make (manufacturer) [enter to skip]: ");
        make = Console.ReadLine();
        Console.Write("Enter vehicle model [enter to skip]: ");
        model = Console.ReadLine();
        Console.Write("Enter vehicle plate number [required]: ");
        plateNumber = Console.ReadLine()!;
        Console.Write("Enter parking slot [required]: ");
        parkingSlot = Console.ReadLine()!;

        if (string.IsNullOrEmpty(parkingSlot) || string.IsNullOrWhiteSpace(parkingSlot))
            Console.WriteLine("Parking slot is required!");

        slot = int.Parse(parkingSlot);

        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            Console.WriteLine("Plate number is required!");

        return (make, model, plateNumber, slot);
    }
}