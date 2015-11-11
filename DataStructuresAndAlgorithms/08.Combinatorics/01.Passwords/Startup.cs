namespace _01.Passwords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var starsCounter = Console.ReadLine().ToCharArray().Where(x => x == '*').Count();
            Console.WriteLine((ulong)Math.Pow(2, starsCounter));
        }
    }
}
