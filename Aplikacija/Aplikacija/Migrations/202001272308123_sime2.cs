namespace Aplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sime2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Zaposleniks", "LoginErrorMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zaposleniks", "LoginErrorMessage", c => c.String());
        }
    }
}
