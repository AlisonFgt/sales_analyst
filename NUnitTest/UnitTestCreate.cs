using NUnit.Framework;
using SalesDataAnalyst.Models.Entities;

namespace NUnitTest
{
    public class UnitTestCreate
    {
        [Test]
        [TestCase("002ç2345675434544345çJose da SilvaçRural", ExpectedResult = "Jose da Silva", TestName = "TestCreateCustomerName")]
        public string TestCreateCustomerName(string line)
        {
            var customer = Customer.CreateCustomer(line);
            return customer.Name;
        }

        [Test]
        [TestCase("002ç2345675434544345çJose da SilvaçRural", ExpectedResult = "Rural", TestName = "TestCreateCustomerArea")]
        public string TestCreateCustomerArea(string line)
        {
            var customer = Customer.CreateCustomer(line);
            return customer.Area;
        }

        [Test]
        [TestCase("002ç2345675434544345çJose da SilvaçRural", ExpectedResult = "2345675434544345", TestName = "TestCreateCustomerCPF")]
        public string TestCreateCustomerCPF(string line)
        {
            var customer = Customer.CreateCustomer(line);
            return customer.CNPJ;
        }

        [Test]
        [TestCase("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", ExpectedResult = 10, TestName = "TestCreateSaleId")]
        public int TestCreateSaleId(string line)
        {
            var sale = Sale.CreateSale(line);
            return sale.Id;
        }

        [Test]
        [TestCase("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", ExpectedResult = 3, TestName = "TestCreateSaleCountItens")]
        public int TestCreateSaleCountItens(string line)
        {
            var sale = Sale.CreateSale(line);
            return sale.Itens.Count;
        }

        [Test]
        [TestCase("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", ExpectedResult = "Pedro", TestName = "TestCreateSaleSalesMan")]
        public string TestCreateSaleSalesMan(string line)
        {
            var sale = Sale.CreateSale(line);
            return sale.SalesMan;
        }

        [Test]
        [TestCase("001ç3245678865434çPauloç40000.99", ExpectedResult = "3245678865434", TestName = "TestCreateSellerCPF")]
        public string TestCreateSellerCPF(string line)
        {
            var seller = Seller.CreateSeller(line);
            return seller.CPF;
        }

        [Test]
        [TestCase("001ç3245678865434çPauloç40000.99", ExpectedResult = "Paulo", TestName = "TestCreateSellerName")]
        public string TestCreateSellerName(string line)
        {
            var seller = Seller.CreateSeller(line);
            return seller.Name;
        }

        [Test]
        [TestCase("001ç3245678865434çPauloç40000.99", ExpectedResult = "40000.99", TestName = "TestCreateSellerSalary")]
        public double TestCreateSellerSalary(string line)
        {
            var seller = Seller.CreateSeller(line);
            return seller.Salary;
        }
    }
}
