namespace StudentSystem.Services.Models.Courses
{
    using System.Collections.Generic;

    using StudentsStystem.Models;

    public class CourseResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}