using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Clinic.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using Clinic.DAL;

namespace Clinic.App_Start
{
    public class IocConfig
    {
        public static IContainer container { get; set; }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<Patient>();
            builder.RegisterType<Appointment>();
            builder.RegisterType<PatientRepository>();
            builder.RegisterType<AppointmentRepository>();
            builder.RegisterType<AppointmentTypesRepository>();

            container = builder.Build();
            
        }
        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }
    }
}