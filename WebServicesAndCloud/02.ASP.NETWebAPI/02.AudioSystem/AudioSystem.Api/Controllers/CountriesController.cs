namespace AudioSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AudioSystem.Models;
    using Data;
    using Models.Countries;
    using StudentsSystem.Data;

    public class CountriesController : ApiController
    {
        private AudioSystemDbContext db;
        private IRepository<Country> countries;

        public CountriesController()
        {
            this.db = new AudioSystemDbContext();
            this.countries = new EfGenericRepository<Country>(this.db);
        }

        public IHttpActionResult Get()
        {
            var contries = this.countries
                .All()
                .Select(c => new CountryResponseModel
                {
                    Id = c.Id,
                    Name = c.CountryName
                })
                .ToList();

            return this.Ok(contries);
        }

        public IHttpActionResult Get(int id)
        {
            var country = this.countries
                .All()
                .Select(c => new CountryResponseModel
                {
                    Id = c.Id,
                    Name = c.CountryName
                })
                .FirstOrDefault(c => c.Id == id);

            if (country == null)
            {
                return this.NotFound();
            }

            return this.Ok(country);
        }

        /// <summary>
        /// Expect CountryRequestModel with valid name.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// If the country is added returns IHttpActionResult with status code 200 OK
        /// If the input data in not in the valid format retunrs  IHttpActionResult with status code 400 Bad Request
        /// </returns>
        public IHttpActionResult Post(CountryRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            this.countries.Add(new Country
            {
                CountryName = model.Name
            });

            this.countries.SaveChanges();
            return this.Ok();
        }

        public IHttpActionResult Put(int id, CountryRequestModel model)
        {
            var countryToUpdate = this.countries
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (countryToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            countryToUpdate.CountryName = model.Name;
            this.countries.SaveChanges();

            return this.Ok("The country was updated successfully");
        }

        public IHttpActionResult Delete(int id)
        {
            var countryExists = this.countries
                .All()
                .Any(c => c.Id == id);

            if (!countryExists)
            {
                return this.NotFound();
            }

            this.countries.Delete(id);
            this.countries.SaveChanges();

            return this.Ok();
        }
    }
}