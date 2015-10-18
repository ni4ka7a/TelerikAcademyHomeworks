namespace _08.InheritingEntityFrameworkClass
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

            var randomEmployee = dbContext
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Territories
                })
                .FirstOrDefault();

            Console.WriteLine(randomEmployee.FirstName);

            foreach (var teritory in randomEmployee.Territories)
            {
                Console.WriteLine(teritory.TerritoryDescription);
            }
        }
    }
}
