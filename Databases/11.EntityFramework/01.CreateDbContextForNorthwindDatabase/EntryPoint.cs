// 01.Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database

namespace _01.CreateDbContextForNorthwindDatabase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            using(var db = new NorthwindEntities())
            {
                var firstCategory = db.Categories.Where(cat => cat.CategoryID == 1).FirstOrDefault();

                Console.WriteLine(firstCategory.CategoryName);
            }
        }
    }
}
