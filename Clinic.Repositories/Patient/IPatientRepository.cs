using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Repositories
{
    public interface IPatientRepository : IDisposable
    {
        IEnumerable<Patient> GetPatients();

        Patient GetPatientById(int Id);

        int CreatePatient(Patient pacient);

        void UpdatePatient(Patient pacient);

        void DeletePatient(int Id);
    }
}