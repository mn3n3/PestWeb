namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_run3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        AnimalTypeID = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(nullable: false),
                        EnglishName = c.String(),
                        InsUserID = c.String(),
                        InsDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalTypeID);
            
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
                .PrimaryKey(t => new { t.CompanyID, t.BreedID });
            
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
                .ForeignKey("dbo.Countries", t => new { t.CompanyID, t.CountryID }, cascadeDelete: true)
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
                .PrimaryKey(t => new { t.CompanyID, t.CountryID });
            
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
                .PrimaryKey(t => new { t.CompanyID, t.CoatColourID });
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArabicName = c.String(),
                        EnglishName = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        TeleFax = c.String(),
                        ArabicAddress = c.String(),
                        EnglishAddress = c.String(),
                        CompanyLogo = c.String(),
                        UserId = c.String(),
                        COREFID = c.String(),
                        test = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.Cities", t => new { t.CompanyID, t.CityID }, cascadeDelete: true)
                .Index(t => new { t.CompanyID, t.CityID });
            
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
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Breeds", t => new { t.CompanyID, t.BreedID }, cascadeDelete: true)
                .ForeignKey("dbo.CoatColours", t => new { t.CompanyID, t.CoatColourID }, cascadeDelete: true)
                .Index(t => new { t.CompanyID, t.BreedID })
                .Index(t => new { t.CompanyID, t.CoatColourID })
                .Index(t => t.AnimalTypeID);
            
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
                .ForeignKey("dbo.DiscriptionOfAnimals", t => new { t.CompanyID, t.AnimalID }, cascadeDelete: true)
                .ForeignKey("dbo.LocationOfMicrochips", t => new { t.CompanyID, t.LocationOfMicrochipID }, cascadeDelete: true)
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
                .PrimaryKey(t => new { t.CompanyID, t.LocationOfMicrochipID });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Int(nullable: false),
                        fCompanyId = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                        EmployeeID = c.String(),
                        CODOMAIN = c.String(),
                        RealPass = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" }, "dbo.LocationOfMicrochips");
            DropForeignKey("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" }, "dbo.DiscriptionOfAnimals");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" }, "dbo.CoatColours");
            DropForeignKey("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" }, "dbo.Breeds");
            DropForeignKey("dbo.DiscriptionOfAnimals", "AnimalTypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" }, "dbo.Cities");
            DropForeignKey("dbo.Cities", new[] { "CompanyID", "CountryID" }, "dbo.Countries");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "LocationOfMicrochipID" });
            DropIndex("dbo.IdentificationOfAnimals", new[] { "CompanyID", "AnimalID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "AnimalTypeID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "CoatColourID" });
            DropIndex("dbo.DiscriptionOfAnimals", new[] { "CompanyID", "BreedID" });
            DropIndex("dbo.DetailsOfOwnerships", new[] { "CompanyID", "CityID" });
            DropIndex("dbo.Cities", new[] { "CompanyID", "CountryID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LocationOfMicrochips");
            DropTable("dbo.IdentificationOfAnimals");
            DropTable("dbo.Genders");
            DropTable("dbo.DiscriptionOfAnimals");
            DropTable("dbo.DetailsOfOwnerships");
            DropTable("dbo.Companies");
            DropTable("dbo.CoatColours");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Breeds");
            DropTable("dbo.AnimalTypes");
        }
    }
}
