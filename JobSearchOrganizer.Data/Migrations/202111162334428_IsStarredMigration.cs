namespace JobSearchOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsStarredMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "IsStarred");
        }
    }
}
