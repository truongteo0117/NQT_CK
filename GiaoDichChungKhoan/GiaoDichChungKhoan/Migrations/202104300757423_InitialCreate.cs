namespace GiaoDichChungKhoan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.giaodiches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        mSan = c.String(),
                        mck = c.String(),
                        mUser = c.Int(nullable: false),
                        lenh = c.String(),
                        soCoPhieu = c.String(),
                        soTien = c.String(),
                        trangThai = c.String(),
                        thoiGian = c.DateTime(nullable: false),
                        phien = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        tien = c.String(),
                        cophieu = c.String(),
                        giaodich_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.giaodiches", t => t.giaodich_id)
                .Index(t => t.giaodich_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "giaodich_id", "dbo.giaodiches");
            DropIndex("dbo.users", new[] { "giaodich_id" });
            DropTable("dbo.users");
            DropTable("dbo.giaodiches");
        }
    }
}
