namespace OnlineAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Starting3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentCancelMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppointmentMasterID = c.Int(nullable: false),
                        CancelDate = c.DateTime(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppointmentMasters", t => t.AppointmentMasterID, cascadeDelete: true)
                .Index(t => t.AppointmentMasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentCancelMasters", "AppointmentMasterID", "dbo.AppointmentMasters");
            DropIndex("dbo.AppointmentCancelMasters", new[] { "AppointmentMasterID" });
            DropTable("dbo.AppointmentCancelMasters");
        }
    }
}
