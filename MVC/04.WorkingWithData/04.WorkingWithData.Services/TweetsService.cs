namespace _04.WorkingWithData.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;
    using Contracts;
    using Models;
    using System;

    public class TweetsService : ITweetsService
    {
        private const int LatestTweetsCount = 5;
        private IRepository<Tweet> tweets;
        private IRepository<Tag> tags;

        public TweetsService(IRepository<Tweet> tweets, IRepository<Tag> tags)
        {
            this.tweets = tweets;
            this.tags = tags;
        }

        public IQueryable<Tweet> GetAll()
        {
            return this.tweets.All();
        }

        public IQueryable<Tweet> GetByTag(string tagName)
        {
            var tag = this.tags
                 .All()
                 .FirstOrDefault(t => t.Name == tagName);

            if (tag == null)
            {
                return new List<Tweet>().AsQueryable();
            }

            return tag.Tweets.AsQueryable();
        }

        public IQueryable<Tweet> GetLatest()
        {
            return this.tweets
                .All()
                .OrderByDescending(t => t.CreatedOn)
                .Take(LatestTweetsCount);
        }

        public void CreateTweet(string content, string userId)
        {
            var words = content
                .Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var tweetToAdd = new Tweet()
            {
                Content = content,
                CreatedOn = DateTime.Now,
                UserId = userId
            };

            foreach (var word in words)
            {
                if (word[0] == '#')
                {
                    var tagName = word.Substring(1, word.Length - 1);
                    var tag = this.tags.All().FirstOrDefault(t => t.Name == tagName);

                    Tag tagToAdd;

                    if (this.tags.All().Any(t => t.Name == tagName))
                    {
                        tagToAdd = this.tags.All().FirstOrDefault(t => t.Name == tagName);
                    }

                    else
                    {
                        tagToAdd = new Tag()
                        {
                            Name = tagName
                        };
                    }

                    tweetToAdd.Tags.Add(tagToAdd);
                }
            }

            this.tweets.Add(tweetToAdd);
            this.tweets.SaveChanges();
        }

        public void UpdateTweet(Tweet tweet)
        {
            var tweetToUpdate = this.tweets.GetById(tweet.Id);

            tweetToUpdate.CreatedOn = tweet.CreatedOn;
            tweetToUpdate.Content = tweet.Content;
            tweetToUpdate.ImageUrl = tweet.ImageUrl;

            this.tweets.Update(tweetToUpdate);
            this.tweets.SaveChanges();
        }

        public void Destroy(int tweetId)
        {
            this.tweets.Delete(tweetId);
            this.tweets.SaveChanges();
        }
    }
}
