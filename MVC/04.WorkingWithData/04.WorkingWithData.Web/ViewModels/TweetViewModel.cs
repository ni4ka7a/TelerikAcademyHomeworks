namespace _04.WorkingWithData.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Username { get; set; }

        public string ImageUrl { get; set; }
    }
}