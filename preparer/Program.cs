using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Text.Json;

namespace Prepare
{
    class Program
    {
        static string zipPath = @"E:\Downloads\Project.sb3";
        static string dirPath = @"C:\Main\Cs\SCP\Project_Json";
        static string jsonPath = @"C:\Main\Cs\SCP\Project_Json\project.Json";
        static string prePath = @"C:\Main\Cs\SCP\Tests\Project\Export\Project\project.json";
        static void Main()
        {
            string command = Console.ReadLine();
            if(command == "make readable")
            {
                JsonSerializerOptions options_ = new JsonSerializerOptions();
                options_.WriteIndented = true;
                object json_ = JsonSerializer.Deserialize<object>(File.ReadAllText(prePath));
                File.WriteAllText(prePath, JsonSerializer.Serialize(json_, options_));
                Main();
            }
            if(File.Exists(zipPath))
            {
                Directory.Delete(dirPath, true);
                Directory.CreateDirectory(dirPath);
                ZipFile.ExtractToDirectory(zipPath, dirPath);
                File.Delete(zipPath);
            }
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            object json = JsonSerializer.Deserialize<object>(File.ReadAllText(jsonPath));
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(json, options));
            Main();
        }
    }
}
