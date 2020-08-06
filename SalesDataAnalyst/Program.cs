using SalesDataAnalyst.Common;
using SalesDataAnalyst.Core;
using SalesDataAnalyst.Infrastructure.Logging;
using System;

namespace SalesDataAnalyst
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeSystem();
            FileHelper.CreateDirectories();
            FileWatcher.StartWatcher();
        }       

        private static void WelcomeSystem()
        {
            Logger.Debug("System was started");
            Logger.Debug("Welcome! System designed by Alison Machado Alves");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Logger.Debug("Enjoy and visit my site http://alisonalves.com/");
            Logger.Debug("Project hosted on GitHub https://github.com/AlisonFgt/sales_analyst");
            Console.ResetColor();
        }
    }
}
