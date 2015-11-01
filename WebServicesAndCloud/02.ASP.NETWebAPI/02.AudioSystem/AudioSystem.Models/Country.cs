namespace AudioSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CountryName { get; set; }
    }
}
