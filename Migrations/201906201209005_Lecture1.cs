namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedule", "Dayofweek", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Schedule", "ScheduleTime", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedule", "ScheduleTime", c => c.String());
            AlterColumn("dbo.Schedule", "Dayofweek", c => c.String());
        }
    }
}
