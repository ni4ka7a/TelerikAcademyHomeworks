namespace _04.WorkingWithData.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Tag
    {
        private ICollection<Tweet> tweets;

        public Tag()
        {
            this.tweets = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }

            set { this.tweets = value; }
        }
    }
}
