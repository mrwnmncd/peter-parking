public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public List<Vehicle> space { get; set; }

    public ParkingSpace()
    {
        List<Vehicle> parkspace = new List<Vehicle>();
        this.space = parkspace;
    }

    public ParkingSpace ParkVehicle(string? make, string? model, string plateNumber)
    {
        this.PlateNumber = plateNumber;
        Vehicle vehicle = new Vehicle();
        vehicle.Make = make;
        vehicle.Model = model;
        vehicle.PlateNumber = plateNumber;
        this.space.Add(vehicle);
        return this;
    }

    public ParkingSpace? UnparkVehicle(string plateNumber)
    {
        this.PlateNumber = plateNumber;
        Vehicle? car = this.space.Find(x => x.PlateNumber == plateNumber);
        if (car is null) {
            Console.WriteLine("Vehicle not found!"); return null;
        }
        else this.space.Remove(car);
        return this;
    }

    public void ListVehicles()
    {
        Console.WriteLine("Vehicles in parking space:"); // TODO: remove console log
        foreach (var vehicle in this.space)
        {
            Console.WriteLine($"{vehicle.PlateNumber} {vehicle.Make} {vehicle.Model}");
        }
    }

    public void ListVehicles(string plateNumber)
    {
        Console.WriteLine("Vehicles in parking space:");
        foreach (var vehicle in this.space)
        {
            if (vehicle.PlateNumber == plateNumber)
                Console.WriteLine(vehicle);
        }
    }
}
public class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? PlateNumber { get; set; }

    public static (string? make, string? model, string plateNumber) PromptUser()
    {
        Console.Write("Enter vehicle make (manufacturer) [enter to skip]: ");
        string? make = Console.ReadLine();
        Console.Write("Enter vehicle model [enter to skip]: ");
        string? model = Console.ReadLine();
        Console.Write("Enter vehicle plate number [required]: ");
        string plateNumber = Console.ReadLine()!;
        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
        {
            Console.WriteLine("Plate number is required!"); // TODO: remove console log
            // TODO: handle null
            // TODO: loop until valid input
        }
        return (make, model, plateNumber);
    }
}