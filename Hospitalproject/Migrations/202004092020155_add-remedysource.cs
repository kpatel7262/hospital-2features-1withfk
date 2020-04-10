namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addremedysource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RemedySources",
                c => new
                    {
                        RemedySource_id = c.Int(nullable: false, identity: true),
                        RemedySource_name = c.String(),
                        RemedySource_url = c.String(),
                    })
                .PrimaryKey(t => t.RemedySource_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RemedySources");
        }
    }
}
