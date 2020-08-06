using SalesDataAnalyst.Models.Entities;
using SalesDataAnalyst.Models.Reports;
using System.Collections.Generic;
using System.Linq;

namespace SalesDataAnalyst.Core
{
    public class BuildReport
    {
        public static string CreateReport(Report report)
        {
            var msg = " Quantidade de clientes no arquivo de entrada: " + report.NumberOfCustomers.ToString()
                    + "\n Quantidade de vendedores no arquivo de entrada: " + report.NumberOfSellers.ToString()
                    + "\n ID da venda mais cara: " + report.MostExpensiveSaleID.ToString()
                    + "\n O pior vendedor: " + report.WorstSeller;

            return msg;
        }

        public static Report GenerateAnalysis(List<Customer> customersList, List<Seller> sellersList, List<Sale> salesList)
        {
            var report = new Report();

            report.NumberOfCustomers = customersList.Count;
            report.NumberOfSellers = sellersList.Count;
            report.MostExpensiveSaleID = GetMostExpensiveSale(salesList).Id;
            report.WorstSeller = GetWorstSeller(salesList).Name;

            return report;
        }

        public static SellerPerformance GetWorstSeller(List<Sale> salesList)
        {
            var sellersPerformance = new List<SellerPerformance>();

            foreach (var sale in salesList)
            {
                if (sellersPerformance.Find(x => x.Name.Equals(sale.SalesMan)) != null)
                {
                    sellersPerformance.Find(x => x.Name.Equals(sale.SalesMan)).SalesAmount += sale.TotalSale;
                }
                else
                {
                    sellersPerformance.Add(new SellerPerformance { Name = sale.SalesMan, SalesAmount = sale.TotalSale });
                }
            }

            return (from sp in sellersPerformance
                    orderby sp.SalesAmount ascending
                    select sp).FirstOrDefault();
        }

        public static Sale GetMostExpensiveSale(List<Sale> salesList)
        {
            var mostExpensiveSale = new Sale();

            foreach (var sale in salesList)
            {
                if (mostExpensiveSale.TotalSale < sale.TotalSale)
                    mostExpensiveSale = sale;
            }

            return mostExpensiveSale;
        }
    }
}
