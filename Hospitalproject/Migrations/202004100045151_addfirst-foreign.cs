namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfirstforeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeRemedies", "RemedySource_id", c => c.Int(nullable: false));
            CreateIndex("dbo.HomeRemedies", "RemedySource_id");
            AddForeignKey("dbo.HomeRemedies", "RemedySource_id", "dbo.RemedySources", "RemedySource_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeRemedies", "RemedySource_id", "dbo.RemedySources");
            DropIndex("dbo.HomeRemedies", new[] { "RemedySource_id" });
            DropColumn("dbo.HomeRemedies", "RemedySource_id");
        }
    }
}
