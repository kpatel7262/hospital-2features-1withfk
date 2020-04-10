namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nodatetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HomeRemedies", "HomeRemedies_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeRemedies", "HomeRemedies_datetime", c => c.String());
        }
    }
}
