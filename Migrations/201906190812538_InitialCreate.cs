namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.License",
                c => new
                    {
                        LicenseID = c.Int(nullable: false, identity: true),
                        LicenseName = c.String(),
                        LicenseAgency = c.String(),
                        LicenseAcqDate = c.DateTime(nullable: false),
                        LicenseNumber = c.String(),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LicenseID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MemberEmail = c.String(),
                        MemberPassword = c.String(),
                        MemberPhone = c.String(),
                        MemberType = c.String(),
                        TutorImage = c.String(),
                        TutorPortfolio = c.String(),
                        TutorGit = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.License", "MemberID", "dbo.Member");
            DropIndex("dbo.License", new[] { "MemberID" });
            DropTable("dbo.Member");
            DropTable("dbo.License");
        }
    }
}
