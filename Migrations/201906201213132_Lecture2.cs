namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Application", "ApplicationLevel", c => c.String(nullable: false));
            AlterColumn("dbo.ApplySchedule", "ApplyDayofweek", c => c.String(nullable: false));
            AlterColumn("dbo.ApplySchedule", "ApplyScheduleTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplySchedule", "ApplyScheduleTime", c => c.String());
            AlterColumn("dbo.ApplySchedule", "ApplyDayofweek", c => c.String());
            AlterColumn("dbo.Application", "ApplicationLevel", c => c.String());
        }
    }
}
