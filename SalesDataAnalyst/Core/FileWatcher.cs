using SalesDataAnalyst.Common;
using SalesDataAnalyst.Infrastructure.Logging;
using System;
using System.IO;
using System.Linq;

namespace SalesDataAnalyst.Core
{
    public static class FileWatcher
    {
        public static void StartWatcher()
        {
            while (true)
            {
                try
                {
                    string[] filePaths = Directory.GetFiles(Path.Combine(Environment.GetEnvironmentVariable(AppSettingsHelper.GetEnvironmentVariable()), AppSettingsHelper.GetPathIN()));

                    foreach (string name in filePaths.Where(x => x.EndsWith(".dat")))
                    {
                        Analyze.ProcessFile(name);
                    }
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }
    }
}
