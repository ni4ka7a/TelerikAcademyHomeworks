namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;
    using StudentsStystem.Models;

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
