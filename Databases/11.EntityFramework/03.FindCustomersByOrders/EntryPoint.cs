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
                var customers = dbContext
                    .Customers
                    .Where(c => c.Orders.Any(x => x.OrderDate != null && (x.OrderDate.Value.Year == 1997 && x.ShipCountry == "Canada")))
                    .ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine("{0}, {1}", customer.ContactName, customer.CompanyName);
                }
            }
        }
    }
}
