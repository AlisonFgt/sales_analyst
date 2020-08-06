namespace SalesDataAnalyst.Models.Entities
{
    public class Customer
    {
        public Customer() { }

        public Customer(string cnpj, string name, string area)
        {
            CNPJ = cnpj;
            Name = name;
            Area = area;
        }

        public string CNPJ { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public static Customer CreateCustomer(string value)
        {
            var customer = value.Split('ç');
            return new Customer(customer[1], customer[2], customer[3]);
        }
    }
}
