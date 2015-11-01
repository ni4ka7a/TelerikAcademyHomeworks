namespace AudioSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;
    using Models;
    using Data.Migrations;

    public static class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AudioSystemDbContext, Configuration>());
            var dbContext = new AudioSystemDbContext();
            dbContext.Albums.ToList();
        }
    }
}
