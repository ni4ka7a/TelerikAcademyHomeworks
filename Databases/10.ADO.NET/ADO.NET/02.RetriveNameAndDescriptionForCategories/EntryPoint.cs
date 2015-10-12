// 02.Write a program that retrieves the name and description of all categories in the Northwind DB.

namespace _02.RetriveNameAndDescriptionForCategories
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var connection = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");

            connection.Open();

            Console.WriteLine("Name and Description for all categories:\n");
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0} -> {1}", reader["CategoryName"], reader["Description"]);
                }
            }
        }
    }
}
