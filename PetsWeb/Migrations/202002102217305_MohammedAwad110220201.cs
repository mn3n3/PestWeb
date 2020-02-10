namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MohammedAwad110220201 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" }, "dbo.Countries");
            DropIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" });
            AddForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" }, "dbo.Countries", new[] { "CompanyID", "CountryID" }, cascadeDelete: true);
        }
    }
}
