namespace StudentSystem.Services.Models.Students
{
    using System.Collections.Generic;

    using StudentsStystem.Models;

    public class StudentResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}