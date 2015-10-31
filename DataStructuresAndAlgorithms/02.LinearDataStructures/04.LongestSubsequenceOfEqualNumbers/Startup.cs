namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sequence = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var sequenceOfEqualNumbers = FindLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine(string.Join(", ", sequenceOfEqualNumbers));
        }

        private static List<int> FindLongestSubsequenceOfEqualNumbers(int[] sequence)
        {
            var bestSequenceLength = 1;
            var currentSequenceLength = 1;
            var repeatingNumber = sequence[0];

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    currentSequenceLength++;
                }
                else
                {
                   currentSequenceLength = 1;
                }

                if (currentSequenceLength > bestSequenceLength)
                {
                    bestSequenceLength = currentSequenceLength;
                    repeatingNumber = sequence[i];
                }
            }

            var sequenceOfEqualNumbers = new List<int>(bestSequenceLength);

            for (int i = 0; i < bestSequenceLength; i++)
            {
                sequenceOfEqualNumbers.Add(repeatingNumber);
            }

            return sequenceOfEqualNumbers;
        }
    }
}
