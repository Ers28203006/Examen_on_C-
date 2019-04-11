using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void ProductAddDelegate(Product product);
    [Serializable]
    public class Product
    {
        public event ProductAddDelegate Event;

        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }

        public void Add(Product product)
        {
            Event(product);
        }
    }
}