namespace _01.OrderStudents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var reader = new StreamReader("../../students.txt");

            var courses = ReadStudentsFromText(reader);

            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }

        private static SortedDictionary<string, SortedSet<string>> ReadStudentsFromText(StreamReader reader)
        {
            var students = new SortedDictionary<string, SortedSet<string>>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Split('|');
                var studentFullName = line[0].Trim() + " " + line[1].Trim();
                var courseName = line[2].Trim();

                if (!students.ContainsKey(courseName))
                {
                    students[courseName] = new SortedSet<string>();
                }

                students[courseName].Add(studentFullName);
            }

            return students;
        }
    }
}
