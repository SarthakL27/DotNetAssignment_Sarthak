using Day7Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Assignment2
{
    class Products
    {
        List<Product> ls;
        public Products()
        {
            ls = new List<Product>();
        }

        public void AddProduct(Product p)
        {
            ls.Add(p);
        }

        public List<Product> getProduct()
        {
            return ls;
        }
    }
}
