namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Member", "Foo_SelectedValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "Foo_SelectedValue", c => c.String());
        }
    }
}
