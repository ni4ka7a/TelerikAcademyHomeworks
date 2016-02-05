namespace _03.AjaxWithMvc.Data
{
    using System.Data.Entity;

    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {

        public MoviesDbContext()
            :base("DefaultConnection")
        {
        }

        public IDbSet<Person> People { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Studio> Studios  { get; set; }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Movie>()
            //   .HasRequired(c => c.Director)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Movie>()
            //   .HasRequired(c => c.LeadingFemaleRole)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Movie>()
            //   .HasRequired(c => c.LeadingMaleRole)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);
        }
    }
}
