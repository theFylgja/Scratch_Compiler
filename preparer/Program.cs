using System;
using System.IO.Compression;
using System.Text.Json;

namespace Prepare
{
    class Program
    {
        static string zipPath = @"E:\Downloads\extraction.sb3";
        static string dirPath = @"C:\Main\Cs\SCP\Project_Json";
        static string jsonPath = @"C:\Main\Cs\SCP\Project_Json\project.Json";
        static void Main()
        {
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
            Environment.Exit(0);
        }
    }
}
