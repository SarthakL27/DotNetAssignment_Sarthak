using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Assignment2.Model
{
    class Product
    {
        public int ProductID { get;  }
        public string Name { get;  }

        public string Category { get; }

        public decimal Price { get;  }

        public Product (int productID,string name,string category,decimal price)
        {
            ProductID = productID;
            Name = name;
            Category = category;
            Price = price;

        }
       


    }
}
