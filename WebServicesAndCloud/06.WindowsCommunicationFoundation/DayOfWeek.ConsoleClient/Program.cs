namespace DayOfWeek.ConsoleClient
{
    using System;

    using DayOfWeekService;

    public class Program
    {
        public static void Main(string[] args)
        {
            DayServiceClient client = new DayServiceClient();

            var result = client.GetDayOfWeek(DateTime.Now);
            Console.WriteLine(result);
        }
    }
}
