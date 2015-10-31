namespace StudentSystem.Services.Models.Homeworks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HomeworkRequestModel
    {
        [Required]
        [MaxLength(150)]
        public string Content { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }
    }
}