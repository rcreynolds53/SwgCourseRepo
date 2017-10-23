namespace DvdLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        ReleaseYear = c.Int(nullable: false),
                        Rating = c.String(maxLength: 5),
                        Director = c.String(maxLength: 75),
                        Notes = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.DvdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
