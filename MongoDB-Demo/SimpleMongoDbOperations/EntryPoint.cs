namespace SimpleMongoDbOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MongoDB.Driver;

    public class EntryPoint
    {
        protected static IMongoClient client;
        protected static IMongoDatabase database;

        public static void Main(string[] args)
        {
            // #Connect to Db Shop => caseSensitive!!!
            client = new MongoClient("mongodb://127.0.0.1");
            database = client.GetDatabase("Shop");

            //var eDrink = new EnergyDrink("Hell", 1.05);

            // #connect to table EnergyDrinks
            var drinksCollection = database.GetCollection<EnergyDrink>("EnergyDrinks");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter command:");
                Console.WriteLine("Add new drink: => 1");
                Console.WriteLine("Get all drinks: => 2");
                Console.WriteLine("Get drinks by name => 3");
                Console.WriteLine("Get drinks by price => 4");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1": InsertToDatabase(drinksCollection); break;
                    case "2": GetAllDrinks(drinksCollection); break;
                    case "3": SearchByName(drinksCollection); break;
                    case "4": SearchByPrice(drinksCollection); break;
                    default:
                        break;
                }
            }
        }

        private static void SearchByName(IMongoCollection<EnergyDrink> collection)
        {
            Console.Clear();
            Console.Write("Enter the name:");
            var inputName = Console.ReadLine();

            var fileter = Builders<EnergyDrink>.Filter.Eq("Name", inputName);
            var result = collection.Find(fileter).ToListAsync().Result;

            if (result.Count == 0)
            {
                Console.WriteLine("\nThere are no drinks with name {0}", inputName);
            }

            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine("Name: {0} => Price: {1}", item.Name, item.Price);
                }
            }

            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
        }

        private static void SearchByPrice(IMongoCollection<EnergyDrink> collection)
        {
            Console.Clear();
            Console.Write("Enter the price:");
            var inputPrice = double.Parse(Console.ReadLine());

            var fileter = Builders<EnergyDrink>.Filter.Eq("Name", inputPrice);
            var result = collection.Find(fileter).ToListAsync().Result;

            if (result.Count == 0)
            {
                Console.WriteLine("\nThere are no drinks with name {0}", inputPrice);
            }

            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine("Name: {0} => Price: {1}", item.Name, item.Price);
                }
            }

            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
        }

        private static void GetAllDrinks(IMongoCollection<EnergyDrink> collection)
        {
            Console.Clear();
            var rest = collection.Find(_ => true);

            foreach (var item in rest.ToListAsync().Result)
            {
                Console.WriteLine("Name: {0} => Price: {1}", item.Name, item.Price);
            }


            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
        }

        private static void InsertToDatabase(IMongoCollection<EnergyDrink> collection)
        {
            Console.Clear();
            Console.Write("Enter the name of the drink:");
            var name = Console.ReadLine();
            Console.Write("\nEnter the price of the drink:");
            var price = double.Parse(Console.ReadLine());

            var energyDrink = new EnergyDrink(name, price);
            collection.InsertOneAsync(energyDrink);

            Console.WriteLine("The drink was successfuly added");
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadLine();
        }
    }
}
