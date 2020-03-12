namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MohammedAwad120320203 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhysicalExaminations", "AnimalName");
            DropColumn("dbo.PhysicalExaminations", "OwnerID");
            DropColumn("dbo.PhysicalExaminations", "OwnerName");
            DropColumn("dbo.PhysicalExaminations", "Species");
            DropColumn("dbo.PhysicalExaminations", "Breed");
            DropColumn("dbo.PhysicalExaminations", "Sex");
            DropColumn("dbo.PhysicalExaminations", "CoatColour");
            DropColumn("dbo.PhysicalExaminations", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhysicalExaminations", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "CoatColour", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Sex", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Breed", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Species", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "OwnerName", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "OwnerID", c => c.Int(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "AnimalName", c => c.String());
        }
    }
}
