namespace Aplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbas", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbas", "Status", c => c.String());
        }
    }
}
