namespace StudentSystem.Services.Models.Homeworks
{
    using System;

    public class HomeworkResponseModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public DateTime TimeSent { get; set; }
    }
}