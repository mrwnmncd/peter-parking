using System.IO;
using System.Runtime.CompilerServices;

class FileSystem
{

    public static void WriteToFile(string content)
    {
        string path;

        path = Environment.ParkingSpacePath;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(content);
        }
    }

    public static void WriteToFile(string[] content)
    {
        string path;

        path = Environment.ParkingSpacePath;
        using (StreamWriter sw = File.AppendText(path))
        {
            foreach (string line in content)
            {
                sw.WriteLine(line);
            }
        }
    }

    public static string[] ReadFromFile()
    {
        string path;
        string[] lines;

        path = Environment.ParkingSpacePath;
        if (!File.Exists(path))
        {
            File.Create(path);
            Console.WriteLine("Reading from file...");
            // Thread.sleep(2000);
        }
        lines = File.ReadAllLines(path);
        return lines;
    }
}


// PLATE NUMBER | MAKE | MODEL | PARKING SLOT