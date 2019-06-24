namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class License : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.License", "LicenseName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.License", "LicenseAgency", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.License", "LicenseNumber", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.License", "LicenseNumber", c => c.String());
            AlterColumn("dbo.License", "LicenseAgency", c => c.String());
            AlterColumn("dbo.License", "LicenseName", c => c.String());
        }
    }
}
