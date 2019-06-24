namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Foo_SelectedValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "Foo_SelectedValue");
        }
    }
}
