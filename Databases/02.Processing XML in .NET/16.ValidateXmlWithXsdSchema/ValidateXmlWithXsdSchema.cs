namespace _16.ValidateXmlWithXsdSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class ValidateXmlWithXsdSchema
    {
        public static void Main(string[] args)
        {
            var validXmlPath = "../../../catalogue.xml";
            var invalidXmlPath = "../../invalidCatalogue.xml";
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalogue.xsd");
            XDocument correctDoc = XDocument.Load(validXmlPath);
            XDocument invalidDoc = XDocument.Load(invalidXmlPath);

            Console.WriteLine("Document '{0}'", validXmlPath);
            ValidateXML(schema, correctDoc);

            Console.WriteLine("\nDocument '{0}'", invalidXmlPath);
            ValidateXML(schema, invalidDoc);
        }

        private static void ValidateXML(XmlSchemaSet schema, XDocument correctDoc)
        {
            bool hasError = false;

            correctDoc.Validate(schema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                hasError = true;
            });

            Console.WriteLine("XML document is {0}", hasError ? "not valid" : "valid");
        }
    }
}
