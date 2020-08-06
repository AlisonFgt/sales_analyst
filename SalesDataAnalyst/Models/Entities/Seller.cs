
using System.Globalization;

namespace SalesDataAnalyst.Models.Entities
{
    public class Seller
    {
        public Seller() { }

        public Seller(string cpf, string name, double salary)
        {
            CPF = cpf;
            Name = name;
            Salary = salary;
        }

        public string CPF { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public static Seller CreateSeller(string value)
        {
            var seller = value.Split('ç');
            return new Seller(seller[1], seller[2], double.Parse(seller[3], CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
