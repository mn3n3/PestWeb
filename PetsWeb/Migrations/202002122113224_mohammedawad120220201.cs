namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mohammedawad120220201 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" }, "dbo.Cities");
            DropIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" });
            DropTable("dbo.Genders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" });
            AddForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" }, "dbo.Cities", new[] { "CompanyID", "CityID" }, cascadeDelete: true);
        }
    }
}
