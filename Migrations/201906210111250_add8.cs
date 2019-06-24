namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "MemberType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "MemberType", c => c.Int(nullable: false));
        }
    }
}
