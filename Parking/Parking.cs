public class ParkingSpace
{
    public string? PlateNumber { get; set; }
    public List<Vehicle> space { get; set; }

    public ParkingSpace()
    {
        List<Vehicle> parkspace = new List<Vehicle>();
        this.space = parkspace;
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