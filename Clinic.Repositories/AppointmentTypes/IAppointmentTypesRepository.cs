using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.Repositories
{
    public interface IAppointmentTypesRepository : IDisposable
    {
        IEnumerable<AppointmentTypes> GetAppointmentTypes();
        
    }
}