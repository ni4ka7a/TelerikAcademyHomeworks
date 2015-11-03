namespace AudioSystem.ConsoleClient
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    public class Startup
    {
        private const string BaseUri = "http://localhost:50940/";

        public static void Main(string[] args)
        {
            // You need to run the web api from task 2 for this to wokr (you don't say).
            // Dont forget to change the base uri to your localhost port!

            while (true)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Get all songs");
                Console.WriteLine("2.Post new Artist");
                Console.WriteLine("3.Update existing country");
                Console.WriteLine("4.Delete the first album");

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        GetSongs("api/songs");
                        break;

                    case 2:
                        PostArtist("api/artists");
                        break;

                    case 3:
                        PutCountry("api/countries/1");
                        break;

                    case 4:
                        DeleteAlbum("api/albums/1");
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void GetSongs(string route)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = httpClient.GetAsync(route).Result;
                Console.WriteLine("Songs:");
                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
        }

        private static void PostArtist(string route)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var json = JObject.Parse(
                    "{\"Name\": \"Stamat\"" +
                    "\"DateOfBirth\": \"01.05.2000\"" +
                    "\"CountryId\": 1" +
                    "\"AlbumIds\": \"[]\"" +
                    "\"SongIds \": \"[]\"}");

                var response = httpClient.PostAsync(
                    route,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json")).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
        }

        private static void PutCountry(string route)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var json = JObject.Parse("{\"Name\": \"Italy\"}");

                var response = httpClient.PostAsync(
                    route,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json")).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
        }

        private static void DeleteAlbum(string route)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = httpClient.DeleteAsync(route).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync());
            }
        }
    }
}
