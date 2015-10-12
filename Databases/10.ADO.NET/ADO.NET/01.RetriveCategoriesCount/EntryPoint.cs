// 01.Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.

namespace _01.RetriveCategoriesCount
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
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                int categoriesCount = (int)command.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}
