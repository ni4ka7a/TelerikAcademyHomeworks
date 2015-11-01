namespace AudioSystem.Api.Models.Artists
{
    using System;
    using System.Collections.Generic;

    public class ArtistResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public virtual ICollection<string> Albums { get; set; }

        public virtual ICollection<string> Songs { get; set; }
    }
}