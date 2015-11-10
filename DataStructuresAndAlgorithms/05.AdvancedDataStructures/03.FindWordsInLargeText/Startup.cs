namespace _03.FindWordsInLargeText
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    using Trie;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // Trie implementation from https://github.com/rmandvikar/csharp-trie
            Console.WriteLine("The program read all words from 'text.txt',");
            Console.WriteLine("adds them in a Trie and prnt the first 1000 words");
            Console.WriteLine("along with the occurrences of each word");
            Console.WriteLine("Press any key to begin..");
            Console.ReadKey();

            ITrie trie = TrieFactory.CreateTrie();
            var reader = new StreamReader("../../text.txt");

            ReadWordsFromText(reader, trie);
            
            var counter = 0;
            foreach (var currentWord in trie.GetWords())
            {
                counter++;

                if (counter == 1000)
                {
                    break;
                }

                var wordCounter = trie.WordCount(currentWord);
                Console.WriteLine("{0} - {1}", currentWord, wordCounter);
            }
        }

        private static void ReadWordsFromText(StreamReader reader, ITrie trie)
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var matches = Regex.Matches(line, @"\w+");

                foreach (var match in matches)
                {
                    trie.AddWord(match.ToString());
                }
            }
        }
    }
}
