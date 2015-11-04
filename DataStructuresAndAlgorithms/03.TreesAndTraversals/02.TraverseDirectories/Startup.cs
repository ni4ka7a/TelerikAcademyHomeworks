namespace _02.TraverseDirectories
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // There are alooot of exe-s in C:\WINDOWS\ - you don't have to wait them all.
            string path = @"C:\WINDOWS\";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            WalkDirectoryTree(new DirectoryInfo(path));
        }

        private static void WalkDirectoryTree(DirectoryInfo root)
        {
            try
            {
                var files = root.GetFiles()
              .Where(f => f.Extension == ".exe")
              .ToList();

                foreach (System.IO.FileInfo fi in files)
                {
                    Console.WriteLine(fi.Name);
                }

                System.IO.DirectoryInfo[] subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }

            // This action prevent from UnauthorizedAccess Exception,
            // because the program doesn't have rights to access all the folders in C:\WINDOWS\.
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
