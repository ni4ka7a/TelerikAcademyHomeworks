// 08.Write a program that reads a string from the console and finds all products that contain this string.
// Ensure you handle correctly characters like ', %, ", \ and _.

namespace _08.SearchInProducts
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

            Console.WriteLine("Enter a pattern for search:");
            var inputPattern = Console.ReadLine();
            inputPattern = ValidatePattern(inputPattern);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT ProductName, UnitPrice FROM Products WHERE ProductName LIKE @pattern", connection);
                command.Parameters.AddWithValue("@pattern", inputPattern);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0} -> {1}", reader["ProductName"], reader["UnitPrice"]);
                }
            }
        }

        private static string ValidatePattern(string pattern)
        {
            var result = pattern;

            var evilHackersCharacters = new string[] { "'", "\"", "%", "\\", "_", "/" };

            foreach (var currentChar in evilHackersCharacters)
            {
                result = result.Replace(currentChar, string.Empty);
            }

            result = "%" + result + "%";
            return result;
        }
    }
}
