namespace AracKiralamaApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GunlukAracTakips", "kiralamaId", c => c.Int(nullable: false));
            AddColumn("dbo.GunlukAracTakips", "gunlukGidilenKm", c => c.Int(nullable: false));
            AlterColumn("dbo.HarcamaTurus", "harcamaTuru", c => c.String(maxLength: 50));
            AlterColumn("dbo.Rols", "rolAdı", c => c.String(maxLength: 50));
            DropColumn("dbo.GunlukAracTakips", "guneBaslangicKm");
            DropColumn("dbo.GunlukAracTakips", "anlikKm");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GunlukAracTakips", "anlikKm", c => c.Int(nullable: false));
            AddColumn("dbo.GunlukAracTakips", "guneBaslangicKm", c => c.Int(nullable: false));
            AlterColumn("dbo.Rols", "rolAdı", c => c.String());
            AlterColumn("dbo.HarcamaTurus", "harcamaTuru", c => c.String());
            DropColumn("dbo.GunlukAracTakips", "gunlukGidilenKm");
            DropColumn("dbo.GunlukAracTakips", "kiralamaId");
        }
    }
}
