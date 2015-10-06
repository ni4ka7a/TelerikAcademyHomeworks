namespace _06.ExtractSongTitlesWithXDocumentAndLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractSongTitlesWithXDocumentAndLINQ
    {
        public static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");

            var titles = from title in xmlDoc.Descendants("title")
                         select title.Value;


            Console.WriteLine("Song Titles:\n");
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
