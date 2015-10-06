namespace _03.ExtractArtistsWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Linq;

    public class ExtractArtistsWithXPath
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            string xPathQuery = "/catalogue/album/artist";

            var artists = new Dictionary<string, int>();

            XmlNodeList artistNodes = doc.SelectNodes(xPathQuery);

            foreach (XmlNode currentArtistNode in artistNodes)
            {
                var currentArtistName = currentArtistNode.InnerText;

                if (artists.ContainsKey(currentArtistName))
                {
                    artists[currentArtistName] = artists[currentArtistName] + 1;
                }

                else
                {
                    artists.Add(currentArtistName, 1);
                }
            }

            PrintArtists(artists);
            
        }

        private static void PrintArtists(Dictionary<string, int> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0}, Songs: {1}", artist.Key, artist.Value);
            }
        }
    }
}
