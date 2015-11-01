namespace StudentSystem.Services.Models.Courses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StudentsStystem.Models;

    public class CourseRequestModel
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Materials { get; set; }

        public ICollection<int> StudentIds { get; set; }

        public virtual ICollection<int> HomeworkIds { get; set; }
    }
}