namespace _02.Todos.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TodosDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_02.Todos.Data.TodosDbContext context)
        {

            if (!context.Categories.Any())
            {
                var category = new Category() { Name = "Programming" };
                context.Categories.Add(category);
                context.SaveChanges();
            }

            if (!context.Todos.Any())
            {
                var todo = new Todo()
                {
                    Title = "Code",
                    Body = "Write your homework",
                    LastModified = DateTime.Now,
                    Category = context.Categories.FirstOrDefault()
                };

                context.Todos.Add(todo);
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
