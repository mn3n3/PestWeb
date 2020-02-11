namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MohammedAwad100220202 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        AnimalTypeID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.AnimalTypeID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        TeleFax = c.String(),
                        ArabicAddress = c.String(),
                        EnglishAddress = c.String(),
                        LogoPath = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        BreedID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.BreedID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CityID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => new { t.CompanyID, t.CountryID }, cascadeDelete: false)
                .Index(t => t.CompanyID)
                .Index(t => new { t.CompanyID, t.CountryID });
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CountryID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.CoatColours",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        CoatColourID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CoatColourID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.DetailsOfOwnerships",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        Surname = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Address = c.String(),
                        PosCode = c.String(),
                        Telephone = c.String(),
                        CountryID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.OwnerID })
                .ForeignKey("dbo.Cities", t => new { t.CompanyID, t.CityID }, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => new { t.CompanyID, t.CountryID }, cascadeDelete: false)
                .Index(t => new { t.CompanyID, t.CityID })
                .Index(t => new { t.CompanyID, t.CountryID });
            
            CreateTable(
                "dbo.DiscriptionOfAnimals",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                        AnimalName = c.String(nullable: false),
                        AnimalTypeID = c.Int(nullable: false),
                        BreedID = c.Int(nullable: false),
                        CoatColourID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.AnimalID })
                .ForeignKey("dbo.AnimalTypes", t => new { t.CompanyID, t.AnimalTypeID }, cascadeDelete: false)
                .ForeignKey("dbo.Breeds", t => new { t.CompanyID, t.BreedID }, cascadeDelete: false)
                .ForeignKey("dbo.CoatColours", t => new { t.CompanyID, t.CoatColourID }, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => new { t.CompanyID, t.AnimalTypeID })
                .Index(t => new { t.CompanyID, t.BreedID })
                .Index(t => new { t.CompanyID, t.CoatColourID });
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.IdentificationOfAnimals",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        SerialID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                        MicrochipNumber = c.String(nullable: false),
                        DateOfMicrochipping = c.DateTime(nullable: false),
                        LocationOfMicrochipID = c.Int(nullable: false),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.SerialID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .ForeignKey("dbo.DiscriptionOfAnimals", t => new { t.CompanyID, t.AnimalID }, cascadeDelete: false)
                .ForeignKey("dbo.LocationOfMicrochips", t => new { t.CompanyID, t.LocationOfMicrochipID }, cascadeDelete: false)
                .Index(t => t.CompanyID)
                .Index(t => new { t.CompanyID, t.AnimalID })
                .Index(t => new { t.CompanyID, t.LocationOfMicrochipID });
            
            CreateTable(
                "dbo.LocationOfMicrochips",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        LocationOfMicrochipID = c.Int(nullable: false),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.LocationOfMicrochipID })
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: false)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" }, "dbo.LocationOfMicrochips");
            DropForeignKey("dbo.LocationOfMicrochips", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" }, "dbo.DiscriptionOfAnimals");
            DropForeignKey("dbo.IdentificationOfAnimals", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.DiscriptionOfAnimals", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" }, "dbo.CoatColours");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" }, "dbo.Breeds");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "AnimalTypeID" }, "dbo.AnimalTypes");
            DropForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" }, "dbo.Countries");
            DropForeignKey("dbo.DetailsOfOwnerships", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" }, "dbo.Cities");
            DropForeignKey("dbo.CoatColours", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Cities", new[] { "CompanyID", "CountryID" }, "dbo.Countries");
            DropForeignKey("dbo.Countries", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Cities", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Breeds", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.AnimalTypes", "CompanyID", "dbo.Companies");
            DropIndex("dbo.LocationOfMicrochips", new[] { "CompanyID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "AnimalTypeID" });
            DropIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CountryID" });
            DropIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" });
            DropIndex("dbo.CoatColours", new[] { "CompanyID" });
            DropIndex("dbo.Countries", new[] { "CompanyID" });
            DropIndex("dbo.Cities", new[] { "CompanyID", "CountryID" });
            DropIndex("dbo.Cities", new[] { "CompanyID" });
            DropIndex("dbo.Breeds", new[] { "CompanyID" });
            DropIndex("dbo.AnimalTypes", new[] { "CompanyID" });
            DropTable("dbo.LocationOfMicrochips");
            DropTable("dbo.IdentificationOfAnimals");
            DropTable("dbo.Genders");
            DropTable("dbo.DiscriptionOfAnimals");
            DropTable("dbo.DetailsOfOwnerships");
            DropTable("dbo.CoatColours");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Breeds");
            DropTable("dbo.Companies");
            DropTable("dbo.AnimalTypes");
        }
    }
}
