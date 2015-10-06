namespace _02.ExtractArtistsWithDOMParser
{
    using System;
    using System.Xml;
    using System.Collections.Generic;

    public class ExtractArtistsWithDOMParser
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;

            var artists = new Dictionary<string, int>();

            foreach (XmlNode album in rootNode.ChildNodes)
            {
                foreach (XmlNode child in album.ChildNodes)
                {
                    if (child.Name == "artist")
                    {
                        var currentArtist = child.InnerText;

                        if (artists.ContainsKey(currentArtist))
                        {
                            artists[currentArtist] = artists[currentArtist] + 1;
                        }

                        else
                        {
                            artists.Add(currentArtist, 1);
                        }
                    }
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
