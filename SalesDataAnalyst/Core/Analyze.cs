using SalesDataAnalyst.Common;
using SalesDataAnalyst.Infrastructure.Logging;
using SalesDataAnalyst.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using static SalesDataAnalyst.Common.EnumLayout;

namespace SalesDataAnalyst.Core
{
    public class Analyze
    {
        public static void ProcessFile(string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                var customersList = new List<Customer>();
                var sellersList = new List<Seller>();
                var salesList = new List<Sale>();
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    switch (int.Parse(ln.Split('ç')[0]))
                    {
                        case (int)Layout.Vendedor:
                            sellersList.Add(Seller.CreateSeller(ln));
                            break;
                        case (int)Layout.Cliente:
                            customersList.Add(Customer.CreateCustomer(ln));
                            break;
                        case (int)Layout.Vendas:
                            salesList.Add(Sale.CreateSale(ln));
                            break;
                        default:
                            Logger.Debug("Unidentified case!");
                            break;
                    }
                }
                file.Close();
                FileHelper.DeleteFile(fileName);

                if (customersList.Count == 0 && sellersList.Count == 0 && salesList.Count == 0)
                {
                    Logger.Debug(Path.GetFileName(fileName) + " file invalid.");
                }
                else
                {
                    var alaysis = BuildReport.GenerateAnalysis(customersList, sellersList, salesList);
                    var report = BuildReport.CreateReport(alaysis);
                    FileHelper.SaveTextFile(Path.Combine(Environment.GetEnvironmentVariable(AppSettingsHelper.GetEnvironmentVariable()), AppSettingsHelper.GetPathOUT()), Path.GetFileName(fileName), report);
                    Logger.Debug(Path.GetFileName(fileName) + " file processed.");
                }
            }
        }
    }
}
