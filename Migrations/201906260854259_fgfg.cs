namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgfg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lecture", "LectureImage", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lecture", "LectureImage", c => c.Binary());
        }
    }
}
