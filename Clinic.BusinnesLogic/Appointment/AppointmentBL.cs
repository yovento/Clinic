using System;
using System.Linq;
namespace Clinic.BusinessLogic.Appointment
{
    public class AppointmentBL
    {
        public string AppointmentCanBeCancelled(Clinic.Domain.Appointment appointment)
        {
            if ((DateTime.Now > appointment.AppointmentDate))
                return "The appointment date is previous than today, you can´t cancel it";

            if ((appointment.AppointmentDate - DateTime.Now).TotalHours < Clinic.Domain.Appointment.HoursToCancelation)
                return "You can only cancel appointments with at least " + Clinic.Domain.Appointment.HoursToCancelation.ToString() + " hours of anticipation";

            return "";
        }

        public string AppointmentCanBeCreated(Clinic.Domain.Appointment appointment)
        {
            Repositories.IAppointmentRepository repository = new Repositories.AppointmentRepository();

            var pacientAppointment = repository.GetAppointmentsByPacientId(appointment.PatientId).Where(a => a.AppointmentDate.ToShortDateString() == appointment.AppointmentDate.ToShortDateString()).FirstOrDefault();

            if (pacientAppointment != null)
                return "Patient already has a appointment for the selected date, select another date";
            
            return "";
        }
    }
}
