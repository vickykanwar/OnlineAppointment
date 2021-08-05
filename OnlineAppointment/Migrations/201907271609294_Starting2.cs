namespace OnlineAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Starting2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceMasterID = c.Int(nullable: false),
                        CustomerMasterID = c.Int(nullable: false),
                        SlotTimeMasterID = c.Int(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerMasters", t => t.CustomerMasterID, cascadeDelete: true)
                .ForeignKey("dbo.ServiceMasters", t => t.ServiceMasterID, cascadeDelete: true)
                .ForeignKey("dbo.SlotTimeMasters", t => t.SlotTimeMasterID, cascadeDelete: true)
                .Index(t => t.ServiceMasterID)
                .Index(t => t.CustomerMasterID)
                .Index(t => t.SlotTimeMasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentMasters", "SlotTimeMasterID", "dbo.SlotTimeMasters");
            DropForeignKey("dbo.AppointmentMasters", "ServiceMasterID", "dbo.ServiceMasters");
            DropForeignKey("dbo.AppointmentMasters", "CustomerMasterID", "dbo.CustomerMasters");
            DropIndex("dbo.AppointmentMasters", new[] { "SlotTimeMasterID" });
            DropIndex("dbo.AppointmentMasters", new[] { "CustomerMasterID" });
            DropIndex("dbo.AppointmentMasters", new[] { "ServiceMasterID" });
            DropTable("dbo.AppointmentMasters");
        }
    }
}
