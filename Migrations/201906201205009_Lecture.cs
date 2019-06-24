namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lecture : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lecture", "LectureTitle", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Lecture", "LectureLanguage", c => c.String(nullable: false));
            AlterColumn("dbo.Lecture", "LectureImage", c => c.String(nullable: false));
            AlterColumn("dbo.Lecture", "TutorIntroduce", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Lecture", "LectureIntroduce", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Lecture", "LecturePeople", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Lecture", "LecturePlan", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Lecture", "LectureLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Lecture", "LecturePlace", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lecture", "LecturePlace", c => c.String());
            AlterColumn("dbo.Lecture", "LectureLocation", c => c.String());
            AlterColumn("dbo.Lecture", "LecturePlan", c => c.String());
            AlterColumn("dbo.Lecture", "LecturePeople", c => c.String());
            AlterColumn("dbo.Lecture", "LectureIntroduce", c => c.String());
            AlterColumn("dbo.Lecture", "TutorIntroduce", c => c.String());
            AlterColumn("dbo.Lecture", "LectureImage", c => c.String());
            AlterColumn("dbo.Lecture", "LectureLanguage", c => c.String());
            AlterColumn("dbo.Lecture", "LectureTitle", c => c.String());
        }
    }
}
