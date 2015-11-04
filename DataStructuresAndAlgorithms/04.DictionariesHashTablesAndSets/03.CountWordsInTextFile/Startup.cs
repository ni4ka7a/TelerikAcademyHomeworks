namespace _03.CountWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var inputText = File.ReadAllText("../../words.txt").Split(new char[] { ' ', '.', '!', '?', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var occurrences = new Dictionary<string, int>();

            foreach (var word in inputText)
            {
                if (occurrences.ContainsKey(word.ToLower()))
                {
                    occurrences[word.ToLower()] += 1;
                }
                else
                {
                    occurrences.Add(word.ToLower(), 1);
                }
            }

            var sortedWords = occurrences
                .OrderBy(o => o.Value)
                .ToList();

            foreach (var item in sortedWords)
            {
                Console.WriteLine("{0} => {1}", item.Key, item.Value);
            }
        }
    }
}
