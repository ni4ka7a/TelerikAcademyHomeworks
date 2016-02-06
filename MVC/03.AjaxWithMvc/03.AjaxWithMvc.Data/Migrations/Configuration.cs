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
                // Add studios
                context.Studios.Add(new Studio()
                {
                    Name = "Dreamworks",
                    Adress = "Some Address 1"
                });

                context.Studios.Add(new Studio()
                {
                    Name = "MGM",
                    Adress = "Some Address 1"
                });

                context.Studios.Add(new Studio()
                {
                    Name = "Sony",
                    Adress = "Some Address 1"
                });

                context.Studios.Add(new Studio()
                {
                    Name = "Time Warner",
                    Adress = "Some Address 1"
                });

                context.Studios.Add(new Studio()
                {
                    Name = "Walt Disney",
                    Adress = "Some Address 1"
                });


                // Add people
                var random = new Random();

                context.People.Add(new Person()
                {
                    FirstName = "Al",
                    LastName = "Pacino",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Robert",
                    LastName = "De Niro",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Jack",
                    LastName = "Nicholson",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Tom",
                    LastName = "Hanks",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Cary",
                    LastName = "Grant",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Johnny",
                    LastName = "Depp",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Morgan",
                    LastName = "Freeman",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Anthony",
                    LastName = "Hopkins",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Brad",
                    LastName = "Pitt",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Russell",
                    LastName = "Crowe",
                    Age = random.Next(18, 100),
                    Gender = Gender.Male
                });

                context.People.Add(new Person()
                {
                    FirstName = "Scarlett",
                    LastName = "Johansson",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Jessica",
                    LastName = "Alba",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Natalie",
                    LastName = "Portman",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Mila",
                    LastName = "Kunis",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Jessica",
                    LastName = "Biel",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Megan",
                    LastName = "Fox",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Monica",
                    LastName = "Bellucci",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.People.Add(new Person()
                {
                    FirstName = "Jennifer",
                    LastName = "Lawrence",
                    Age = random.Next(18, 100),
                    Gender = Gender.Female
                });

                context.SaveChanges();

                var allPeople = context.People.ToList();
                var males = allPeople.Where(p => p.Gender == Gender.Male).ToList();
                var females = allPeople.Where(p => p.Gender == Gender.Female).ToList();
                var studios = context.Studios.ToList();

                for (int i = 0; i < 5; i++)
                {
                    var movie = new Movie()
                    {
                        Title = $"Movie {i}",
                        Year = i + 2000,
                        Director = allPeople[random.Next(0, allPeople.Count)],
                        LeadingFemaleRole = females[random.Next(0, females.Count)],
                        LeadingMaleRole = males[random.Next(0, males.Count)],
                        Studio = studios[random.Next(0, studios.Count)]
                    };

                    context.Movies.Add(movie);
                }

                context.SaveChanges();
            }
        }
    }
}
