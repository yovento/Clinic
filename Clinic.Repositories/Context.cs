using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repositories
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentTypes> AppointmentTypes { get; set; }

        
    }
}
