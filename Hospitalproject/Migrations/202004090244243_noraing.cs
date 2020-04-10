namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noraing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HomeRemedies", "HomeRemedies_ratings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeRemedies", "HomeRemedies_ratings", c => c.String());
        }
    }
}
