using Day7Assignment2.Model;
using Day7Assignment2.Repository;

namespace Day7Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product(1, "mobile", "Electronics", 20000);
            Product p1 = new Product(2, "laptop", "Electronics", 40000);
            Product p2= new Product(3, "headphones", "wearables", 600);
            Product p3= new Product(4, "waterbottle", "Essentials",800);
            Product p4= new Product(5, "tablet", "Electronics", 15000);
            Product p5= new Product(6, "book", "Essentials",100);

            Products pop = new Products();
            pop.AddProduct(p);
            pop.AddProduct(p1);
            pop.AddProduct(p2);
            pop.AddProduct(p3);
            pop.AddProduct(p4);
            pop.AddProduct(p5);

           FilteredProducts getFilteredProducts = new FilteredProducts();
            getFilteredProducts.FilterByCategoryAndPrice(pop.getProduct(), "electronics", 1000);
            getFilteredProducts.MostExpensiveProduct(pop.getProduct());


        }
    }
}
