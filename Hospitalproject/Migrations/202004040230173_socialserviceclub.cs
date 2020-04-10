namespace Hospitalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class socialserviceclub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialServiceClubs",
                c => new
                    {
                        SocialServiceClubs_id = c.Int(nullable: false, identity: true),
                        SocialServiceClubs_title = c.String(),
                        SocialServiceClubs_details = c.String(),
                        SocialServiceClubs_address = c.String(),
                    })
                .PrimaryKey(t => t.SocialServiceClubs_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialServiceClubs");
        }
    }
}
