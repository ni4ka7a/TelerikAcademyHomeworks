using _04.WorkingWithData.Services.Contracts;
using _04.WorkingWithData.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04.WorkingWithData.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITweetsService tweets;

        public HomeController(ITweetsService tweets)
        {
            this.tweets = tweets;
        }

        public ActionResult Index()
        {
            var latestTweets = this.tweets
                .GetLatest()
                .Select(t => new TweetViewModel()
                {
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    Username = t.User.UserName,
                    Tags = t.Tags.Select(tag => new TagViewModel()
                    {
                        Name = tag.Name
                    }).ToList()
                })
                .ToList();

            return View(latestTweets);
        }
    }
}