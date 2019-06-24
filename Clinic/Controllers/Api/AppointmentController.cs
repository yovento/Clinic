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
using Clinic.App_Start;
using Autofac;
using Microsoft.AspNet.Identity.EntityFramework;
using Clinic.DAL;

namespace Clinic.Controllers.Api
{
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private AppointmentRepository _repository { get; set; }
        private AppointmentTypesRepository _repositoryAppoinmentTypes { get; set; }

        public AppointmentController()
        {
            _repository = IocConfig.GetInstance<AppointmentRepository>();
            _repositoryAppoinmentTypes = IocConfig.GetInstance<AppointmentTypesRepository>();
        }

        [Route("GetAppointments")]
        public IHttpActionResult GetAppointments(int PatientId)
        {
            return Ok(_repository.GetAppointmentsByPacientId(PatientId).Select(Mapper.Map<Appointment, AppointmentDto>));            
        }

        [Route("GetAppointmentTypes")]
        public IHttpActionResult GetAppointmentTypes()
        {
            return Ok(_repositoryAppoinmentTypes.GetAppointmentTypes().Select(Mapper.Map<AppointmentTypes, AppointmentTypeDto>));
        }

        [Route("GetAppointment")]
        public IHttpActionResult GetAppointment(int Id)
        {
            var Appointment = _repository.GetAppointmentById(Id);

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

            Appointment.Id = _repository.CreateAppointment(Appointment);

            return Ok(Appointment.Id);
        }

        [HttpPut]
        public IHttpActionResult UpdateAppointment(AppointmentDto AppointmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AppointmentInDb = _repository.GetAppointmentById(AppointmentDto.Id);

            if (AppointmentInDb == null)
                return NotFound();

            Mapper.Map<AppointmentDto, Appointment>(AppointmentDto, AppointmentInDb);

            _repository.UpdateAppointment(AppointmentInDb);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAppointment(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AppointmentInDb = _repository.GetAppointmentById(Id);

            if (AppointmentInDb == null)
                return NotFound();

            _repository.DeleteAppointment(Id);

            return Ok();
        }
    }
}
