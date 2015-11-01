namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Models.Homeworks;
    using Services.Models.Students;
    using StudentsStystem.Models;
    using StudentsSystem.Data;

    public class StudentsController : ApiController
    {
        private StudentsDbContext db;
        private IRepository<Student> students;
        private IRepository<Homework> homeworks;
        private IRepository<Course> courses;

        public StudentsController()
        {
            this.db = new StudentsDbContext();
            this.students = new EfGenericRepository<Student>(this.db);
            this.homeworks = new EfGenericRepository<Homework>(this.db);
            this.courses = new EfGenericRepository<Course>(this.db);
        }

        public IHttpActionResult Get()
        {
            var students = this.students
                .All()
                .Select(s => new StudentResponseModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    FacultyNumber = s.FacultyNumber,
                    Courses = s.Courses.Select(c => c.Name).ToList(),
                    Homeworks = s.Homeworks.Select(h => new HomeworkResponseModel
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

            return this.Ok(students);
        }

        public IHttpActionResult Get(int id)
        {
            var student = this.students
                .All()
                .Select(s => new StudentResponseModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    FacultyNumber = s.FacultyNumber,
                    Courses = s.Courses.Select(c => c.Name).ToList(),
                    Homeworks = s.Homeworks.Select(h => new HomeworkResponseModel
                    {
                        Content = h.Content,
                        Id = h.Id,
                        TimeSent = h.TimeSent,
                        CourseId = h.CourseId,
                        StudentId = h.StudentId
                    })
                    .ToList()
                })
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }

        public IHttpActionResult Post(StudentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var studentToAdd = new Student()
            {
                Name = model.Name,
                FacultyNumber = model.FacultyNumber
            };

            foreach (var homeworkId in model.HomeworkIds)
            {
                var currentHomework = this.homeworks
                    .All()
                    .FirstOrDefault(h => h.Id == homeworkId);

                if (currentHomework != null)
                {
                    studentToAdd.Homeworks.Add(currentHomework);
                }
            }

            foreach (var courseId in model.CourseIds)
            {
                var currentCourse = this.courses
                    .All()
                    .FirstOrDefault(c => c.Id == courseId);

                if (currentCourse != null)
                {
                    studentToAdd.Courses.Add(currentCourse);
                }
            }

            this.students.Add(studentToAdd);
            this.students.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var studentExists = this.students
                .All()
                .Any(s => s.Id == id);

            if (!studentExists)
            {
                return this.NotFound();
            }

            this.students.Delete(id);
            this.students.SaveChanges();

            return this.Ok("The student was successfully deleted");
        }

        public IHttpActionResult Put(int id, StudentRequestModel model)
        {
            var studentToUpdate = this.students
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (studentToUpdate == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            studentToUpdate.Name = model.Name;
            studentToUpdate.FacultyNumber = model.FacultyNumber;

            foreach (var homeworkId in model.HomeworkIds)
            {
                var currentHomework = this.homeworks
                    .All()
                    .FirstOrDefault(h => h.Id == homeworkId);

                if (currentHomework != null)
                {
                    studentToUpdate.Homeworks.Add(currentHomework);
                }
            }

            foreach (var courseId in model.CourseIds)
            {
                var currentCourse = this.courses
                    .All()
                    .FirstOrDefault(c => c.Id == courseId);

                if (currentCourse != null)
                {
                    studentToUpdate.Courses.Add(currentCourse);
                }
            }

            this.students.SaveChanges();

            return this.Ok();
        }
    }
}