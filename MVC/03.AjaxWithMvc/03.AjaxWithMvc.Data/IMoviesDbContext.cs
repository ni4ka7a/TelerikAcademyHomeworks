namespace _03.AjaxWithMvc.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IMoviesDbContext
    {
        IDbSet<Person> People { get; set; }

        IDbSet<Studio> Studios { get; set; }

        IDbSet<Movie> Movies { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
