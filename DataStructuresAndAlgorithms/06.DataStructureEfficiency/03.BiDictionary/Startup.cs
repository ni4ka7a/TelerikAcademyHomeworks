namespace _03.BiDictionary
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var dict = new BiDictionary<int, int, string>();

            dict.Add(1, 1, "Pesho");
            dict.Add(1, 21, "Gosho");
            dict.Add(2, 1, "Stamat");
            dict.Add(1, 3, "Mariika");

            Console.WriteLine(dict[1, 3]);
            Console.WriteLine(dict[1, 1]);

            var collectionByKey2 = dict.GetByKey2(1);
            Console.WriteLine(string.Join(", ", collectionByKey2));  
        }
    }
}
