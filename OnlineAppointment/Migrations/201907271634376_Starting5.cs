namespace OnlineAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Starting5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointmentMasters", "AppointmentMaster_ID", "dbo.AppointmentMasters");
            DropIndex("dbo.AppointmentMasters", new[] { "AppointmentMaster_ID" });
            CreateTable(
                "dbo.ProcessMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppointmentMasterID = c.Int(nullable: false),
                        ProcessDate = c.DateTime(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppointmentMasters", t => t.AppointmentMasterID, cascadeDelete: true)
                .Index(t => t.AppointmentMasterID);
            
            DropColumn("dbo.AppointmentMasters", "AppointmentMaster_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointmentMasters", "AppointmentMaster_ID", c => c.Int());
            DropForeignKey("dbo.ProcessMasters", "AppointmentMasterID", "dbo.AppointmentMasters");
            DropIndex("dbo.ProcessMasters", new[] { "AppointmentMasterID" });
            DropTable("dbo.ProcessMasters");
            CreateIndex("dbo.AppointmentMasters", "AppointmentMaster_ID");
            AddForeignKey("dbo.AppointmentMasters", "AppointmentMaster_ID", "dbo.AppointmentMasters", "ID");
        }
    }
}
