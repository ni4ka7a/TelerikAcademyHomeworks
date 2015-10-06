namespace _04.RemoveExpensiveAlbums
{
    using System;
    using System.Xml;

    public class RemoveExpensiveAlbums
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;

            int removedElements = 0;

            foreach (XmlNode currentNode in rootNode.SelectNodes("album"))
            {
                var price = double.Parse(currentNode["price"].InnerText);

                if (price > 20)
                {
                    rootNode.RemoveChild(currentNode);
                    removedElements++;
                }

            }

            doc.Save("../../cheapAlbums.xml");

            Console.WriteLine("The number of the removed albums is: {0}", removedElements);
            Console.WriteLine("You can see the new list of albums in 'cheapAlbums.xml'");


        }
    }
}
