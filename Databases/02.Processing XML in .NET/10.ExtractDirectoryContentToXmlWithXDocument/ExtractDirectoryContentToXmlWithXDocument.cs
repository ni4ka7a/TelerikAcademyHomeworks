namespace _10.ExtractDirectoryContentToXmlWithXDocument
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    public class ExtractDirectoryContentToXmlWithXDocument
    {
        public static void Main(string[] args)
        {
            string path = @"../../";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            var rootDirectory = new DirectoryInfo(path);

            XElement directoryInfo = new XElement("root");
            directoryInfo.Add(WalkDirectoryTree(rootDirectory));

            directoryInfo.Save("../../fileSystem.xml");

            Console.WriteLine("The information about the directories was successfuly saved in 'fileSystem.xml'");
        }

        private static XElement WalkDirectoryTree(DirectoryInfo directory)
        {
            var currentElement = new XElement("dir", new XAttribute("path", directory.Name));

            foreach (var currentFile in directory.GetFiles())
            {
                currentElement.Add(new XElement("file", currentFile.Name));
            }

            foreach (var currentDirectory in directory.GetDirectories())
            {
                currentElement.Add(WalkDirectoryTree(currentDirectory));
            }

            return currentElement;
        }
    }
}
