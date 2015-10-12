// 10.Re-implement the previous task with SQLite embedded DB

namespace _10.BooksTableInSqlite
{
    using System;
    using System.Data;
    using System.Data.SQLite;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var connection = new SQLiteConnection("Data Source=../../db.sqlite;Version=3;");

            while (true)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.List all books.");
                Console.WriteLine("2.FInd book by title.");
                Console.WriteLine("3.Add new book.");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": ListAllBooks(connection);
                        break;
                    case "2": FindBookByName(connection);
                        break;
                    case "3": AddNewBook(connection);
                        break;
                    default: Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void AddNewBook(SQLiteConnection connection)
        {
            Console.Write("\nEnter book title:");
            var title = Console.ReadLine();

            Console.Write("\nEnter book Author:");
            var author = Console.ReadLine();

            Console.Write("\nEnter book ISBN:");
            var isbn = Console.ReadLine();

            connection.Open();

            var command = new SQLiteCommand("INSERT INTO books (Title, Author, PublishDate, Isbn) VALUES(@title, @author, @publishDate, @isbn)", connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@publishDate", DateTime.Now);
            command.Parameters.AddWithValue("@isbn", isbn);

            command.ExecuteNonQuery();
            Console.WriteLine("\nThe book was added successfully");

            connection.Close();
            Console.WriteLine("\nPress any key to continiue..");
            Console.ReadLine();
            Console.Clear();
        }

        private static void FindBookByName(SQLiteConnection connection)
        {
            Console.Write("Enter patter for search:");
            var inputPattern = Console.ReadLine();
            inputPattern = ValidatePattern(inputPattern);

            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM books WHERE TITLE LIKE @pattern", connection);
            command.Parameters.AddWithValue("@pattern", inputPattern);
            var reader = command.ExecuteReader();

            Console.WriteLine("Books: Title, Author, PublishDate, ISBN:\n");

            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["PublishDate"], reader["Isbn"]);
            }

            connection.Close();
            Console.WriteLine("\nPress any key to continiue..");
            Console.ReadLine();
            Console.Clear();
        }

        private static void ListAllBooks(SQLiteConnection connection)
        {
            connection.Open();

            var command = new SQLiteCommand("SELECT * FROM books", connection);
            var reader = command.ExecuteReader();

            Console.WriteLine("Books: Title, Author, PublishDate, ISBN:\n");

            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["PublishDate"], reader["Isbn"]);
            }
            connection.Close();

            Console.WriteLine("\nPress any key to continiue..");
            Console.ReadLine();
            Console.Clear();
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
