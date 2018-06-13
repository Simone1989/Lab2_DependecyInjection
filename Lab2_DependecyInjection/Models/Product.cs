using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_DependecyInjection.Models
{
    public class Product
    {
        public Product(int id, string type, decimal price, int quantity, string section)
        {
            id = Id;
            type = Type;
            price = Price;
            quantity = Quantity;
            section = Section;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Section { get; set; }

    }
}
