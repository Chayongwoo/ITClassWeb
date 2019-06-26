namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedule", "LectureID", "dbo.Lecture");
            DropIndex("dbo.Schedule", new[] { "LectureID" });
            AddColumn("dbo.Lecture", "ScheduleTime", c => c.String(nullable: false));
            DropTable("dbo.Schedule");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Dayofweek = c.String(nullable: false, maxLength: 10),
                        ScheduleTime = c.String(nullable: false, maxLength: 20),
                        LectureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
            DropColumn("dbo.Lecture", "ScheduleTime");
            CreateIndex("dbo.Schedule", "LectureID");
            AddForeignKey("dbo.Schedule", "LectureID", "dbo.Lecture", "LectureID", cascadeDelete: true);
        }
    }
}
