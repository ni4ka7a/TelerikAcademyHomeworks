namespace _04.WorkingWithData.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using System.Data.Entity;
    public class TwitterDbContext : IdentityDbContext<User>, ITwitterDbContext
    {
        public TwitterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }
    }
}
