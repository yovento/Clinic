using AutoMapper;
using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clinic.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public int CreateAppointment(Appointment appointment)
        {
            Insert(appointment);

            SaveChanges();

            return appointment.Id;
        }

        public void DeleteAppointment(int Id)
        {
            var AppointmentInDb = GetById(Id);

            Delete(AppointmentInDb);

            SaveChanges();
        }

        public Appointment GetAppointmentById(int Id)
        {
            return GetById(Id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return GetAll().ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsByPacientId(int PacientId)
        {
            return GetAll().Include(a => a.AppointmentType).Where(a => a.PatientId == PacientId);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            var AppointmentInDb = GetById(appointment.Id);
            
            Mapper.Map(appointment, AppointmentInDb);

            SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}