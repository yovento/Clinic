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
            return View();
        }

        public ActionResult New()
        {
            return View("PatientForm", 0);
        }

        public ActionResult Edit(int Id)
        {
            return View("PatientForm", Id);
        }
    }
}