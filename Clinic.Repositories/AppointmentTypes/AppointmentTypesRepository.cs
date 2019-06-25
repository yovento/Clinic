using AutoMapper;
using Clinic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Clinic.Repositories
{
    public class AppointmentTypesRepository : BaseRepository<AppointmentTypes>, IAppointmentTypesRepository
    {        
        public IEnumerable<AppointmentTypes> GetAppointmentTypes()
        {
            return GetAll().ToList();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}