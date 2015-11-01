namespace StudentSystem.Client
{
    using System.Data.Entity;
    using System.Linq;

    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, Configuration>());

            var dbContext = new StudentsDbContext();

            var studentNames = dbContext.Students.Select(s => s.Name).ToList();
        }
    }
}
