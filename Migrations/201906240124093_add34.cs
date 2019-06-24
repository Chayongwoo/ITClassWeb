namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "ImageMimeType");
        }
    }
}
