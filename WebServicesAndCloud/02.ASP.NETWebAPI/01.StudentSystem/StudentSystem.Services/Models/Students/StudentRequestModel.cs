namespace StudentSystem.Services.Models.Students
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using StudentsStystem.Models;

    public class StudentRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string FacultyNumber { get; set; }

        public virtual ICollection<int> CourseIds { get; set; }

        public virtual ICollection<int> HomeworkIds { get; set; }
    }
}