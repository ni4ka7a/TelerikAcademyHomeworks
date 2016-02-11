namespace _04.WorkingWithData.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_04.WorkingWithData.Data.TwitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "admin@admin.com" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admin");

                this.SeedTags(context);
                this.SeedTweets(context);
            }
        }

        private void SeedTweets(TwitterDbContext context)
        {
            if (!context.Tweets.Any())
            {
                var tags = context.Tags.ToList();
                var user = context.Users.FirstOrDefault();
                var random = new Random();

                context.Tweets.Add(new Tweet()
                {
                    Content = "I love code #fun",
                    CreatedOn = DateTime.Now,
                    User = user,
                    Tags = new List<Tag>() { tags.FirstOrDefault(t => t.Name == "fun") }
                });

                context.Tweets.Add(new Tweet()
                {
                    Content = "#programming Sunny day behind the PC ",
                    CreatedOn = DateTime.Now,
                    User = user,
                    Tags = new List<Tag>() { tags.FirstOrDefault(t => t.Name == "programming") }
                });

                context.Tweets.Add(new Tweet()
                {
                    Content = "My first app #helloworld",
                    CreatedOn = DateTime.Now,
                    User = user,
                    Tags = new List<Tag>() { tags.FirstOrDefault(t => t.Name == "helloworld") }
                });

            }
        }

        private void SeedTags(TwitterDbContext context)
        {
            if (!context.Tags.Any())
            {
                context.Tags.Add(new Tag()
                {
                    Name = "code"
                });

                context.Tags.Add(new Tag()
                {
                    Name = "programming"
                });

                context.Tags.Add(new Tag()
                {
                    Name = "fun"
                });

                context.Tags.Add(new Tag()
                {
                    Name = "helloworld"
                });

                context.SaveChanges();
            }
        }
    }
}
