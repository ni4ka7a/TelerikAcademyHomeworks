namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Services.Models.Courses;
    using StudentsStystem.Models;
    using StudentsSystem.Data;

    public class CoursesController : ApiController
    {
        private StudentsDbContext db;
        private IRepository<Course> courses;

        public CoursesController()
        {
            this.db = new StudentsDbContext();
            this.courses = new EfGenericRepository<Course>(this.db);
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
                    Students = c.Students,
                    Homeworks = c.Homeworks
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
                    Students = c.Students,
                    Homeworks = c.Homeworks
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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.courses.Add(new Course()
            {
                Name = model.Name,
                Description = model.Description,
                Materials = model.Materials,
                Students = model.Students,
                Homeworks = model.Homeworks
            });

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

        // TODO: Implement update option
        public IHttpActionResult Put()
        {
            return this.Ok();
        }
    }
}