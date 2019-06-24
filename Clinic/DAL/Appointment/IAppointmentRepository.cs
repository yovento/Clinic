using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DAL
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointmentsByPacientId(int PacientId);
        
        Appointment GetAppointmentById(int Id);

        int CreateAppointment(Appointment appointment);

        void UpdateAppointment(Appointment appointment);

        void DeleteAppointment(int Id);
    }
}