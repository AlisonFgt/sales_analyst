using NUnit.Framework;
using SalesDataAnalyst.Core;
using SalesDataAnalyst.Models.Entities;
using System.Collections.Generic;

namespace NUnitTest
{
    public class UnitTestCases
    {
        List<Sale> salesList;
        List<Item> itensOne;
        List<Item> itensTwo;
        List<Customer> customersList;
        List<Seller> sellersList;

        [SetUp]
        public void Setup()
        {
            salesList = new List<Sale>();
            itensOne = new List<Item>();
            itensTwo = new List<Item>();
            customersList = new List<Customer>();
            sellersList = new List<Seller>();

            itensOne.Add(new Item(1, 2, 20.50));
            itensOne.Add(new Item(2, 4, 40.50));
            itensTwo.Add(new Item(3, 6, 60.50));
            itensTwo.Add(new Item(4, 8, 80.50));

            salesList.Add(new Sale(1, itensOne, "Carlos"));
            salesList.Add(new Sale(2, itensTwo, "Bianca"));

            customersList.Add(new Customer("49762147000108", "Fabrica do pastel", "Alimentos"));
            customersList.Add(new Customer("49762147770108", "Fabrica do sapato", "Calçados"));

            sellersList.Add(new Seller("02164558445", "Caio", 880.00));
            sellersList.Add(new Seller("02164754122", "Luiz", 1380.00));
            sellersList.Add(new Seller("02845511278", "Sabrina", 6456.00));
        }

        [Test]
        public void TestGetMostExpensiveSale()
        {
            var sale = BuildReport.GetMostExpensiveSale(salesList);
            Assert.AreEqual(141, sale.TotalSale);
        }

        [Test]
        public void TestGetWorstSeller()
        {
            var sellerPerformance = BuildReport.GetWorstSeller(salesList);
            Assert.AreEqual("Carlos", sellerPerformance.Name);
        }

        [Test]
        public void TestGenerateAnalysis()
        {
            var report = BuildReport.GenerateAnalysis(customersList, sellersList, salesList);
            Assert.AreEqual(2, report.MostExpensiveSaleID);
            Assert.AreEqual(2, report.NumberOfCustomers);
            Assert.AreEqual(3, report.NumberOfSellers);
            Assert.AreEqual("Carlos", report.WorstSeller);
        }
    }
}
