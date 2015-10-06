namespace _07.CreateXMLFromTextData
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class CreateXMLFromTextData
    {
        public static void Main(string[] args)
        {
            var personName = string.Empty;
            var personAddress = string.Empty;
            var personPhoneNumber = string.Empty;
            using (var reader = new StreamReader("../../personData.txt"))
            {
                personName = reader.ReadLine();
                personAddress = reader.ReadLine();
                personPhoneNumber = reader.ReadLine();
            }

            XElement persons =
                new XElement("persons",
                    new XElement("person",
                        new XElement("name", personName),
                        new XElement("address", personAddress),
                        new XElement("phoneNumber", personPhoneNumber)));

            Console.WriteLine("Successfuly parsed the data in 'personData.txt' in 'persons.xml'");
            persons.Save("../../persons.xml");
        }
    }
}
