namespace _04.FindCustomersByOrdersWithNativeSqlQuery
{
    using System;
    using _01.CreateDbContextForNorthwindDatabase;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var nativeSqlQuery = "SELECT * " +
                                      "FROM Customers c " +
                                      "JOIN Orders o " +
                                      "ON c.CustomerID = o.CustomerID " +
                                      "WHERE o.ShipCountry = 'Canada' AND YEAR(o.OrderDate) = 1997";

                var customers = dbContext.Database.SqlQuery<Customer>(nativeSqlQuery);

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
        }
    }
}
