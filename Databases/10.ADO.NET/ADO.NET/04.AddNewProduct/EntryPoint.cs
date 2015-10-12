// 04.Write a method that adds a new product in the products table in the Northwind database.
// Use a parameterized SQL command.

namespace _04.AddNewProduct
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
                    ("INSERT INTO Products (ProductName, Discontinued) VALUES " + 
                    "(@name, @discontinued)", connection);

                command.Parameters.AddWithValue("@name", "New Product");
                command.Parameters.AddWithValue("@discontinued", 0);

                command.ExecuteNonQuery();
            }
        }
    }
}
