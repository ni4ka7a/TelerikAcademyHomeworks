namespace AudioSystem.Api.Models.Countries
{
    using System.ComponentModel.DataAnnotations;

    public class CountryRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}