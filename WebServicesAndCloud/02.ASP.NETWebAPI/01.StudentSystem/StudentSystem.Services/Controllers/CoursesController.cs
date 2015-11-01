namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models.Homeworks;
    using Services.Models.Courses;
    using StudentsStystem.Models;
    using StudentsSystem.Data;

    public class CoursesController : ApiController
    {
        private StudentsDbContext db;
        private IRepository<Course> courses;
        private IRepository<Student> students;
        private IRepository<Homework> homeworks;

        public CoursesController()
        {
            this.db = new StudentsDbContext();
            this.courses = new EfGenericRepository<Course>(this.db);
            this.students = new EfGenericRepository<Student>(this.db);
            this.homeworks = new EfGenericRepository<Homework>(this.db);
        }

        public IHttpActionResult Get()
        {
            var courses = this.courses
                .All()
                .Select(c => new CourseResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Materials = c.Materials,
                    Students = c.Students.Select(s => s.Name).ToList(),
                    Homeworks = c.Homeworks.Select(h => new HomeworkResponseModel
                    {
                        Content = h.Content,
                        Id = h.Id,
                        TimeSent = h.TimeSent,
                        CourseId = h.CourseId,
                        StudentId = h.StudentId
                    })
                    .ToList()
                })
                .ToList();

            return this.Ok(courses);
        }

        public IHttpActionResult Get(int id)
        {
            var course = this.courses
                .All()
                .Select(c => new CourseResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Materials = c.Materials,
                    Students = c.Students.Select(s => s.Name).ToList(),
                    Homeworks = c.Homeworks.Select(h => new HomeworkResponseModel
                    {
                        Content = h.Content,
                        Id = h.Id,
                        TimeSent = h.TimeSent,
                        CourseId = h.CourseId,
                        StudentId = h.StudentId
                    })
                    .ToList()
                })
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return this.NotFound();
            }

            return this.Ok(course);
        }

        public IHttpActionResult Post(CourseRequestModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var courseToAdd = new Course()
            {
                Name = model.Name,
                Description = model.Description,
                Materials = model.Materials,
            };

            foreach (var homeworkId in model.HomeworkIds)
            {
                var currentHomework = this.homeworks
                    .All()
                    .FirstOrDefault(h => h.Id == homeworkId);

                if (currentHomework != null)
                {
                    courseToAdd.Homeworks.Add(currentHomework);
                }
            }

            foreach (var studentId in model.StudentIds)
            {
                var currentStudent = this.students
                    .All()
                    .FirstOrDefault(s => s.Id == studentId);

                if (currentStudent != null)
                {
                    courseToAdd.Students.Add(currentStudent);
                }
            }

            this.courses.Add(courseToAdd);
            this.courses.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var courseExists = this.courses
                .All()
                .Any(c => c.Id == id);

            if (!courseExists)
            {
                return this.NotFound();
            }

            this.courses.Delete(id);
            this.courses.SaveChanges();

            return this.Ok("The course was deleted successfully.");
        }

        public IHttpActionResult Put(int id, CourseRequestModel model)
        {
            var courseToUpdate = this.courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (courseToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            courseToUpdate.Description = model.Description;
            courseToUpdate.Materials = model.Materials;
            courseToUpdate.Name = model.Name;

            foreach (var homeworkId in model.HomeworkIds)
            {
                var currentHomework = this.homeworks
                    .All()
                    .FirstOrDefault(h => h.Id == homeworkId);

                if (currentHomework != null)
                {
                    courseToUpdate.Homeworks.Add(currentHomework);
                }
            }

            foreach (var studentId in model.StudentIds)
            {
                var currentStudent = this.students
                    .All()
                    .FirstOrDefault(s => s.Id == studentId);

                if (currentStudent != null)
                {
                    courseToUpdate.Students.Add(currentStudent);
                }
            }

            this.courses.SaveChanges();
            return this.Ok();
        }
    }
}