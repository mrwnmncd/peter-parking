using System.IO;

class FileManager
{

    public static bool CheckFileExists(string path)
    {
        return File.Exists(path);
    }
    public static void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public static void OverwriteToFile(string path, string[] content)
    {
        File.WriteAllLines(path, content);
    }
    public static void WriteToFile(string path, string content, int? line)
    {
        string[] lines;
        if (line is not null)
        {
            lines = File.ReadAllLines(path);
            lines[line.Value] = content;
            File.WriteAllLines(path, lines);
        }
        else
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(content);
            }
        }

    }

    public static void AppendToFile(string path, string content)
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(content);
        }
    }

    public static string[] ReadFromFile(string path)
    {
        string[] lines;

        CreateFile(path);

        lines = File.ReadAllLines(path);
        return lines;
    }
}