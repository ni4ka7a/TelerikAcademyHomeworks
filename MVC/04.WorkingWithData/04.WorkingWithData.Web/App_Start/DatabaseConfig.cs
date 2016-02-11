namespace _04.WorkingWithData.Web.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
            TwitterDbContext.Create().Database.Initialize(true);
        }
    }
}