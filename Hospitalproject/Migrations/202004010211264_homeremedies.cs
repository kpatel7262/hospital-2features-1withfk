namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homeremedies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomeRemedies",
                c => new
                    {
                        HomeRemedies_id = c.Int(nullable: false, identity: true),
                        HomeRemedies_title = c.String(),
                        HomeRemedies_desc = c.String(),
                        HomeRemedies_ratings = c.String(),
                        HomeRemedies_datetime = c.String(),
                    })
                .PrimaryKey(t => t.HomeRemedies_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HomeRemedies");
        }
    }
}
