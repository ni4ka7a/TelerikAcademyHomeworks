namespace _05.FindSalesByRegionAndPeriod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using _01.CreateDbContextForNorthwindDatabase;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var dbContext = new NorthwindEntities();

            var startDate = new DateTime(1995, 10, 10);
            var endDate = new DateTime(1997, 01, 1);
            var region = "RJ";

            var orders = dbContext
                .Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Where(o => o.ShipRegion == region)
                .Select(o => new
                {
                    Id = o.OrderID,
                    Quantity = o.Order_Details.FirstOrDefault().Quantity,
                    Region = o.ShipRegion
                })
                .ToList();


            foreach (var order in orders)
            {
                Console.WriteLine("{0}, {1}, {2}", order.Id, order.Quantity, order.Region);
            }



        }
    }
}
