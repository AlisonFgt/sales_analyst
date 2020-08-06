using System.Collections.Generic;
using System.Globalization;

namespace SalesDataAnalyst.Models.Entities
{
    public class Sale
    {
        public Sale() { }

        public Sale(int id, IList<Item> itens, string salesMan)
        {
            Id = id;
            Itens = itens;
            SalesMan = salesMan;

            foreach (var item in itens)
            {
                TotalSale += item.Price;
            }
        }

        public int Id { get; set; }

        public IList<Item> Itens { get; set; }

        public string SalesMan { get; set; }

        public double TotalSale { get; set; }

        public static Sale CreateSale(string value)
        {
            var sale = value.Split('ç');
            var itens = sale[2].Replace("[", "").Replace("]", "").Split(',');
            var itensList = new List<Item>();

            foreach (var preItem in itens)
            {
                var item = preItem.Split('-');
                itensList.Add(new Item(int.Parse(item[0]), int.Parse(item[1]), double.Parse(item[2], CultureInfo.GetCultureInfo("en-US"))));
            }

            return new Sale(int.Parse(sale[1]), itensList, sale[3]);
        }
    }

    public class Item
    {
        public Item() { }

        public Item(int itemId, int itemQuantity, double itemPrice)
        {
            Id = itemId;
            Quantity = itemQuantity;
            Price = itemPrice;
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}