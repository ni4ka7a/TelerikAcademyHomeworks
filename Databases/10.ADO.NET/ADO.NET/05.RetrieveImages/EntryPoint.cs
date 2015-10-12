// 05.Write a program that retrieves the images for all categories in the Northwind database
// and stores them as JPG files in the file system.

namespace _05.RetrieveImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var connection = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT Picture FROM Categories", connection);
                var reader = command.ExecuteReader();

                var pictureCount = 0;

                while (reader.Read())
                {
                    byte[] firstImage = (byte[])reader["Picture"];
                    WriteImagesToFile(firstImage, "../../images/Picture" + pictureCount + ".jpg");
                    pictureCount += 1;
                }

                Console.WriteLine("The images was successfuly sotred in '../images/'");
                
            }
        }

        private static void WriteImagesToFile(byte[] image, string imageName)
        {
            const int oleMetaPictStartPosition = 78;

            FileStream stream = File.OpenWrite(imageName);

            using (stream)
            {
                stream.Write(image, oleMetaPictStartPosition, image.Length - oleMetaPictStartPosition);
            }
        }
    }
}
