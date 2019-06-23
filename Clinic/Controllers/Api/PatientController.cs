using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clinic.DTO;
using Clinic.Models;
using AutoMapper;

namespace Clinic.Controllers.Api
{
    public class PatientController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public PatientController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IHttpActionResult GetPatient()
        {
            return Ok(_dbContext.Patients.ToList().Select(Mapper.Map<Patient, PatientDTO>));
        }

        public IHttpActionResult GetPatient(int Id)
        {
            var Patient = _dbContext.Patients.SingleOrDefault(c => c.Id == Id);

            if (Patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientDTO>(Patient));
        }

        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDTO PatientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Patient = Mapper.Map<PatientDTO, Patient>(PatientDto);
            _dbContext.Patients.Add(Patient);
            _dbContext.SaveChanges();
            PatientDto.Id = Patient.Id;

            return Created(new Uri(Request.RequestUri + "/" + Patient.Id), PatientDto);
        }

        [HttpPut]
        public IHttpActionResult UpdatePatient(int Id, PatientDTO PatientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var PatientInDb = _dbContext.Patients.Single(c => c.Id == Id);

            if (PatientInDb == null)
                return NotFound();

            Mapper.Map<PatientDTO, Patient>(PatientDto, PatientInDb);

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePatient(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var PatientInDb = _dbContext.Patients.Single(c => c.Id == Id);

            if (PatientInDb == null)
                return NotFound();

            _dbContext.Patients.Remove(PatientInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
