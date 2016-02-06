namespace _03.AjaxWithMvc.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IMoviesService
    {
        IQueryable<Movie> GetAll();

        Movie GetById(int id);

        void Update(Movie movieToUpdate);

        void Delete(int id);

        void Create(Movie movie);
    }
}
