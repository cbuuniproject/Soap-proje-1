namespace AracKiralamaApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yeni : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aracs", "kullanımDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aracs", "kullanımDurumu");
        }
    }
}
