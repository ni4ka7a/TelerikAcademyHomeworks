namespace _02.Todos.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Body { get; set; }

        public DateTime LastModified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
