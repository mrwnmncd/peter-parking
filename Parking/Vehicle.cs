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

    public void SaveToFile(Vehicle? vehicle = null)
    {
        if (vehicle is null) vehicle = this;
        string Make = vehicle.Make!;
        string Model = vehicle.Model!;
        string PlateNumber = vehicle.PlateNumber!;
        int ParkingSlot = 0;
        WriteToFile(Make, Model, PlateNumber, ParkingSlot);
    }
    public static void WriteToFile(string Make, string Model, string PlateNumber, int ParkingSlot)
    {
        string content = $"{ParkingSlot} | {PlateNumber} | {Make} | {Model} ";
        FileSystem.WriteToFile(content);
    }

    public static Vehicle[] ListVehicles()
    {
        Vehicle[] vehicles;
        string[] lines;

        string[] data;
        int ParkingSlot;
        string PlateNumber;
        string Make;
        string Model;
        Vehicle vehicle;

        lines = FileSystem.ReadFromFile();

        vehicles = new Vehicle[lines.Length];

        foreach (string line in lines)
        {
            data = line.Split('|');
            ParkingSlot = int.Parse(data[0]);
            PlateNumber = data[1].Trim();
            Make = data[2].Trim();
            Model = data[3].Trim();
            vehicle = new Vehicle()
            { Make = Make, Model = Model, PlateNumber = PlateNumber};
            vehicles[ParkingSlot]  = vehicle;
        }
        return vehicles;
    }

}