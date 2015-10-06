namespace _12.ExtractPricesOfTheLatestAlbumsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractPricesOfTheLatestAlbumsWithLinq
    {
        public static void Main(string[] args)
        {
            var currentYear = DateTime.Now.Year;

            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");

            var prices = from album in xmlDoc.Descendants("album")
                         where (currentYear - int.Parse(album.Element("year").Value)) < 6
                         select album.Element("price").Value;

            Console.WriteLine("The prices of the latest albums are:");
            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
