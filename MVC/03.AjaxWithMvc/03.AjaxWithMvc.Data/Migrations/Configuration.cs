namespace _03.AjaxWithMvc.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;
    using System;
    public sealed class Configuration : DbMigrationsConfiguration<_03.AjaxWithMvc.Data.MoviesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_03.AjaxWithMvc.Data.MoviesDbContext context)
        {
            var databaseIsEmpty = !(context.Movies.Any() && context.People.Any() && context.Studios.Any());

            if (databaseIsEmpty)
            {
                for (int i = 0; i < 5; i++)
                {
                    var studio = new Studio()
                    {
                        Name = $"Studio {i}",
                        Adress = $"Adress {i}"
                    };

                    context.Studios.Add(studio);
                }


                for (int i = 0; i < 15; i++)
                {
                    var person = new Person()
                    {
                        FirstName = $"First name {i}",
                        LastName = $"Last name {i}",
                        Age = i + 18
                    };

                    context.People.Add(person);
                }

                context.SaveChanges();


                var random = new Random();

                var people = context.People.ToList();
                var studios = context.Studios.ToList();

                for (int i = 0; i < 5; i++)
                {
                    var movie = new Movie()
                    {
                        Title = $"Movie {i}",
                        Year = i + 2000,
                        Director = people[random.Next(0, people.Count)],
                        LeadingFemaleRole = people[random.Next(0, people.Count)],
                        LeadingMaleRole = people[random.Next(0, people.Count)],
                        Studio = studios[random.Next(0, studios.Count)]
                    };

                    context.Movies.Add(movie);
                }

                context.SaveChanges();
            }
        }
    }
}
