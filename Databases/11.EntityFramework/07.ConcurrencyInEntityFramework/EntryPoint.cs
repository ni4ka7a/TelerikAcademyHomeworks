namespace _07.ConcurrencyInEntityFramework
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
            var firstDbContext = new NorthwindEntities();
            var secondDbContext = new NorthwindEntities();


            var randomRegion = firstDbContext.Regions.FirstOrDefault();
            var anotherRandomRegion = secondDbContext.Regions.FirstOrDefault();

            randomRegion.RegionDescription = "Changed Description 1";
            anotherRandomRegion.RegionDescription = "changed Description 2";

            firstDbContext.SaveChanges();
            secondDbContext.SaveChanges();

            firstDbContext.Dispose();
            secondDbContext.Dispose();


            var thirdDbContext = new NorthwindEntities();
            var actualRegion = thirdDbContext.Regions.FirstOrDefault();
            Console.WriteLine(actualRegion.RegionDescription);
        }
    }
}
