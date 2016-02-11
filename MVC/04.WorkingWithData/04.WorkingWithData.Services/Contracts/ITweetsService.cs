namespace _04.WorkingWithData.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface ITweetsService
    {
        IQueryable<Tweet> GetAll();

        IQueryable<Tweet> GetLatest();

        IQueryable<Tweet> GetByTag(string tagName);

        void CreateTweet(string content, string userId);

        void UpdateTweet(Tweet tweet);

        void Destroy(int tweetId);
    }
}
