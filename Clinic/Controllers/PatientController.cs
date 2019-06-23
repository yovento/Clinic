using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext _dbContext;

        public PatientController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Patient
        public ActionResult Index()
        {
            var patients = _dbContext.Patients.ToList();
            return View(patients);
        }
    }
}