namespace _02.SearchInLargeCollection
{
    using System;

    public class Product : IComparable
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int CompareTo(object obj)
        {
            var productToCompare = obj as Product;

            return this.Price - productToCompare.Price;
        }
    }
}
