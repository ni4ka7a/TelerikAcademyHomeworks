namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Models.Homeworks;
    using StudentsStystem.Models;
    using StudentsSystem.Data;

    public class HomeworksController : ApiController
    {
        private StudentsDbContext db;
        private IRepository<Homework> homeworks;

        public HomeworksController()
        {
            this.db = new StudentsDbContext();
            this.homeworks = new EfGenericRepository<Homework>(this.db);
        }

        public IHttpActionResult Get()
        {
            var homeworks = this.homeworks
                .All()
                .Select(h => new HomeworkResponseModel
                {
                    Id = h.Id,
                    Content = h.Content,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId
                })
                .ToList();

            return this.Ok(homeworks);
        }

        public IHttpActionResult Get(int id)
        {
            var homework = this.homeworks
                .All()
                .Select(h => new HomeworkResponseModel
                {
                    Id = h.Id,
                    Content = h.Content,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId
                })
                .FirstOrDefault();

            if (homework == null)
            {
                return this.NotFound();
            }

            return this.Ok(homework);
        }

        public IHttpActionResult Post(HomeworkRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.homeworks.Add(new Homework()
            {
                Content = model.Content,
                CourseId = model.CourseId,
                TimeSent = DateTime.Now,
                StudentId = model.StudentId
            });

            this.homeworks.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var homeworkExists = this.homeworks
                .All()
                .Any(h => h.Id == id);

            if (!homeworkExists)
            {
                return this.NotFound();
            }

            this.homeworks.Delete(id);
            this.homeworks.SaveChanges();

            return this.Ok("The homework was successfully deleted.");
        }

        // TODO: Implement update option
        public IHttpActionResult Put()
        {
            return this.Ok();
        }
    }
}