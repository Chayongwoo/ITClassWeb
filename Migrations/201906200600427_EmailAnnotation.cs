namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "MemberEmail", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "MemberEmail", c => c.String(nullable: false));
        }
    }
}
