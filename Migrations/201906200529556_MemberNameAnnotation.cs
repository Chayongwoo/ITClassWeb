namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberNameAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "MemberName", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "MemberName", c => c.String(nullable: false));
        }
    }
}
