namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        ApplicationLevel = c.String(),
                        LectureID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationID)
                .ForeignKey("dbo.Lecture", t => t.LectureID, cascadeDelete: true)
                .Index(t => t.LectureID);
            
            CreateTable(
                "dbo.ApplySchedule",
                c => new
                    {
                        ApplyScheduleID = c.Int(nullable: false, identity: true),
                        ApplyDayofweek = c.String(),
                        ApplyScheduleTime = c.String(),
                        ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplyScheduleID)
                .ForeignKey("dbo.Application", t => t.ApplicationID, cascadeDelete: true)
                .Index(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        LectureID = c.Int(nullable: false, identity: true),
                        LectureTitle = c.String(),
                        LectureLanguage = c.String(),
                        LectureImage = c.String(),
                        TutorIntroduce = c.String(),
                        LectureIntroduce = c.String(),
                        LecturePeople = c.String(),
                        LecturePlan = c.String(),
                        LectureCount = c.Int(nullable: false),
                        LecturePrice = c.Int(nullable: false),
                        LectureMaxperson = c.Int(nullable: false),
                        LectureApplyDeadline = c.DateTime(nullable: false),
                        LectureLocation = c.String(),
                        LecturePlace = c.String(),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LectureID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewContent = c.String(),
                        ReviewGrade = c.Int(nullable: false),
                        LectureID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Lecture", t => t.LectureID, cascadeDelete: true)
                .Index(t => t.LectureID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Dayofweek = c.String(),
                        ScheduleTime = c.String(),
                        LectureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Lecture", t => t.LectureID, cascadeDelete: true)
                .Index(t => t.LectureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.Review", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.Lecture", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Application", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.ApplySchedule", "ApplicationID", "dbo.Application");
            DropIndex("dbo.Schedule", new[] { "LectureID" });
            DropIndex("dbo.Review", new[] { "LectureID" });
            DropIndex("dbo.Lecture", new[] { "MemberID" });
            DropIndex("dbo.ApplySchedule", new[] { "ApplicationID" });
            DropIndex("dbo.Application", new[] { "LectureID" });
            DropTable("dbo.Schedule");
            DropTable("dbo.Review");
            DropTable("dbo.Lecture");
            DropTable("dbo.ApplySchedule");
            DropTable("dbo.Application");
        }
    }
}
