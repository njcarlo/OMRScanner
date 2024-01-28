// ImageService.cs
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using System;

namespace TestSheetScanner.Services
{
    public class ImageService : IImageService
    {
        public void ProcessImage(IFormFile file)
        {
            var folderPath = @"inputs\sampleInputs\scans\"; 
            var fileExtension = Path.GetExtension(file.FileName);
            var filesInFolder = Directory.GetFiles(folderPath, $"image*{fileExtension}").Length;
            var newFileName = $"image{filesInFolder + 1}{fileExtension}";
            var filePath = Path.Combine(folderPath, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

        public void ExecutePythonScript(string scriptPath)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\Jace\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
            start.Arguments = scriptPath; // Pass the script file as an argument
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }

                // Check if the process has exited before accessing BasePriority
                if (!process.HasExited)
                {
                    int basePriority = process.BasePriority;
                    Console.WriteLine("Base Priority: " + basePriority);
                }
            }
        }
    }
}
