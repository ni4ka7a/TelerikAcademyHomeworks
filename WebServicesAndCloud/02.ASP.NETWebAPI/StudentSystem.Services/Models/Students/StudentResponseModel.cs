namespace StudentSystem.Services.Models.Students
{
    using System.Collections.Generic;

    using Homeworks;
    using StudentsStystem.Models;

    public class StudentResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FacultyNumber { get; set; }

        public virtual ICollection<string> Courses { get; set; }

        public virtual ICollection<HomeworkResponseModel> Homeworks { get; set; }
    }
}