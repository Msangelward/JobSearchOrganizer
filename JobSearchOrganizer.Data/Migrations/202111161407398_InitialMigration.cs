namespace JobSearchOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "JobTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "JobTitle");
        }
    }
}
