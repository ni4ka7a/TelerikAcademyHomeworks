// 03.Write a program that retrieves from the Northwind database all product categories
// and the names of the products in each category.

namespace _03.RetriveProductsInEachCategory
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
                SqlCommand command = new SqlCommand
                    ("SELECT c.CategoryName, p.ProductName" +
                     " FROM Products p JOIN Categories c" +
                     " ON c.CategoryID = p.CategoryID" +
                     " GROUP BY c.CategoryName, p.ProductName", connection);

                var reader = command.ExecuteReader();

                var lastCategoryName = string.Empty;

                while (reader.Read())
                {
                    if (reader["CategoryName"].ToString() != lastCategoryName)
                    {
                        Console.WriteLine("\nCategory {0}", reader["CategoryName"]);
                    }

                    Console.WriteLine("\t{0}", reader["ProductName"]);

                    lastCategoryName = reader["CategoryName"].ToString();
                }
            }
        }
    }
}
