namespace _11.ExtractPricesOfTheLatestAlbumsWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractPricesOfTheLatestAlbumsWithXPath
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");
            string xPathQuery = "/catalogue/album[year>2009]/price";


            XmlNodeList albumNodes = doc.SelectNodes(xPathQuery);

            Console.WriteLine("The prices of the latest albums are:");

            foreach (XmlNode currentAlbumNode in albumNodes)
            {
                Console.WriteLine(currentAlbumNode.InnerText);
            }
        }
    }
}
