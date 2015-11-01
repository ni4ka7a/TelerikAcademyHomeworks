namespace AudioSystem.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class Startup
    {
        private const string BaseUri = "http://localhost:50940/";

        public static void Main(string[] args)
        {
            // You need to run the web api from task 2 for this to wokr (you don't say).
            // Dont forget to change the base uri to your localhost port!

            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/songs").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsStringAsync().Result;

                foreach (var song in songs)
                {
                    Console.WriteLine(songs);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Console.ReadLine();
        }
    }
}
