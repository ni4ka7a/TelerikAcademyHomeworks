namespace _02.Todos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Todo> todos;

        public Category()
        {
            this.todos = new HashSet<Todo>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Todo> Todos
        {
            get { return this.todos; }

            set { this.todos = value; }
        }
    }
}
