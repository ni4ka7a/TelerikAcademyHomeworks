namespace AudioSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;
    using Data.Migrations;
    using Models;

    public static class Startup
    {
        public static void Main()
        {
            var dbContext = new AudioSystemDbContext();
            dbContext.Albums.ToList();
        }
    }
}
