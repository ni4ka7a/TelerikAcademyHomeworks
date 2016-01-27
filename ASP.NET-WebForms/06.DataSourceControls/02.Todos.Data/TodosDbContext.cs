namespace _02.Todos.Data
{
    using System.Data.Entity;

    using Models;

    public class TodosDbContext : DbContext
    {
        public TodosDbContext()
            : base("TodosDb")
        {

        }
        public DbSet<Todo> Todos { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
