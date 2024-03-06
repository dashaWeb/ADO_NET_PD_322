using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_access_layer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Id:{Id,-10} Name:{Name,-15} Type:{Type,-10} Quantity:{Quantity,-5} CostPrice:{CostPrice,-5} Producer:{Producer,-15} Price:{Price,-10}";
        }
    }
}
