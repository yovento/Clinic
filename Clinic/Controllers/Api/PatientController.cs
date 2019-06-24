using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clinic.DTO;
using Clinic.Models;
using AutoMapper;
using Clinic.App_Start;
using Clinic.DAL;

namespace Clinic.Controllers.Api
{
    public class PatientController : ApiController
    {
        private PatientRepository _repository { get; set; }
        public PatientController()
        {
            _repository = IocConfig.GetInstance<PatientRepository>();
        }
        public IHttpActionResult GetPatient()
        {
            return Ok(_repository.GetPatients().Select(Mapper.Map<Patient, PatientDTO>));
        }

        public IHttpActionResult GetPatient(int Id)
        {
            var Patient = _repository.GetPatientById(Id);
            
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

            Patient.Id = _repository.CreatePatient(Patient);

            return Ok(Patient.Id);
        }

        [HttpPut]
        public IHttpActionResult UpdatePatient(PatientDTO PatientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var PatientInDb = _repository.GetPatientById(PatientDto.Id);
            
            if (PatientInDb == null)
                return NotFound();

            Mapper.Map<PatientDTO, Patient>(PatientDto, PatientInDb);

            _repository.UpdatePatient(PatientInDb);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePatient(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var PatientInDb = _repository.GetPatientById(Id);

            if (PatientInDb == null)
                return NotFound();
            
            _repository.DeletePatient(Id);

            return Ok();
        }
    }
}
