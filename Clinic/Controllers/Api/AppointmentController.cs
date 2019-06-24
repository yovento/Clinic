using AutoMapper;
using Clinic.DTO;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Clinic.Controllers.Api
{
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AppointmentController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Route("GetAppointments")]
        public IHttpActionResult GetAppointments(int PatientId)
        {
            return Ok(_dbContext.Appointments.Include(a => a.AppointmentType).Where(a => a.PatientId == PatientId).ToList().Select(Mapper.Map<Appointment, AppointmentDto>));
        }

        [Route("GetAppointmentTypes")]
        public IHttpActionResult GetAppointmentTypes()
        {
            return Ok(_dbContext.AppointmentTypes.ToList().Select(Mapper.Map<AppointmentTypes, AppointmentTypeDto>));
        }

        [Route("GetAppointment")]
        public IHttpActionResult GetAppointment(int Id)
        {
            var Appointment = _dbContext.Appointments.SingleOrDefault(c => c.Id == Id);

            if (Appointment == null)
                return NotFound();

            return Ok(Mapper.Map<Appointment, AppointmentDto>(Appointment));
        }

        [HttpPost]
        public IHttpActionResult CreateAppointment(AppointmentDto AppointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Appointment = Mapper.Map<AppointmentDto, Appointment>(AppointmentDto);
            _dbContext.Appointments.Add(Appointment);
            _dbContext.SaveChanges();
            AppointmentDto.Id = Appointment.Id;

            return Ok(Appointment.Id);
        }

        [HttpPut]
        public IHttpActionResult UpdateAppointment(AppointmentDto AppointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AppointmentInDb = _dbContext.Appointments.Single(c => c.Id == AppointmentDto.Id);

            if (AppointmentInDb == null)
                return NotFound();

            Mapper.Map<AppointmentDto, Appointment>(AppointmentDto, AppointmentInDb);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAppointment(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AppointmentInDb = _dbContext.Appointments.Single(c => c.Id == Id);

            if (AppointmentInDb == null)
                return NotFound();

            _dbContext.Appointments.Remove(AppointmentInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
