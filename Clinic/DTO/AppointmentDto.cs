using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }

        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }
        public AppointmentTypes AppointmentType { get; set; }

        public int AppointmentTypeId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool IsActiveAppointment { get; set; }
    }
}