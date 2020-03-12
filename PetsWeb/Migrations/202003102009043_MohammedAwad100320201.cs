namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MohammedAwad100320201 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscriptionOfAnimals", "OwnerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiscriptionOfAnimals", "OwnerID", c => c.String(nullable: false));
        }
    }
}
