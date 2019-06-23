namespace Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointments", "AppointmentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "AppointmentTypeId");
            AddForeignKey("dbo.Appointments", "AppointmentTypeId", "dbo.AppointmentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "AppointmentTypeId", "dbo.AppointmentTypes");
            DropIndex("dbo.Appointments", new[] { "AppointmentTypeId" });
            DropColumn("dbo.Appointments", "AppointmentTypeId");
            DropTable("dbo.AppointmentTypes");
        }
    }
}
