public class Vehicle
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? PlateNumber { get; set; }

    public override string ToString()
    {
        return $"{this.PlateNumber} {this.Make} {this.Model}";
    }

    public string ToFormattedString()
    {
        return $"{this.PlateNumber} | {this.Make} | {this.Model}";
    }

    public string ToStructuredString()
    {
        return $"Make: {this.Make} | " +
      $"Model: {this.Model} | " +
      $"Plate Number: {this.PlateNumber}";
    }

    public void RemoveFromFile(Vehicle? vehicle = null)
    {
        if (vehicle is null) vehicle = this;
        string PlateNumber = vehicle.PlateNumber!;
        VehicleFS.RemoveFromFile(PlateNumber);
    }


}

class VehicleFS
{

    public static Vehicle[] CreateVehicleInstance()
    {
        Vehicle[] vehicle;

        if (FileManager.CheckFileExists(Environment.ParkingSpacePath))
            return EnumerateParkedVehicles()!;


        FileManager.CreateFile(Environment.ParkingSpacePath);
        vehicle = new Vehicle[Environment.InitialCapacity];
        Console.WriteLine(Environment.InitialCapacity);
        for (int i = 1; i < Environment.InitialCapacity; i++)
        {
            FileManager.AppendToFile(Environment.ParkingSpacePath, "");
        }
        return vehicle;
    }

    public static void WriteToFile(string? Make, string? Model, string? PlateNumber, int ParkingSlot)
    {
        string data;

        if (Make is null) Make = "";
        if (Model is null) Model = "";
        if (PlateNumber is null) PlateNumber = "";

        ParkingSlot -= 1;

        data = $"{PlateNumber} | {Make} | {Model}";
        FileManager.WriteToFile(Environment.ParkingSpacePath, data, ParkingSlot);
    }

    public static void RemoveFromFile(string PlateNumber)
    {
        string[] lines;
        string[] data;
        string plateNumber;
        string Make;
        string Model;
        string[] newLines;
        string newLine;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);
        newLines = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            newLines[i] = lines[i];
        }

        for (int i = 0; i < lines.Length; i++)
        {
            data = lines[i].Split('|');
            if (string.IsNullOrEmpty(data[0]) || string.IsNullOrWhiteSpace(data[0])) continue;
            plateNumber = data[0].Trim();
            Make = data[1].Trim();
            Model = data[2].Trim();
            if (plateNumber == PlateNumber)
            {
                newLine = "";
                newLines[i] = newLine;
            }
        }
        FileManager.OverwriteToFile(Environment.ParkingSpacePath, newLines);
    }

    public static Vehicle? SearchVehicle(string PlateNumber)
    {
        string[] lines;
        string[] data;
        string plateNumber;
        string Make;
        string Model;
        int ParkingSlot;
        Vehicle vehicle;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);

        foreach (string line in lines)
        {
            data = line.Split('|');

            if (string.IsNullOrEmpty(data[0]) || string.IsNullOrWhiteSpace(data[0]))
                continue;

            ParkingSlot = Array.IndexOf(lines, line);
            plateNumber = data[0].Trim();
            Make = data[1].Trim();
            Model = data[2].Trim();
            if (plateNumber == PlateNumber)
            {
                vehicle = new Vehicle()
                { Make = Make, Model = Model, PlateNumber = PlateNumber };
                return vehicle;
            }
        }
        return null;
    }

    public static Vehicle? UpdateVehicle(string PlateNumber, string? newPlateNumber = null, string? Make = null, string? Model = null)
    {
        string[] lines;
        string[] data;
        string plateNumber;
        string make;
        string model;
        int ParkingSlot;
        Vehicle vehicle;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);

        foreach (string line in lines)
        {
            data = line.Split('|');
            if (string.IsNullOrEmpty(data[0]) || string.IsNullOrWhiteSpace(data[0])) continue;
            ParkingSlot = Array.IndexOf(lines, line);
            plateNumber = data[0].Trim();
            make = data[1].Trim();
            model = data[2].Trim();
            if (plateNumber == PlateNumber)
            {
                if (Make is not null) make = Make;
                if (Model is not null) model = Model;
                if (newPlateNumber is not null) PlateNumber = newPlateNumber;

                vehicle = new Vehicle()
                { Make = make, Model = model, PlateNumber = PlateNumber };
                FileManager.WriteToFile(Environment.ParkingSpacePath,
                vehicle.ToFormattedString(), ParkingSlot);
                return vehicle;
            }
        }
        return null;
    }

    public static bool CheckIfParkingLotIsAvailable(int ParkingSlot)
    {
        string[] lines;
        string[] data;
        string plateNumber;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);

        data = lines[ParkingSlot - 1].Split('|');
        plateNumber = data[0].Trim();

        if (string.IsNullOrEmpty(plateNumber) || string.IsNullOrWhiteSpace(plateNumber))
            return true;
        return false;
    }

    public static Vehicle[] EnumerateParkedVehicles()
    {
        Vehicle[] vehicles;
        string[]? lines;

        string[] data;
        int ParkingSlot;
        string PlateNumber;
        string Make;
        string Model;
        Vehicle vehicle;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);

        if (lines is null) return CreateVehicleInstance()!;

        vehicles = new Vehicle[lines.Length];

        foreach (string line in lines)
        {
            data = line.Split('|');
            if (string.IsNullOrEmpty(data[0]) || string.IsNullOrWhiteSpace(data[0])) continue;
            ParkingSlot = Array.IndexOf(lines, line);
            PlateNumber = data[0].Trim();
            Make = data[1].Trim();
            Model = data[2].Trim();
            vehicle = new Vehicle()
            { Make = Make, Model = Model, PlateNumber = PlateNumber };
            vehicles[ParkingSlot] = vehicle;
        }
        return vehicles;
    }

    public static int? SearchEmptySlot()
    {
        string[]? lines;

        string[] data;

        lines = FileManager.ReadFromFile(Environment.ParkingSpacePath);

        foreach (string line in lines)
        {
            data = line.Split('|');
            if (string.IsNullOrEmpty(data[0]) || string.IsNullOrWhiteSpace(data[0]))
                return Array.IndexOf(lines, data[0]);
         }
        return null;
    }

    public static int ExtendParkingLots(int newCapacity)
    {
        for (int i = 0; i < newCapacity; i++)
        {
            FileManager.AppendToFile(Environment.ParkingSpacePath, "");
        }
        return FileManager.ReadFromFile(Environment.ParkingSpacePath).Length;
    }

}