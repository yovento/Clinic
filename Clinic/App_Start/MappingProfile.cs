using AutoMapper;
using Clinic.DTO;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDTO>();
        }
    }
}