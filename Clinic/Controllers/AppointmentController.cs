using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        public Dictionary<string, int> Ids { get; set; }

        public AppointmentController()
        {
            Ids = new Dictionary<string, int>();
        }
        // GET: Appointment
        public ActionResult Index(int Id)
        {
            if (User.IsInRole(RolesDefinition.CanManageClinicRole))
            {
                return View(Id);
            }
            else
            {
                return View("ReadOnlyIndex", Id);
            }
        }

        [Authorize(Roles = RolesDefinition.CanManageClinicRole)]
        public ActionResult New(int Id)
        {
            Ids.Add("PatientId", Id);
            Ids.Add("AppointmentId", 0);
return View("AppointmentForm", Ids);
        }

        [Authorize(Roles = RolesDefinition.CanManageClinicRole)]
        public ActionResult Edit(int Id)
        {
            Ids.Add("PatientId", 0);
            Ids.Add("AppointmentId", Id);
            return View("AppointmentForm", Ids);
        }
    }
}