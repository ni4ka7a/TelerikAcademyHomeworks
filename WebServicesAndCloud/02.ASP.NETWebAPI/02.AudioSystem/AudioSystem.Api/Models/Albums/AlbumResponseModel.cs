namespace AudioSystem.Api.Models.Albums
{
    using System.Collections.Generic;

    public class AlbumResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte PublishYear { get; set; }

        public string ProducerName { get; set; }

        public virtual ICollection<string> Artists { get; set; }

        public virtual ICollection<string> Songs { get; set; }
    }
}
