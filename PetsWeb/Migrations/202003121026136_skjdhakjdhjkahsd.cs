namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhysicalExaminations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                        AnimalName = c.String(),
                        OwnerID = c.Int(nullable: false),
                        OwnerName = c.String(),
                        Species = c.String(),
                        Breed = c.String(),
                        Sex = c.String(),
                        CoatColour = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Ch1 = c.Boolean(nullable: false),
                        Tx1 = c.String(),
                        Ch2 = c.Boolean(nullable: false),
                        Tx2 = c.String(),
                        Ch3 = c.Boolean(nullable: false),
                        Tx3 = c.String(),
                        Ch4 = c.Boolean(nullable: false),
                        Tx4 = c.String(),
                        Ch5 = c.Boolean(nullable: false),
                        Tx5 = c.String(),
                        Ch6 = c.Boolean(nullable: false),
                        Tx6 = c.String(),
                        Ch7 = c.Boolean(nullable: false),
                        Tx7 = c.String(),
                        Ch8 = c.Boolean(nullable: false),
                        Tx8 = c.String(),
                        Ch9 = c.Boolean(nullable: false),
                        Tx9 = c.String(),
                        Ch10 = c.Boolean(nullable: false),
                        Tx10 = c.String(),
                        Ch11 = c.Boolean(nullable: false),
                        Tx11 = c.String(),
                        Ch12 = c.Boolean(nullable: false),
                        Tx12 = c.String(),
                        Ch13 = c.Boolean(nullable: false),
                        Tx13 = c.String(),
                        Ch14 = c.Boolean(nullable: false),
                        Tx14 = c.String(),
                        Ch15 = c.Boolean(nullable: false),
                        Tx15 = c.String(),
                        Ch16 = c.Boolean(nullable: false),
                        Tx16 = c.String(),
                        Ch17 = c.Boolean(nullable: false),
                        Tx17 = c.String(),
                        Ch18 = c.Boolean(nullable: false),
                        Tx18 = c.String(),
                        Ch19 = c.Boolean(nullable: false),
                        Tx19 = c.String(),
                        Ch20 = c.Boolean(nullable: false),
                        Tx20 = c.String(),
                        Ch21 = c.Boolean(nullable: false),
                        Tx21 = c.String(),
                        Ch22 = c.Boolean(nullable: false),
                        Tx22 = c.String(),
                        Ch23 = c.Boolean(nullable: false),
                        Tx23 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.DiscriptionOfAnimals", "OwnerID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscriptionOfAnimals", "OwnerID", c => c.Int(nullable: false));
            DropTable("dbo.PhysicalExaminations");
        }
    }
}
