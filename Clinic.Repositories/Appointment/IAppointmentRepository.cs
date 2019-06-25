using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Repositories
{
    public interface IAppointmentRepository : IDisposable
    {
        IEnumerable<Appointment> GetAppointmentsByPacientId(int PacientId);
        
        Appointment GetAppointmentById(int Id);

        int CreateAppointment(Appointment appointment);

        void UpdateAppointment(Appointment appointment);

        void DeleteAppointment(int Id);
    }
}