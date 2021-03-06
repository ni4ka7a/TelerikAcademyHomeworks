﻿namespace StudentsStystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string FacultyNumber { get; set; }

        public virtual ICollection<Course> Courses 
        {
            get { return this.courses; }

            set { this.courses = value; } 
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }

            set { this.homeworks = value; }
        }
    }
}
