using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
