namespace Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingAppointmentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Medicina General')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Odontolog�a')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Pediatr�a')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Neurolog�a')");
        }
        
        public override void Down()
        {
        }
    }
}
