namespace AudioSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AudioSystem.Models;
    using Data;
    using Models.Songs;
    using StudentsSystem.Data;

    public class SongsController : ApiController
    {
        private AudioSystemDbContext db;
        private IRepository<Song> songs;
        private IRepository<Album> albums;
        private IRepository<Artist> artists;

        public SongsController()
        {
            this.db = new AudioSystemDbContext();
            this.songs = new EfGenericRepository<Song>(this.db);
            this.albums = new EfGenericRepository<Album>(this.db);
            this.artists = new EfGenericRepository<Artist>(this.db);
        }

        public IHttpActionResult Get()
        {
            var songs = this.songs
                .All()
                .Select(s => new SongResponseModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Genre = s.Genre,
                    PublishYear = s.PublishYear,
                    Artist = s.Artist.Name,
                    Album = s.Album.Title
                })
                .ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            var song = this.songs
                .All()
                .Select(s => new SongResponseModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Genre = s.Genre,
                    PublishYear = s.PublishYear,
                    Artist = s.Artist.Name,
                    Album = s.Album.Title
                })
                .FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }

        public IHttpActionResult Post(SongRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumExists = this.albums
                .All()
                .Any(a => a.Id == model.AlbumId);

            var artistExist = this.artists
                .All()
                .Any(a => a.Id == model.ArtistId);

            if (!(albumExists && artistExist))
            {
                return this.BadRequest("Invalid albumID or artistID");
            }

            this.songs.Add(new Song
            {
                Title = model.Title,
                Genre = model.Genre,
                PublishYear = model.PublishYear,
                ArtistId = model.ArtistId,
                AlbumId = model.AlbumId
            });

            this.songs.SaveChanges();
            return this.Ok("The song was successfully added.");
        }

        public IHttpActionResult Put(int id, SongRequestModel model)
        {
            var songToUpdate = this.songs
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (songToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumExists = this.albums
                .All()
                .Any(a => a.Id == model.AlbumId);

            var artistExist = this.artists
                .All()
                .Any(a => a.Id == model.ArtistId);

            if (!(albumExists && artistExist))
            {
                return this.BadRequest("Invalid albumID or artistID");
            }

            songToUpdate.Title = model.Title;
            songToUpdate.Genre = model.Genre;
            songToUpdate.PublishYear = model.PublishYear;
            songToUpdate.ArtistId = model.ArtistId;
            songToUpdate.AlbumId = model.AlbumId;

            this.songs.SaveChanges();
            return this.Ok("The song was updated successfully");
        }

        public IHttpActionResult Delete(int id)
        {
            var songExists = this.songs
                .All()
                .Any(s => s.Id == id);

            if (!songExists)
            {
                return this.NotFound();
            }

            this.songs.Delete(id);
            this.songs.SaveChanges();
            return this.Ok("The song was deleted successfully");
        }
    }
}