namespace _04.WorkingWithData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Tag> tags;

        public Tweet()
        {
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }

            set { this.tags = value; }
        }
    }
}
