using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public int PatientId { get; set; }
        public AppointmentTypes AppointmentType { get; set; }

        [Required]
        public int AppointmentTypeId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public bool IsActiveAppointment { get; set; }

    }
}