namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lecture", "LectureImageType", c => c.String());
            AlterColumn("dbo.Lecture", "LectureImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lecture", "LectureImage", c => c.String());
            DropColumn("dbo.Lecture", "LectureImageType");
        }
    }
}
