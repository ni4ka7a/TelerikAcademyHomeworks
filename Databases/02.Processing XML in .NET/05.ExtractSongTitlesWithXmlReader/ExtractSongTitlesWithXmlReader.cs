namespace _05.ExtractSongTitlesWithXmlReader
{
    using System;
    using System.Xml;

    public class ExtractSongTitlesWithXmlReader
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Song Titles:\n");
            using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
