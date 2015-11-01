namespace AudioSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AudioSystem.Models;
    using Data;
    using Models.Albums;
    using StudentsSystem.Data;

    public class AlbumsController : ApiController
    {
        private AudioSystemDbContext db;
        private IRepository<Song> songs;
        private IRepository<Album> albums;
        private IRepository<Artist> artists;

        public AlbumsController()
        {
            this.db = new AudioSystemDbContext();
            this.songs = new EfGenericRepository<Song>(this.db);
            this.albums = new EfGenericRepository<Album>(this.db);
            this.artists = new EfGenericRepository<Artist>(this.db);
        }

        public IHttpActionResult Get()
        {
            var albums = this.albums
                .All()
                .Select(a => new AlbumResponseModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    ProducerName = a.ProducerName,
                    PublishYear = a.PublishYear,
                    Artists = a.Artists.Select(ar => ar.Name).ToList(),
                    Songs = a.Songs.Select(s => s.Title).ToList()
                })
                .ToList();

            return this.Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.albums
                .All()
                .Select(a => new AlbumResponseModel
                {
                    Title = a.Title,
                    ProducerName = a.ProducerName,
                    PublishYear = a.PublishYear,
                    Artists = a.Artists.Select(ar => ar.Name).ToList(),
                    Songs = a.Songs.Select(s => s.Title).ToList()
                })
                .FirstOrDefault(a => a.Id == id);

            return this.Ok(album);
        }

        public IHttpActionResult Post(AlbumRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumToAdd = new Album()
            {
                Title = model.Title,
                ProducerName = model.ProducerName,
                PublishYear = model.PublishYear
            };

            foreach (var songId in model.SongIds)
            {
                var currentSong = this.songs
                    .All()
                    .FirstOrDefault(s => s.Id == songId);

                if (currentSong != null)
                {
                    albumToAdd.Songs.Add(currentSong);
                }
            }

            foreach (var artistId in model.ArtistIds)
            {
                var currentArtist = this.artists
                    .All()
                    .FirstOrDefault(a => a.Id == artistId);

                if (currentArtist != null)
                {
                    albumToAdd.Artists.Add(currentArtist);
                }
            }

            this.albums.Add(albumToAdd);
            this.albums.SaveChanges();

            return this.Ok("The album was successfully added.");
        }

        public IHttpActionResult Put(int id, AlbumRequestModel model)
        {
            var albumToUpdate = this.albums
                .All()
                .FirstOrDefault(a => a.Id == id);

            if (albumToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            albumToUpdate.Title = model.Title;
            albumToUpdate.ProducerName = model.ProducerName;
            albumToUpdate.PublishYear = model.PublishYear;

            foreach (var songId in model.SongIds)
            {
                var currentSong = this.songs
                    .All()
                    .FirstOrDefault(s => s.Id == songId);

                if (currentSong != null)
                {
                    albumToUpdate.Songs.Add(currentSong);
                }
            }

            foreach (var artistId in model.ArtistIds)
            {
                var currentArtist = this.artists
                    .All()
                    .FirstOrDefault(a => a.Id == artistId);

                if (currentArtist != null)
                {
                    albumToUpdate.Artists.Add(currentArtist);
                }
            }

            this.albums.SaveChanges();

            return this.Ok("The album was successfully updated.");
        }

        public IHttpActionResult Delete(int id)
        {
            var albumExists = this.albums
                .All()
                .Any(a => a.Id == id);

            if (!albumExists)
            {
                return this.NotFound();
            }

            this.albums.Delete(id);
            return this.Ok("The album was successfully deleted.");
        }
    }
}