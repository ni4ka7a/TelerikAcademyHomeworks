namespace _13_14.TransformXmlToHtmlWithXlstStylesheet
{
    using System;
    using System.Xml.Xsl;

    public class TransformXmlToHtmlWithXlstStylesheet
    {
        public static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../catalogue.xslt");
            xslt.Transform("../../../catalogue.xml", "../../catalog.html");

            Console.WriteLine("The file 'catalogue.xml' was successfuly transformed in 'catalogue.html'");
        }
    }
}
