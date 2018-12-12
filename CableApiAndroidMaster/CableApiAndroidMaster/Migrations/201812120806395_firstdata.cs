namespace CableApiAndroidMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdminRegistrations",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        RegId = c.Int(),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        UserId = c.String(),
                        Password = c.String(),
                        Pin = c.String(),
                        RegDate = c.DateTime(),
                        NoOfAgent = c.Int(),
                        SkyStatus = c.Int(nullable: false),
                        OperatorCode = c.String(),
                        IMEINo = c.String(),
                        ApiLink = c.String(),
                    })
                .PrimaryKey(t => t.Aid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblAdminRegistrations");
        }
    }
}
