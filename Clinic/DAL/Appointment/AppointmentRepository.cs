using AutoMapper;
using Clinic.DTO;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Clinic.DAL
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
    }
}