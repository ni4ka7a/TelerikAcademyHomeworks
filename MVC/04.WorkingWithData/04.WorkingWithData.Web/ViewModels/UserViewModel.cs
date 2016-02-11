namespace _04.WorkingWithData.Web.ViewModels
{
    using System.Collections.Generic;

    public class UserViewModel
    {
        public string Username { get; set; }

        public ICollection<TweetViewModel> MyTweets { get; set; }
    }
}