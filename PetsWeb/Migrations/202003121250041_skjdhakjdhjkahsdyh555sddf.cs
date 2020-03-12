namespace PetsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skjdhakjdhjkahsdyh555sddf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicalExaminations", "Ch81", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx81", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch82", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx82", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch83", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx83", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch84", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx84", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch85", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx85", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch86", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx86", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch87", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx87", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch88", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx88", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch89", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx89", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch90", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx90", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch91", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx91", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch92", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx92", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch93", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx93", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch94", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx94", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch95", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx95", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch96", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx96", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch97", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx97", c => c.String());
            AddColumn("dbo.PhysicalExaminations", "Ch98", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhysicalExaminations", "Tx98", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicalExaminations", "Tx98");
            DropColumn("dbo.PhysicalExaminations", "Ch98");
            DropColumn("dbo.PhysicalExaminations", "Tx97");
            DropColumn("dbo.PhysicalExaminations", "Ch97");
            DropColumn("dbo.PhysicalExaminations", "Tx96");
            DropColumn("dbo.PhysicalExaminations", "Ch96");
            DropColumn("dbo.PhysicalExaminations", "Tx95");
            DropColumn("dbo.PhysicalExaminations", "Ch95");
            DropColumn("dbo.PhysicalExaminations", "Tx94");
            DropColumn("dbo.PhysicalExaminations", "Ch94");
            DropColumn("dbo.PhysicalExaminations", "Tx93");
            DropColumn("dbo.PhysicalExaminations", "Ch93");
            DropColumn("dbo.PhysicalExaminations", "Tx92");
            DropColumn("dbo.PhysicalExaminations", "Ch92");
            DropColumn("dbo.PhysicalExaminations", "Tx91");
            DropColumn("dbo.PhysicalExaminations", "Ch91");
            DropColumn("dbo.PhysicalExaminations", "Tx90");
            DropColumn("dbo.PhysicalExaminations", "Ch90");
            DropColumn("dbo.PhysicalExaminations", "Tx89");
            DropColumn("dbo.PhysicalExaminations", "Ch89");
            DropColumn("dbo.PhysicalExaminations", "Tx88");
            DropColumn("dbo.PhysicalExaminations", "Ch88");
            DropColumn("dbo.PhysicalExaminations", "Tx87");
            DropColumn("dbo.PhysicalExaminations", "Ch87");
            DropColumn("dbo.PhysicalExaminations", "Tx86");
            DropColumn("dbo.PhysicalExaminations", "Ch86");
            DropColumn("dbo.PhysicalExaminations", "Tx85");
            DropColumn("dbo.PhysicalExaminations", "Ch85");
            DropColumn("dbo.PhysicalExaminations", "Tx84");
            DropColumn("dbo.PhysicalExaminations", "Ch84");
            DropColumn("dbo.PhysicalExaminations", "Tx83");
            DropColumn("dbo.PhysicalExaminations", "Ch83");
            DropColumn("dbo.PhysicalExaminations", "Tx82");
            DropColumn("dbo.PhysicalExaminations", "Ch82");
            DropColumn("dbo.PhysicalExaminations", "Tx81");
            DropColumn("dbo.PhysicalExaminations", "Ch81");
        }
    }
}
