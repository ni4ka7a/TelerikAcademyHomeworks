namespace StringsOperations.ConsoleClient
{
    using System;

    using StringsService;

    public class Startup
    {
        public static void Main(string[] args)
        {
            StringsServiceClient client = new StringsServiceClient();

            var firstString = "hello";
            var secondString = "hello pesho, hello";

            var result = client.NumberOfContains(firstString, secondString);
            Console.WriteLine(result);
        }
    }
}
