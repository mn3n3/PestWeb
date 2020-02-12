namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mohammedawad120220202 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", new[] { "CompanyID", "CountryID" }, "dbo.Countries");
            DropForeignKey("dbo.DiscriptionOfAnimals", "AnimalTypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" }, "dbo.Breeds");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" }, "dbo.CoatColours");
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" }, "dbo.DiscriptionOfAnimals");
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" }, "dbo.LocationOfMicrochips");
            DropIndex("dbo.Cities", new[] { "CompanyID", "CountryID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "AnimalTypeID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" });
            AddColumn("dbo.DiscriptionOfAnimals", "OwnerID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscriptionOfAnimals", "OwnerID");
            CreateIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" });
            CreateIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" });
            CreateIndex("dbo.DiscriptionOfAnimals", "AnimalTypeID");
            CreateIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" });
            CreateIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" });
            CreateIndex("dbo.Cities", new[] { "CompanyID", "CountryID" });
            AddForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" }, "dbo.LocationOfMicrochips", new[] { "CompanyID", "LocationOfMicrochipID" }, cascadeDelete: true);
            AddForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" }, "dbo.DiscriptionOfAnimals", new[] { "CompanyID", "AnimalID" }, cascadeDelete: true);
            AddForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" }, "dbo.CoatColours", new[] { "CompanyID", "CoatColourID" }, cascadeDelete: true);
            AddForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" }, "dbo.Breeds", new[] { "CompanyID", "BreedID" }, cascadeDelete: true);
            AddForeignKey("dbo.DiscriptionOfAnimals", "AnimalTypeID", "dbo.AnimalTypes", "AnimalTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Cities", new[] { "CompanyID", "CountryID" }, "dbo.Countries", new[] { "CompanyID", "CountryID" }, cascadeDelete: true);
        }
    }
}
