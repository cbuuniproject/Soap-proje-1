namespace AracKiralamaApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aracs",
                c => new
                    {
                        aracId = c.Int(nullable: false, identity: true),
                        sirketId = c.Int(nullable: false),
                        marka = c.String(maxLength: 50),
                        model = c.String(maxLength: 50),
                        minEhliyetYasi = c.Int(nullable: false),
                        minYasSiniri = c.Short(nullable: false),
                        gunlukMaxKmSiniri = c.Short(nullable: false),
                        anlikKm = c.Int(nullable: false),
                        airbagSayisi = c.Byte(nullable: false),
                        bagajHacmi = c.Short(nullable: false),
                        koltukSayisi = c.Byte(nullable: false),
                        gunlukFiyat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.aracId)
                .ForeignKey("dbo.Sirkets", t => t.sirketId, cascadeDelete: true)
                .Index(t => t.sirketId);
            
            CreateTable(
                "dbo.Kiralamas",
                c => new
                    {
                        kiralamaId = c.Int(nullable: false, identity: true),
                        sirketId = c.Int(nullable: false),
                        musteriId = c.Int(nullable: false),
                        aracId = c.Int(nullable: false),
                        verilisTarihi = c.DateTime(nullable: false),
                        geriAlisTarihi = c.DateTime(),
                        verilisKm = c.Int(nullable: false),
                        sonKm = c.Int(),
                        ucret = c.Int(),
                    })
                .PrimaryKey(t => t.kiralamaId)
                .ForeignKey("dbo.Aracs", t => t.aracId, cascadeDelete: false)
                .ForeignKey("dbo.Sirkets", t => t.sirketId, cascadeDelete: false)
                .Index(t => t.sirketId)
                .Index(t => t.aracId);
            
            CreateTable(
                "dbo.Sirkets",
                c => new
                    {
                        sirketId = c.Int(nullable: false, identity: true),
                        sirketAdi = c.String(maxLength: 50),
                        sehir = c.String(maxLength: 50),
                        adres = c.String(maxLength: 100),
                        sirketPuani = c.Int(),
                    })
                .PrimaryKey(t => t.sirketId);
            
            CreateTable(
                "dbo.Calisans",
                c => new
                    {
                        calisanId = c.Int(nullable: false, identity: true),
                        ad = c.String(maxLength: 50),
                        soyad = c.String(maxLength: 50),
                        sirketId = c.Int(nullable: false),
                        kullaniciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.calisanId)
                .ForeignKey("dbo.Kullanicis", t => t.kullaniciId, cascadeDelete: true)
                .ForeignKey("dbo.Sirkets", t => t.sirketId, cascadeDelete: true)
                .Index(t => t.sirketId)
                .Index(t => t.kullaniciId);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        kullaniciId = c.Int(nullable: false, identity: true),
                        kullaniciAd = c.String(maxLength: 50),
                        parola = c.String(maxLength: 50),
                        kullaniciTuru = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.kullaniciId);
            
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        musteriId = c.Int(nullable: false, identity: true),
                        kullaniciId = c.Int(nullable: false),
                        ad = c.String(maxLength: 50),
                        soyad = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.musteriId)
                .ForeignKey("dbo.Kullanicis", t => t.kullaniciId, cascadeDelete: true)
                .Index(t => t.kullaniciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musteris", "kullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.Kiralamas", "sirketId", "dbo.Sirkets");
            DropForeignKey("dbo.Calisans", "sirketId", "dbo.Sirkets");
            DropForeignKey("dbo.Calisans", "kullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.Aracs", "sirketId", "dbo.Sirkets");
            DropForeignKey("dbo.Kiralamas", "aracId", "dbo.Aracs");
            DropIndex("dbo.Musteris", new[] { "kullaniciId" });
            DropIndex("dbo.Calisans", new[] { "kullaniciId" });
            DropIndex("dbo.Calisans", new[] { "sirketId" });
            DropIndex("dbo.Kiralamas", new[] { "aracId" });
            DropIndex("dbo.Kiralamas", new[] { "sirketId" });
            DropIndex("dbo.Aracs", new[] { "sirketId" });
            DropTable("dbo.Musteris");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.Calisans");
            DropTable("dbo.Sirkets");
            DropTable("dbo.Kiralamas");
            DropTable("dbo.Aracs");
        }
    }
}
