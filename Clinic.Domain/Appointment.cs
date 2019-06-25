using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic.Domain
{
    public class Appointment
    {
        public static int HoursToCancelation = 24;
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

        

        public bool CanBeCreated(Appointment appointment)
        {
            if ((appointment.AppointmentDate - DateTime.Now).TotalHours < Appointment.HoursToCancelation)
                return false;

            return true;
        }
    }
}