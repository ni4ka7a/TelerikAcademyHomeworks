namespace _03.AjaxWithMvc.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }

        public int Year { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public int DirectorId { get; set; }

        public virtual Person Director { get; set; }

        public int LeadingMaleRoleId { get; set; }

        public virtual Person LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }

        public virtual Person LeadingFemaleRole { get; set; }
    }
}
