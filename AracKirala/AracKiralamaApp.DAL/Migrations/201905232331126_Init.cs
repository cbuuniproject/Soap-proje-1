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
                .PrimaryKey(t => t.aracId);
            
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
                .PrimaryKey(t => t.calisanId);
            
            CreateTable(
                "dbo.GunlukAracTakips",
                c => new
                    {
                        takipId = c.Int(nullable: false, identity: true),
                        aracId = c.Int(nullable: false),
                        kiralamaId = c.Int(nullable: false),
                        gunlukGidilenKm = c.Int(nullable: false),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.takipId);
            
            CreateTable(
                "dbo.Harcamalars",
                c => new
                    {
                        harcamaId = c.Int(nullable: false, identity: true),
                        harcamaTuruId = c.Int(nullable: false),
                        aciklama = c.String(),
                        tarih = c.DateTime(nullable: false),
                        ucret = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.harcamaId);
            
            CreateTable(
                "dbo.HarcamaTurus",
                c => new
                    {
                        harcamaId = c.Int(nullable: false, identity: true),
                        harcamaTuru = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.harcamaId);
            
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
                .PrimaryKey(t => t.kiralamaId);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        kullaniciId = c.Int(nullable: false, identity: true),
                        kullaniciAd = c.String(maxLength: 50),
                        parola = c.String(maxLength: 50),
                        rolid = c.Int(nullable: false),
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
                .PrimaryKey(t => t.musteriId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        rolid = c.Int(nullable: false, identity: true),
                        rolAdı = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.rolid);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sirkets");
            DropTable("dbo.Rols");
            DropTable("dbo.Musteris");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.Kiralamas");
            DropTable("dbo.HarcamaTurus");
            DropTable("dbo.Harcamalars");
            DropTable("dbo.GunlukAracTakips");
            DropTable("dbo.Calisans");
            DropTable("dbo.Aracs");
        }
    }
}
