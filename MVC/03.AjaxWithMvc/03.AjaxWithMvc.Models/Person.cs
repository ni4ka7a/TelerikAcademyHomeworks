namespace _03.AjaxWithMvc.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Range(1, 130)]
        public int Age { get; set; }

        public Gender Gender { get; set; }
    }
}
