using Clinic.BusinessLogic.Appointment;
using Clinic.Domain;
using Clinic.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Tests.BusinessLogic
{
    [TestFixture]
    public class AppointmentBLTests
    {
        private AppointmentBL _BL;

        [SetUp]
        public void Setup()
        {
            _BL = new AppointmentBL();
        }

        [Test]
        [TestCase(25)]
        [TestCase(23)]
        public void AppointmentCanBeCancelled_WhenCalled_ValidateHoursCancelWindow(int Hours)
        {
            var result = _BL.AppointmentCanBeCancelled(new Appointment { AppointmentDate = DateTime.Now.AddHours(Hours) });

            if (Hours > AppointmentBL.HoursToCancelation)
                Assert.That(result, Is.EqualTo(""));
            else
                Assert.That(result, Is.Not.EqualTo(""));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void AppointmentCanBeCreated_WhenCalled_ValidateIfAnAppointmentCanBeCreated(int PacientId)
        {
             var repository = new Mock<IAppointmentRepository>();

            if (PacientId == 0)
                repository.Setup(r => r.GetAppointmentsByPacientId(PacientId)).Returns((new List<Appointment> { new Appointment { AppointmentDate = DateTime.Now} }).AsEnumerable());
            else
                repository.Setup(r => r.GetAppointmentsByPacientId(PacientId)).Returns((new List<Appointment> { }).AsEnumerable());

            var result = _BL.AppointmentCanBeCreated(new Appointment { AppointmentDate = DateTime.Now, PatientId = PacientId}, repository.Object);
            
            if (PacientId == 0)
                Assert.That(result, Is.Not.EqualTo(""));
            else
                Assert.That(result, Is.EqualTo(""));
        }
    }
}
