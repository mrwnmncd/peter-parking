using System.Text.RegularExpressions;
public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public Vehicle[] parkingspace { get; set; }
    public int Capacity { get; }

    public ParkingSpace(int capacity = 0)
    {
        if (capacity == 0) capacity = ProgramVariables.InitialCapacity;
        this.Capacity = capacity;
        this.parkingspace = VehicleFS.CreateVehicleInstance();
    }

    public void ParkVehicle(Vehicle? vehicle = null)
    {
        Console.WriteLine("Park Vehicle");
        string parkingSlot;
        int slot;

        if (vehicle is null) vehicle = UserInterface.InputVehicle();

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
                if (choice == "y") ParkVehicle(vehicle);
            }
            return;
        }

        if (VehicleFS.CheckIfParkingLotIsAvailable(slot))
        {
            VehicleFS.WriteToFile(vehicle.Make!, vehicle.Model!, vehicle.PlateNumber!, slot);
            Console.WriteLine($"Parking lot {parkingSlot} reserved "
            + $"for vehicle with plate number \"{vehicle.PlateNumber!}\".\n");
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

        vehicle = SearchVehicle(plateNumber);
        if (vehicle is null) return;

        slot = Array.FindIndex(this.parkingspace, vehicle => vehicle.PlateNumber == plateNumber);
        VehicleFS.RemoveFromFile(vehicle.PlateNumber!);

        Console.WriteLine($"Vehicle with plate number \"{plateNumber}\" removed from parking {slot + 1}.\n");
    }

    public void UpdateParkingDetails()
    {
        string plateNumber;
        string newPlateNumber;
        string? inputMake;
        string? inputModel;
        Vehicle vehicle;

        Console.WriteLine("Update Parking Details");

        plateNumber = UserInterface.InputPlateNumber();

        vehicle = SearchVehicle(plateNumber)!;

        if (vehicle is null) return;

        Console.WriteLine($"Parking details for vehicle with plate number \"{plateNumber}\":");
        Console.WriteLine(vehicle.ToStructuredString());
        Console.WriteLine();

        inputMake = UserInterface.InputMake();
        inputModel = UserInterface.InputModel();
        Console.Write("Enter new vehicle plate number [enter to skip]: ");
        newPlateNumber = Console.ReadLine()!;

        if (!string.IsNullOrEmpty(inputMake) || !string.IsNullOrWhiteSpace(inputMake))
            vehicle.Make = inputMake;

        if (!string.IsNullOrEmpty(inputModel) || !string.IsNullOrWhiteSpace(inputModel))
            vehicle.Model = inputModel;

        if (!string.IsNullOrEmpty(newPlateNumber) || !string.IsNullOrWhiteSpace(newPlateNumber))
            vehicle.PlateNumber = newPlateNumber;

        vehicle = VehicleFS.UpdateVehicle(plateNumber, vehicle.PlateNumber, vehicle.Make, vehicle.Model)!;


        Console.WriteLine($"Parking details updated for vehicle with plate number \"{vehicle.PlateNumber}\".\n");
    }

    public void ListVehicles()
    {

        Console.WriteLine("Enumerate Occupied Parking");

        this.parkingspace = VehicleFS.EnumerateParkedVehicles();

        Console.WriteLine($"\nTotal parking space: {this.parkingspace.Length + 1}");
        if (this.parkingspace.Length == 0) return;

        // Console.WriteLine("Vehicles in parking space:");

        for (int i = 0; i < this.parkingspace.Length; i++)
        {
            if (this.parkingspace[i] is not null && this.parkingspace[i].PlateNumber != null)
                Console.WriteLine($"\tParking slot {i + 1}: {this.parkingspace[i].ToString()}");
        }
        Console.WriteLine('\n');
    }

    public Vehicle? SearchVehicle(string? PlateNumber = null)
    {
        Vehicle vehicle;
        string pattern;
        bool isValid;

        Console.WriteLine("Search Vehicle");

        if (PlateNumber is null)
        {
            Console.Write("Enter plate number: ");
            PlateNumber = Console.ReadLine()!;

            if (string.IsNullOrEmpty(PlateNumber) || string.IsNullOrWhiteSpace(PlateNumber))
            { Console.WriteLine("Plate number is required!"); return null; }

            pattern = @"^[a-zA-Z0-9 ]{8}$";

            isValid = Regex.IsMatch(PlateNumber, pattern);

            if (!isValid)
            { Console.WriteLine($"Plate number must be {ProgramVariables.PlateNumberCharacters} characters long and alphanumeric!"); return null; }

            PlateNumber = PlateNumber.ToUpper();

        }

        vehicle = VehicleFS.SearchVehicle(PlateNumber)!;

        if (vehicle is null)
        {
            Console.WriteLine($"No parking match found for vehicle with plate number \"{PlateNumber}\".\n");
            return null;
        }

        Console.WriteLine($"Parking details for vehicle with plate number \"{PlateNumber}\":");
        Console.WriteLine(vehicle.ToStructuredString());
        Console.WriteLine('\n');

        return vehicle;
    }

    public void SearchNearestFreeParking()
    {
        Console.WriteLine("Search Nearest Free Parking");

        int? emptySlot = VehicleFS.SearchEmptySlot();

        if (emptySlot is null)
        {
            Console.WriteLine("No available parking slots.\n");
            return;
        }

        Console.WriteLine($"Nearest parking lot available is lot number {emptySlot + 1}.\n");
        Console.WriteLine();
    }
    public void ExtendParkingSpace()
    {
        string inputCapacity;
        int capacity;

        int spaces;

        Console.WriteLine("Add Parking Lots");

        Console.Write("Enter parking space capacity: ");

        inputCapacity = Console.ReadLine()!;
        if (!int.TryParse(inputCapacity, out capacity))
        {
            Console.WriteLine("Parking space capacity must be a valid number!\n");
            return;
        };
        Console.WriteLine();

        spaces = VehicleFS.ExtendParkingLots(capacity);

        Console.WriteLine($"Parking space extended by {capacity} lots. Total of {spaces} parking lots.");
        Console.WriteLine('\n');
    }
}


