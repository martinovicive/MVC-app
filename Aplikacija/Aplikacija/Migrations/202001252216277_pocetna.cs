namespace Aplikacija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pocetna : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predbiljezbas",
                c => new
                    {
                        IdPredbiljezba = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        IdSeminar = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.IdPredbiljezba)
                .ForeignKey("dbo.Seminars", t => t.IdSeminar, cascadeDelete: true)
                .Index(t => t.IdSeminar);
            
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        IdSeminar = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Opis = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Popunjen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeminar);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        IdZaposlenik = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        KorisnickoIme = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LoginErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.IdZaposlenik);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predbiljezbas", "IdSeminar", "dbo.Seminars");
            DropIndex("dbo.Predbiljezbas", new[] { "IdSeminar" });
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.Seminars");
            DropTable("dbo.Predbiljezbas");
        }
    }
}
