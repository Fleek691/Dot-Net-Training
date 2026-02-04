using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public List<string> MedicalHistory { get; set; }
    }
}
