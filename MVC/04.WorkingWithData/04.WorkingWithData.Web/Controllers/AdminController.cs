namespace _04.WorkingWithData.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Newtonsoft.Json;

    using Services.Contracts;
    using ViewModels;
    using System.Collections.Generic;
    using Models;
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ITweetsService tweets;

        public AdminController(ITweetsService tweets)
        {
            this.tweets = tweets;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TweetsRead([DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(this.tweets
                .GetAll()
                .Select(t => new TweetViewModel()
                {
                    Id = t.Id,
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    Username = t.User.UserName,
                })
                .ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult TweetsUpdate([DataSourceRequest] DataSourceRequest request, TweetViewModel tweetToUpdate)
        {

            if (tweetToUpdate != null)
            {
                var tweet = new Tweet()
                {
                    Id = tweetToUpdate.Id,
                    Content = tweetToUpdate.Content,
                    CreatedOn = tweetToUpdate.CreatedOn,
                    ImageUrl = tweetToUpdate.ImageUrl
                };

                this.tweets.UpdateTweet(tweet);
            }

            return this.Json(new[] { tweetToUpdate }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult TweetsDestroy([DataSourceRequest] DataSourceRequest request, TweetViewModel tweetToDelete)
        {
            if (tweetToDelete != null)
            {
                this.tweets.Destroy(tweetToDelete.Id);
            }

            return Json(new[] { tweetToDelete }.ToDataSourceResult(request, ModelState));
        }
    }
}