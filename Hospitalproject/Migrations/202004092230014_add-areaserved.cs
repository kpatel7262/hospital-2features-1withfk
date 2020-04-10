namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addareaserved : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaServeds",
                c => new
                    {
                        AreaServed_id = c.Int(nullable: false, identity: true),
                        AreaServed_name = c.String(),
                    })
                .PrimaryKey(t => t.AreaServed_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AreaServeds");
        }
    }
}
