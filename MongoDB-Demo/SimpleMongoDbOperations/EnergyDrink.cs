namespace SimpleMongoDbOperations
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class EnergyDrink
    {
        public EnergyDrink()
        {
        }

        public EnergyDrink(string name, double price)
        {
            this.Name = name;
            this.Price = price;
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
