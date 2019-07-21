﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.DTO
{
    /*Patient DTO definition*/
    public class PatientDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
    }
}