namespace _03.AjaxWithMvc.Services
{
    using System;
    using System.Linq;

    using Contracts;
    using Data;
    using Models;

    public class MoviesService : IMoviesService
    {
        private IRepository<Movie> movies;

        public MoviesService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public Movie GetById(int id)
        {
            return this.movies.GetById(id);
        }

        public void Update(Movie movieToUpdate)
        {
            this.movies.Update(movieToUpdate);
            this.movies.SaveChanges();
        }
    }
}
