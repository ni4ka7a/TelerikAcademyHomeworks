namespace StudentSystem.Services.Models.Courses
{
    using System.Collections.Generic;

    using StudentsStystem.Models;
    using Homeworks;

    public class CourseResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public ICollection<string> Students { get; set; }

        public ICollection<HomeworkResponseModel> Homeworks { get; set; }
    }
}