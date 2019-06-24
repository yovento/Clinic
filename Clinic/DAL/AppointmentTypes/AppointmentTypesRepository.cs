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
    public class AppointmentTypesRepository : BaseRepository<AppointmentTypes>, IAppointmentTypesRepository
    {        
        public IEnumerable<AppointmentTypes> GetAppointmentTypes()
        {
            return GetAll().ToList();
        }
    }
}