namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsdyh555 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicalExaminations", "Ch52", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx52", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch53", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx53", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch54", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx54", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch55", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx55", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch56", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx56", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch57", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx57", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch58", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx58", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch59", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx59", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch60", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx60", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch61", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx62", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch63", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx63", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicalExaminations", "Tx63");
            DropColumn("dbo.PhysicalExaminations", "Ch63");
            DropColumn("dbo.PhysicalExaminations", "Tx62");
            DropColumn("dbo.PhysicalExaminations", "Ch61");
            DropColumn("dbo.PhysicalExaminations", "Tx60");
            DropColumn("dbo.PhysicalExaminations", "Ch60");
            DropColumn("dbo.PhysicalExaminations", "Tx59");
            DropColumn("dbo.PhysicalExaminations", "Ch59");
            DropColumn("dbo.PhysicalExaminations", "Tx58");
            DropColumn("dbo.PhysicalExaminations", "Ch58");
            DropColumn("dbo.PhysicalExaminations", "Tx57");
            DropColumn("dbo.PhysicalExaminations", "Ch57");
            DropColumn("dbo.PhysicalExaminations", "Tx56");
            DropColumn("dbo.PhysicalExaminations", "Ch56");
            DropColumn("dbo.PhysicalExaminations", "Tx55");
            DropColumn("dbo.PhysicalExaminations", "Ch55");
            DropColumn("dbo.PhysicalExaminations", "Tx54");
            DropColumn("dbo.PhysicalExaminations", "Ch54");
            DropColumn("dbo.PhysicalExaminations", "Tx53");
            DropColumn("dbo.PhysicalExaminations", "Ch53");
            DropColumn("dbo.PhysicalExaminations", "Tx52");
            DropColumn("dbo.PhysicalExaminations", "Ch52");
        }
    }
}
