namespace AudioSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AudioSystem.Models;
    using Data;
    using Models.Artists;
    using StudentsSystem.Data;

    public class AritstsController : ApiController
    {
        private AudioSystemDbContext db;
        private IRepository<Country> countries;
        private IRepository<Song> songs;
        private IRepository<Album> albums;
        private IRepository<Artist> artists;

        public AritstsController()
        {
            this.db = new AudioSystemDbContext();
            this.countries = new EfGenericRepository<Country>(this.db);
            this.songs = new EfGenericRepository<Song>(this.db);
            this.albums = new EfGenericRepository<Album>(this.db);
            this.artists = new EfGenericRepository<Artist>(this.db);
        }

        public IHttpActionResult Get()
        {
            var artists = this.artists
                .All()
                .Select(a => new ArtistResponseModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country.CountryName,
                    DateOfBirth = a.DateOfBirth,
                    Albums = a.Albums.Select(al => al.Title).ToList(),
                    Songs = a.Songs.Select(s => s.Title).ToList()
                })
                .ToList();

            return this.Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.artists
                .All()
                 .Select(a => new ArtistResponseModel
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Country = a.Country.CountryName,
                     DateOfBirth = a.DateOfBirth,
                     Albums = a.Albums.Select(al => al.Title).ToList(),
                     Songs = a.Songs.Select(s => s.Title).ToList()
                 })
                 .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return this.NotFound();
            }

            return this.Ok(artist);
        }

        public IHttpActionResult Post(ArtistRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var countryExists = this.countries
                .All()
                .Any(c => c.Id == model.CountryId);

            if (!countryExists)
            {
                return this.BadRequest("Invalid country id");
            }

            var artistToAdd = new Artist()
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                CountryId = model.CountryId
            };

            foreach (var songId in model.SongIds)
            {
                var currentSong = this.songs
                    .All()
                    .FirstOrDefault(s => s.Id == songId);

                if (currentSong != null)
                {
                    artistToAdd.Songs.Add(currentSong);
                }
            }

            foreach (var albumId in model.AlbumIds)
            {
                var currentAlbum = this.albums
                    .All()
                    .FirstOrDefault(a => a.Id == albumId);

                if (currentAlbum != null)
                {
                    artistToAdd.Albums.Add(currentAlbum);
                }
            }

            this.artists.Add(artistToAdd);
            this.artists.SaveChanges();

            return this.Ok("The artist was successfully added.");
        }

        public IHttpActionResult Put(int id, ArtistRequestModel model)
        {
            var artistToUpdate = this.artists
                .All()
                .FirstOrDefault(a => a.Id == id);

            if (artistToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var countryExists = this.countries
                .All()
                .Any(c => c.Id == model.CountryId);

            if (!countryExists)
            {
                return this.BadRequest("Invalid country id");
            }

            artistToUpdate.Name = model.Name;
            artistToUpdate.CountryId = model.CountryId;
            artistToUpdate.DateOfBirth = model.DateOfBirth;

            foreach (var songId in model.SongIds)
            {
                var currentSong = this.songs
                    .All()
                    .FirstOrDefault(s => s.Id == songId);

                if (currentSong != null)
                {
                    artistToUpdate.Songs.Add(currentSong);
                }
            }

            foreach (var albumId in model.AlbumIds)
            {
                var currentAlbum = this.albums
                    .All()
                    .FirstOrDefault(a => a.Id == albumId);

                if (currentAlbum != null)
                {
                    artistToUpdate.Albums.Add(currentAlbum);
                }
            }

            this.artists.SaveChanges();
            return this.Ok("The artist was successfully updated.");
        }

        public IHttpActionResult Delete(int id)
        {
            var artistExists = this.artists
                .All()
                .Any(a => a.Id == id);

            if (!artistExists)
            {
                return this.NotFound();
            }

            this.artists.Delete(id);
            this.artists.SaveChanges();

            return this.Ok("The artist was successfully deleted.");
        }
    }
}