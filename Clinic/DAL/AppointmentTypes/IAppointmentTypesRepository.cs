using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DAL
{
    public interface IAppointmentTypesRepository
    {
        IEnumerable<AppointmentTypes> GetAppointmentTypes();
        
    }
}