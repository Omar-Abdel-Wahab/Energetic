namespace IP_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        role = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        gAddress = c.String(),
                        email = c.String(),
                        phone = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        title = c.String(),
                        content = c.String(),
                        date_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Dates", t => t.date_id)
                .Index(t => t.date_id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        title = c.String(),
                        content = c.String(),
                        date_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Dates", t => t.date_id)
                .Index(t => t.date_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "date_id", "dbo.Dates");
            DropForeignKey("dbo.Events", "date_id", "dbo.Dates");
            DropIndex("dbo.News", new[] { "date_id" });
            DropIndex("dbo.Events", new[] { "date_id" });
            DropTable("dbo.News");
            DropTable("dbo.Events");
            DropTable("dbo.Dates");
            DropTable("dbo.Contacts");
            DropTable("dbo.Admins");
        }
    }
}
