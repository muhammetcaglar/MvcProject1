namespace BeyazEsyaProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mcaglar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeyazEsyas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Renk = c.String(),
                        Boyutlar_En = c.Int(nullable: false),
                        Boyutlar_Boy = c.Int(nullable: false),
                        Boyutlar_Derinlik = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                        Kg = c.Int(),
                        ProgramSayisi = c.Int(),
                        SogutucuTip = c.Int(),
                        Hacim = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeyazEsyas", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.BeyazEsyas", new[] { "KategoriId" });
            DropTable("dbo.Kategoris");
            DropTable("dbo.BeyazEsyas");
        }
    }
}
