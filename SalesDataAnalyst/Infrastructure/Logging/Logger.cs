using System;
using System.IO;

namespace SalesDataAnalyst.Infrastructure.Logging
{
    public class Logger
    {
        static string logFile = "loggerfile.txt";

        public static void Debug(string content)
        {
            SaveLog("DEBUG", content);
        }

        public static void Error(string content)
        {
            SaveLog("ERROR", content);
        }

        public static void Error(string content, string error)
        {
            SaveLog("ERROR", content + error);
        }

        public static void SaveLog(string status, string content)
        {
            StreamWriter log;

            if (!File.Exists(logFile))
            {
                log = new StreamWriter(logFile);
            }
            else
            {
                log = File.AppendText(logFile);
            }

            var msg = string.Concat($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") } - { status } - {content }");
            log.WriteLine(msg);
            log.WriteLine();
            Console.WriteLine(msg);
            log.Close();
        }
    }
}
