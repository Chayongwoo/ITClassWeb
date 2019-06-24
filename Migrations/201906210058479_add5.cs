namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Member", "MemberPasswordConfirm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "MemberPasswordConfirm", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
