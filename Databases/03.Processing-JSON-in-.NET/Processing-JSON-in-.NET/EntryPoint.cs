namespace Processing_JSON_in_.NET
{
    using System;
    using System.Net;
    using System.Linq;
    using Newtonsoft.Json;
    using System.Xml;
    using Newtonsoft.Json.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.IO;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            var xmlContent = DownLoadRssFeed(rssUrl);

            var json = ConvertXmlToJson(xmlContent);

            var titles = GetVideoTitles(json);

            Console.WriteLine("Video Titles:");
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            var videos = ParseJsonToVideoObjects(json);

            GenerateHtml(videos, json);

        }

        private static string DownLoadRssFeed(string url)
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData(url);
            var content = Encoding.UTF8.GetString(data);

            return content;
        }

        private static string ConvertXmlToJson(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var json = JsonConvert.SerializeObject(doc, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        private static IEnumerable<JToken> GetVideoTitles(string json)
        {
            var jObj = JObject.Parse(json);

            var titles = jObj["feed"]["entry"]
                .Select(e => e["title"]);

            return titles;
        }

        private static IEnumerable<Video> ParseJsonToVideoObjects(string json)
        {
            var jObj = JObject.Parse(json);


            var videos = jObj["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        private static void GenerateHtml(IEnumerable<Video> videos, string path)
        {
            var outputText = new StringBuilder();
            outputText.Append("<!DOCTYPE html><html><head><title>TelerikAcademy Chanel</title></head><body>");

            foreach (var video in videos)
            {
                outputText.AppendFormat("<div><iframe width=\"420\" height=\"345\" " +
                    "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" </iframe>" +
                     "<h3>{2}</h3><a href=\"{0}\">Go to YouTube</a></div>", video.Link.Href, video.Id, video.Title);
            }

            outputText.Append("</body></html>");

            File.WriteAllText("../../index.html", outputText.ToString());
        }
    }
}
