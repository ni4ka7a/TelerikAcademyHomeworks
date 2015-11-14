namespace StringsOperations.HostingClient
{
    using System;
    using StringsOperations;
    using System.ServiceModel;

    public class Startup
    {
        public static void Main(string[] args)
        {
            // Run as administrator!!!
            var url = new Uri("http://127.0.0.1:9876");

            ServiceHost host = new ServiceHost(typeof(StringsService), url);
            host.Open();

            Console.WriteLine("Service working on {0}", url);
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();

            host.Close();
        }
    }
}
