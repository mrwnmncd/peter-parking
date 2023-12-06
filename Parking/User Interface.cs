using System.Text.RegularExpressions;

class UserInterface
{
    public static string InputPlateNumber()
    {
        string plateNumber;
        string pattern;
        bool isValid;

        while (true)
        {
            Console.Write("Enter plate number: ");
            plateNumber = Console.ReadLine()!;

            if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            { Console.WriteLine("Plate number is required!"); continue; }

            plateNumber = plateNumber.ToUpper();

            pattern = @"^[a-zA-Z0-9 ]{8}$";

            isValid = Regex.IsMatch(plateNumber, pattern);

            if (!isValid)
            { Console.WriteLine($"Plate number must be {Environment.PlateNumberCharacters} characters long and alphanumeric!"); continue; }

            break;
        }

        return plateNumber;
    }

    public static string? InputMake()
    {
        string? make;

        Console.Write("Enter vehicle make (manufacturer) [enter to skip]: ");
        make = Console.ReadLine();

        return make;
    }

    public static string? InputModel()
    {
        string? model;

        Console.Write("Enter vehicle model [enter to skip]: ");
        model = Console.ReadLine();

        return model;
    }

    public static Vehicle InputVehicle()
    {
        string plateNumber;
        string? make;
        string? model;
        Vehicle vehicle;

        plateNumber = InputPlateNumber();
        make = InputMake();
        model = InputModel();

        vehicle = new Vehicle()
        { Make = make, Model = model, PlateNumber = plateNumber };

        return vehicle;
    }

    public static int? InputParkingLotNumber()
    {
        string parkingSlot;
        int slot;

        Console.Write("Enter parking lot [required]: ");
        parkingSlot = Console.ReadLine()!;

        if (string.IsNullOrEmpty(parkingSlot) || string.IsNullOrWhiteSpace(parkingSlot))
            Console.WriteLine("Parking lot is required!\n");

        if (!int.TryParse(parkingSlot, out slot))
        {
            Console.WriteLine("Parking lot must be a valid number!\n");
            return null;
        }

        return slot;
    }
}