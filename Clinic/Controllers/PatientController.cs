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
            if (User.IsInRole(RolesDefinition.CanManageClinicRole))
            {
                return View();
            }
            else
            {
                return View("ReadOnlyIndex");
            }            
        }

        [Authorize(Roles = RolesDefinition.CanManageClinicRole)]
        public ActionResult New()
        {
            return View("PatientForm", 0);
        }

        [Authorize(Roles = RolesDefinition.CanManageClinicRole)]
        public ActionResult Edit(int Id)
        {
            return View("PatientForm", Id);
        }
    }
}