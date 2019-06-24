namespace ITClassWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class add26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "TutorImageTmp", c => c.Binary());
            Sql("Update dbo.Member SET TutorImageTmp = Convert(varbinary, TutorImageTmp)");
            DropColumn("dbo.Member", "TutorImage");
            RenameColumn("dbo.Member", "TutorImageTmp", "TutorImage");
        }

        public override void Down()
        {
            AddColumn("dbo.Member", "TutorImageTmp", c => c.String());
            Sql("Update dbo.Member SET TutorImageTmp = Convert(string, TutorImageTmp)");
            DropColumn("dbo.Member", "TutorImage");
            RenameColumn("dbo.Member", "TutorImageTmp", "TutorImage");      
        }
    }
}
