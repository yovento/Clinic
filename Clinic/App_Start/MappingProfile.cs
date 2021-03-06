﻿using AutoMapper;
using Clinic.DTO;
using Clinic.Models;
using Clinic.Domain;
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
            Mapper.CreateMap<PatientDTO, Patient>();

            Mapper.CreateMap<Appointment, AppointmentDto>();
            Mapper.CreateMap<AppointmentDto, Appointment>();

            Mapper.CreateMap<AppointmentTypes, AppointmentTypeDto>();
            Mapper.CreateMap<AppointmentTypeDto, AppointmentTypes>();
        }
    }
}