namespace _04.WorkingWithData.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using ViewModels;
    using Services.Contracts;
    using Microsoft.AspNet.Identity;

    public class TweetsController : Controller
    {
        private ITweetsService tweets;

        public TweetsController(ITweetsService tweets)
        {
            this.tweets = tweets;
        }

        public ActionResult Index()
        {
            var tweets = this.tweets
                .GetAll()
                .OrderByDescending(t => t.CreatedOn)
                .Select(t => new TweetViewModel()
                {
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    Username = t.User.UserName,
                    Tags = t.Tags.Select(tag => new TagViewModel()
                    {
                        Name = tag.Name
                    })
                    .ToList()
                })
                .ToList();

            return this.View(tweets);
        }

        public ActionResult ByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return this.RedirectToAction("Index");
            }

            if (this.HttpContext.Cache[tag] == null)
            {
                var tweets = this.tweets
                    .GetByTag(tag)
                    .OrderByDescending(t => t.CreatedOn)
                    .Select(t => new TweetViewModel()
                    {
                        Content = t.Content,
                        CreatedOn = t.CreatedOn,
                        Username = t.User.UserName,
                        Tags = t.Tags.Select(currnetTag => new TagViewModel()
                        {
                            Name = currnetTag.Name
                        }).ToList()
                    })
                    .ToList();

                this.HttpContext.Cache.Insert(
                    tag,
                    tweets,
                    null,
                    DateTime.Now.AddMinutes(15),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return this.View(this.HttpContext.Cache[tag]);
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public ActionResult AddTweet(InputTweetModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.tweets.CreateTweet(model.Content, this.User.Identity.GetUserId());

            return this.RedirectToAction("Index", "Home");
        }
    }
}