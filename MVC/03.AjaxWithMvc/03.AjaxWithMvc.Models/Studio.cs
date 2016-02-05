namespace _03.AjaxWithMvc.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Studio
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Adress { get; set; }
    }
}
