namespace _04.HashTableImplementation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var table = new HashTable<int, string>();
            table.Add(1, "a");
            table.Add(2, "b");
            table.Add(3, "pesho");

            foreach (var pair in table)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }
        }
    }
}
