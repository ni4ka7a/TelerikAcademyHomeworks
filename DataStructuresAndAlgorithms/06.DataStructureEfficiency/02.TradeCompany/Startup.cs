namespace _02.TradeCompany
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var articles = GenerateArticles(50000);

            var articlesInRange = articles.Range(4m, true, 50m, true);

            foreach (var item in articlesInRange)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.FirstOrDefault().Title);
            }
        }

        private static OrderedMultiDictionary<decimal, Article> GenerateArticles(int numberOfArticles)
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(true);

            for (int i = 0; i < numberOfArticles; i++)
            {
                var article = new Article(
                    i + string.Empty + i + 1 + string.Empty + i + 2,
                    "Vendor " + i,
                    "Title " + i,
                    (decimal)(i + Math.Sqrt(i)));

                articles.Add(article.Price, article);
            }

            return articles;
        }
    }
}
