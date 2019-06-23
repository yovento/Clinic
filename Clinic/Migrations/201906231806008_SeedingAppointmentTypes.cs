namespace Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingAppointmentTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Medicina General')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Odontología')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Pediatría')");
            Sql("INSERT INTO AppointmentTypes (Name) VALUES ('Neurología')");
        }
        
        public override void Down()
        {
        }
    }
}
