using AutoMapper;
using Clinic.DTO;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DAL
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public int CreatePatient(Patient pacient)
        {
            Insert(pacient);

            SaveChanges();

            return pacient.Id;
        }

        public void DeletePatient(int Id)
        {
            var PatientInDb = GetById(Id);

            Delete(PatientInDb);

            SaveChanges();
        }

        public Patient GetPatientById(int Id)
        {
            return GetById(Id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return GetAll().ToList();
        }

        public void UpdatePatient(Patient pacient)
        {
            var PatientInDb = GetById(pacient.Id);
            
            Mapper.Map(pacient, PatientInDb);

            SaveChanges();
        }
    }
}