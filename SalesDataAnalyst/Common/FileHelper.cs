using System;
using System.IO;

namespace SalesDataAnalyst.Common
{
    public static class FileHelper
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void CreateDirectories()
        {
            CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable(AppSettingsHelper.GetEnvironmentVariable()), AppSettingsHelper.GetPathIN()));
            CreateDirectory(Path.Combine(Environment.GetEnvironmentVariable(AppSettingsHelper.GetEnvironmentVariable()), AppSettingsHelper.GetPathOUT()));
        }

        public static void SaveTextFile(string path, string fileName, string body)
        {
            StreamWriter textFile;
            var fileReport = "Report-" + fileName.Replace(".dat", ".txt");
            var pathFile = Path.Combine(Environment.CurrentDirectory, path, fileReport);

            if (File.Exists(pathFile))
                File.Delete(pathFile);
            
            textFile = File.AppendText(pathFile);
            var msg = string.Concat($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") } result of { fileName } file analysis process.");
            textFile.WriteLine(msg);
            textFile.WriteLine();

            foreach (var line in body.Split('\n'))
                textFile.WriteLine(line);
            
            textFile.Close();
        }

        public static void DeleteFile(string fullNameFile)
        {
            if (File.Exists(fullNameFile))
                File.Delete(fullNameFile);
        }
    }
}
