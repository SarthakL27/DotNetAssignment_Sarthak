using Day7Assignment2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Assignment2.Repository
{
    class FilteredProducts
    {
        public void FilterByCategoryAndPrice(List<Product> products,string category,decimal price)
        {
            var filteredProducts = products.Where(p => p.Category == category && p.Price > price);
            Console.WriteLine($"Filters=> Category :{category} and Price >{price}");
            if (filteredProducts.Count() > 0)
            {
                foreach (Product product in filteredProducts)
                {
                    Console.WriteLine($"ProductID:{product.ProductID}and Product Name:{product.Name}");
                }
            }
            else
            {
                Console.WriteLine("No products with this filter");
            }

        }

        public void MostExpensiveProduct(List<Product> products)
        {
            var maxPrice = products.Max(p => p.Price);
            var expensiveProducts = products.Where(p => p.Price == maxPrice);
            Console.WriteLine("Expensive Products are:");
            if (expensiveProducts.Count() > 0)
            {
                foreach(Product product in expensiveProducts)
                {
                    Console.WriteLine($"{product.Name}:{product.Price} RS");
                }
            }
            else
            {
                Console.WriteLine("No Products");
            }
        }
    }
}
