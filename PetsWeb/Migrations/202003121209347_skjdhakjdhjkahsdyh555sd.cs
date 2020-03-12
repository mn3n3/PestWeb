namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsdyh555sd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicalExaminations", "Tx61", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch62", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Ch64", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx64", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch65", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx65", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch66", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx66", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch67", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx67", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch68", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx68", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch69", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx69", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch70", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx70", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch71", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx71", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch72", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx72", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch73", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx73", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch74", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx74", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch75", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx75", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch76", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx76", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch77", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx77", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch78", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx78", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch79", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx79", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch80", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx80", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicalExaminations", "Tx80");
            DropColumn("dbo.PhysicalExaminations", "Ch80");
            DropColumn("dbo.PhysicalExaminations", "Tx79");
            DropColumn("dbo.PhysicalExaminations", "Ch79");
            DropColumn("dbo.PhysicalExaminations", "Tx78");
            DropColumn("dbo.PhysicalExaminations", "Ch78");
            DropColumn("dbo.PhysicalExaminations", "Tx77");
            DropColumn("dbo.PhysicalExaminations", "Ch77");
            DropColumn("dbo.PhysicalExaminations", "Tx76");
            DropColumn("dbo.PhysicalExaminations", "Ch76");
            DropColumn("dbo.PhysicalExaminations", "Tx75");
            DropColumn("dbo.PhysicalExaminations", "Ch75");
            DropColumn("dbo.PhysicalExaminations", "Tx74");
            DropColumn("dbo.PhysicalExaminations", "Ch74");
            DropColumn("dbo.PhysicalExaminations", "Tx73");
            DropColumn("dbo.PhysicalExaminations", "Ch73");
            DropColumn("dbo.PhysicalExaminations", "Tx72");
            DropColumn("dbo.PhysicalExaminations", "Ch72");
            DropColumn("dbo.PhysicalExaminations", "Tx71");
            DropColumn("dbo.PhysicalExaminations", "Ch71");
            DropColumn("dbo.PhysicalExaminations", "Tx70");
            DropColumn("dbo.PhysicalExaminations", "Ch70");
            DropColumn("dbo.PhysicalExaminations", "Tx69");
            DropColumn("dbo.PhysicalExaminations", "Ch69");
            DropColumn("dbo.PhysicalExaminations", "Tx68");
            DropColumn("dbo.PhysicalExaminations", "Ch68");
            DropColumn("dbo.PhysicalExaminations", "Tx67");
            DropColumn("dbo.PhysicalExaminations", "Ch67");
            DropColumn("dbo.PhysicalExaminations", "Tx66");
            DropColumn("dbo.PhysicalExaminations", "Ch66");
            DropColumn("dbo.PhysicalExaminations", "Tx65");
            DropColumn("dbo.PhysicalExaminations", "Ch65");
            DropColumn("dbo.PhysicalExaminations", "Tx64");
            DropColumn("dbo.PhysicalExaminations", "Ch64");
            DropColumn("dbo.PhysicalExaminations", "Ch62");
            DropColumn("dbo.PhysicalExaminations", "Tx61");
        }
    }
}
