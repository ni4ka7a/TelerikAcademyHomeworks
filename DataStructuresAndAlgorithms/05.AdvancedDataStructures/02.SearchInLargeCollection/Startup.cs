namespace _02.SearchInLargeCollection
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Startup
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            var products = AddProducts(500000);

            var startProduct = new Product("Pesho", 100);
            var endProduct = new Product("Pesho", 200);

            var filteredProducts = products.Range(startProduct, true, endProduct, true).Take(20);

            foreach (var product in filteredProducts)
            {
                Console.WriteLine("Name: {0}    Price:{1}", product.Name, product.Price);
            }
        }

        private static OrderedBag<Product> AddProducts(int numberOfProducts)
        {
            var products = new OrderedBag<Product>();

            for (int i = 1; i < numberOfProducts; i++)
            {
                products.Add(new Product(
                    "Name " + i,
                    Random.Next(1, 1000)));
            }

            return products;
        }
    }
}
