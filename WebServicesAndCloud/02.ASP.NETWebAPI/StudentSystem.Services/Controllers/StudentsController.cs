namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Services.Models.Students;
    using StudentsSystem.Data;
    using StudentsStystem.Models;

    public class StudentsController : ApiController
    {
        private StudentsDbContext db;
        private IRepository<Student> students;

        public StudentsController()
        {
            this.db = new StudentsDbContext();
            this.students = new EfGenericRepository<Student>(db);
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
                    Courses = s.Courses,
                    Homeworks = s.Homeworks
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
                    Courses = s.Courses,
                    Homeworks = s.Homeworks
                })
                .FirstOrDefault(s => s.Id == id);

            if(student == null)
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

            this.students.Add(new Student()
            {
                Name = model.Name,
                FacultyNumber = model.FacultyNumber,
                Courses = model.Courses,
                Homeworks = model.Homeworks
            });

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

        // TODO: Implement the update option
        public IHttpActionResult Put(int id)
        {
            return this.Ok();
        }
    }
}