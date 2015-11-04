namespace _03.DirectoriesTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // This program may take awhile..
            string path = @"C:\WINDOWS\";

            var rootFolder = new Folder(path);
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            WalkDirectoryTree(rootFolder);

            Console.WriteLine("The size of all files in C:/WINDOWS/ is:");
            Console.WriteLine(CalculateSize(rootFolder) + " MB");
        }

        private static void WalkDirectoryTree(Folder folder)
        {
            try
            {
                var folderInfo = new DirectoryInfo(folder.Name);
                var subFilesToAdd = new List<File>();
                var subFoldersToAdd = new List<Folder>();

                FileInfo[] containedFIles = folderInfo.GetFiles();

                foreach (FileInfo file in containedFIles)
                {
                    var fileToAdd = new File(file.Name, (int)file.Length);
                    subFilesToAdd.Add(fileToAdd);
                }

                folder.Files = subFilesToAdd.ToArray();
                Console.Write(".");
                foreach (var subfolder in Directory.GetDirectories(folder.Name))
                {
                    var folderToAdd = new Folder(subfolder);
                    subFoldersToAdd.Add(folderToAdd);
                    WalkDirectoryTree(folderToAdd);
                }

                folder.ChildFolders = subFoldersToAdd.ToArray();
            }

            // This action prevent from UnauthorizedAccess Exception,
            // because the program doesn't have rights to access all the folders in C:\WINDOWS\.
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static ulong CalculateSize(Folder folder, ulong size = 0)
        {
            if (folder.Files != null)
            {
                foreach (var file in folder.Files)
                {
                    size += (ulong)file.Size;
                }
            }

            if (folder.ChildFolders != null)
            {
                foreach (var subfolder in folder.ChildFolders)
                {
                    size += CalculateSize(subfolder);
                }
            }

            return size;
        }
    }
}
