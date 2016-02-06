namespace _03.AjaxWithMvc.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Contracts;
    using Models;
    using ViewModels;

    public class MoviesController : Controller
    {
        private IMoviesService movies;
        private IStudiosService studios;
        private IPeopleService people;

        public MoviesController(IMoviesService movies, IStudiosService studios, IPeopleService people)
        {
            this.movies = movies;
            this.studios = studios;
            this.people = people;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllMovies()
        {
            var movies = this.movies.GetAll().ToList();
            return this.PartialView("_AllMoviesPartial", movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = this.movies
                .GetAll()
                .Where(m => m.Id == id)
                .Select(m => new MovieDetailsViewModel()
                {
                    Title = m.Title,
                    Year = m.Year,
                    Director = m.Director.FirstName + " " + m.Director.LastName,
                    LeadingMaleRole = m.LeadingMaleRole.FirstName + " " + m.LeadingMaleRole.LastName,
                    LeadingFemaleRole = m.LeadingFemaleRole.FirstName + " " + m.LeadingFemaleRole.LastName
                })
                .FirstOrDefault();

            return this.PartialView("_MovieDetailsPartial", movie);
        }

        public ActionResult EditMovie(int id)
        {
            var movie = this.movies
                .GetAll()
                .Where(m => m.Id == id)
                .Select(m => new EditMovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    StudioId = m.StudioId,
                    DirectorId = m.DirectorId,
                    LeadingFemaleRoleId = m.LeadingFemaleRoleId,
                    LeadingMaleRoleId = m.LeadingMaleRoleId
                })
                .FirstOrDefault();

            movie.Studios = this.studios
                 .GetAll()
                 .Select(s => new SelectListItem()
                 {
                     Value = s.Id.ToString(),
                     Text = s.Name
                 })
                 .ToList();

            movie.People = this.people
                .GetAll()
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.FirstName + " " + p.LastName
                })
                .ToList();


            return this.PartialView("_EditMoviePartial", movie);
        }

        public ActionResult UpdateMovie(int id, Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("AllMovies");
            }

            this.movies.Update(movie);

            return this.RedirectToAction("AllMovies");
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id)
        {
            this.movies.Delete(id);

            return this.RedirectToAction("AllMovies");
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            var addMovieViewModel = new AddMovieViewModel();
            addMovieViewModel.People = this.people
                 .GetAll()
                 .Select(p => new SelectListItem()
                 {
                     Text = p.FirstName + p.LastName,
                     Value = p.Id.ToString()
                 })
                 .ToList();

            addMovieViewModel.Studios = this.studios
                .GetAll()
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
                .ToList();

            return this.PartialView("_AddMoviePartial", addMovieViewModel);
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            if (this.ModelState.IsValid)
            {
                this.movies.Create(movie);
            }

            return this.RedirectToAction("AllMovies");
        }

    }
}