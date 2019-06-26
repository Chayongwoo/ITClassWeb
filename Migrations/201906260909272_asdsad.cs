namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lecture", "LectureImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lecture", "LectureImage", c => c.Binary(nullable: false));
        }
    }
}
