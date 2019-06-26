namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lecture", "LectureImageFile", c => c.Binary());
            Sql("Update dbo.Lecture SET LectureImageFile = Convert(varbinary, LectureImageFile)");
            DropColumn("dbo.Lecture", "LectureImage");
            RenameColumn("dbo.Lecture", "LectureImageFile", "LectureImage");
        }

        public override void Down()
        {
            AddColumn("dbo.Lecture", "LectureImageFile", c => c.String());
            Sql("Update dbo.Lecture SET LectureImageFile = Convert(string, LectureImageFile)");
            DropColumn("dbo.Lecture", "LectureImage");
            RenameColumn("dbo.Lecture", "LectureImageFile", "LectureImage");
        }
    }
}
