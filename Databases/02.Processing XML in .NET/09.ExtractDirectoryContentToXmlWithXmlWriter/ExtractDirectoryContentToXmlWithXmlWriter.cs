namespace _09.ExtractDirectoryContentToXmlWithXmlWriter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class ExtractDirectoryContentToXmlWithXmlWriter
    {
        public static void Main(string[] args)
        {
            string path = @"../../";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter("../../fileSystem.xml", encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();

                WalkDirectoryTree(new DirectoryInfo(path), writer);

                writer.WriteEndDocument();
            }

            Console.WriteLine("The information about the directories was successfuly saved in 'fileSystem.xml'");
        }

        private static void WalkDirectoryTree(DirectoryInfo root, XmlTextWriter writer)
        {
            System.IO.FileInfo[] files = root.GetFiles();
            System.IO.DirectoryInfo[] subDirs = null;

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("path", root.Name);

            foreach (System.IO.FileInfo fi in files)
            {
                writer.WriteElementString("file", fi.ToString());
            }
            subDirs = root.GetDirectories();

            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo, writer);
            }


            writer.WriteEndElement();
        }

    }
}

