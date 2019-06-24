using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DAL
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();

        Patient GetPatientById(int Id);

        int CreatePatient(Patient pacient);

        void UpdatePatient(Patient pacient);

        void DeletePatient(int Id);
    }
}