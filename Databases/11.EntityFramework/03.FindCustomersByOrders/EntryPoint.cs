// 03.Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

namespace _03.FindCustomersByOrders
{
    using System;
    using System.Linq;
    using _01.CreateDbContextForNorthwindDatabase;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new NorthwindEntities())
            {
                // Doesen't work!
                var cus = dbContext
                    .Customers
                    .Where(c => c.Orders.Where(o => o.ShipCountry == "Canada" && o.OrderDate.Value.Year == 1997).Any())
                    .ToList();

                foreach (var item in cus)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
        }
    }
}
