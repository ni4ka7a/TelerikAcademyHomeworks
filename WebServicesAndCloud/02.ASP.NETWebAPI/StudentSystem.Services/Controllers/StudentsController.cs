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
            this.students = new StudentSystemRepository<Student>(db);
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
    }
}