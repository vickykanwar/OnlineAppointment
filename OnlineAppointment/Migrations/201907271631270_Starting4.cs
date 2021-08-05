namespace OnlineAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Starting4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointmentMasters", "AppointmentMaster_ID", c => c.Int());
            CreateIndex("dbo.AppointmentMasters", "AppointmentMaster_ID");
            AddForeignKey("dbo.AppointmentMasters", "AppointmentMaster_ID", "dbo.AppointmentMasters", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentMasters", "AppointmentMaster_ID", "dbo.AppointmentMasters");
            DropIndex("dbo.AppointmentMasters", new[] { "AppointmentMaster_ID" });
            DropColumn("dbo.AppointmentMasters", "AppointmentMaster_ID");
        }
    }
}
