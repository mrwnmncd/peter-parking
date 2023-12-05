using System.IO;
using System.Runtime.CompilerServices;

class FileSystem
{
    public static void CreateFile()
    {
        string path;
        path = Environment.ParkingSpacePath;
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public static void WriteToFile(string content)
    {
        string path;

        path = Environment.ParkingSpacePath;
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(content);
        }
    }

    public static string[] ReadFromFile()
    {
        string path;
        string[] lines;

        path = Environment.ParkingSpacePath;

        CreateFile();

        lines = File.ReadAllLines(path);
        return lines;
    }
}


// PLATE NUMBER | MAKE | MODEL | PARKING SLOT