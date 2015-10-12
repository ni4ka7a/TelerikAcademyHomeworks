// 02.Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.

namespace _02.CreateDAOClass
{
    using System;
    using System.Linq;
    using _01.CreateDbContextForNorthwindDatabase;

    public class EntryPoint
    {

        public static void Main(string[] args)
        {
            //InsertCustomer();
            //DeleteCustomer();
            //ModifyCustomer();
        }

        private static void InsertCustomer()
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(new Customer()
                {
                    CompanyName = "Fake company",
                    CustomerID = "100"
                });

                dbContext.SaveChanges();
            }

            Console.WriteLine("The customer was added successfully");
        }

        private static void DeleteCustomer()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var unluckyCustomer = dbContext.Customers.Where(c => c.CustomerID == "100").FirstOrDefault();
                dbContext.Customers.Remove(unluckyCustomer);
                dbContext.SaveChanges();
            }

            Console.WriteLine("The customer was deleted successfully");
        }


        private static void ModifyCustomer()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var luckyCustomer = dbContext.Customers.FirstOrDefault();
                luckyCustomer.Country = "Bulgaria";
                dbContext.SaveChanges();
            }

            Console.WriteLine("The customer was modified successfully");
        }

    }
}
