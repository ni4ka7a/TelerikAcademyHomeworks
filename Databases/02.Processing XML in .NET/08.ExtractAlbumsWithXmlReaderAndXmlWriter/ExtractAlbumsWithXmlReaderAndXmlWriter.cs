namespace _08.ExtractAlbumsWithXmlReaderAndXmlWriter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    public class ExtractAlbumsWithXmlReaderAndXmlWriter
    {
        public static void Main(string[] args)
        {
            var albums = ReadAlbums("../../../catalogue.xml");
            WriteAlbums(albums, "../../albums.xml");

            Console.WriteLine("The albums was successfuly written in albums.xml");
        }

        private static Dictionary<string, string> ReadAlbums(string path)
        {
            var albums = new Dictionary<string, string>();

            using (XmlReader reader = XmlReader.Create(path))
            {
                string currentAlbum = string.Empty;
                string currentAuthor = string.Empty;

                while (reader.Read())
                {
                    if (currentAuthor != string.Empty && currentAlbum != string.Empty)
                    {
                        albums.Add(currentAlbum, currentAuthor);
                        currentAuthor = string.Empty;
                        currentAlbum = string.Empty;
                    }

                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "name"))
                    {
                        currentAlbum = reader.ReadElementString();
                    }

                    else if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "artist"))
                    {
                        currentAuthor = reader.ReadElementString();
                    }
                }
            }

            return albums;
        }

        private static void WriteAlbums(Dictionary<string, string> albums, string path)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(path, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                foreach (var item in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("album", item.Key);
                    writer.WriteElementString("author", item.Value);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
