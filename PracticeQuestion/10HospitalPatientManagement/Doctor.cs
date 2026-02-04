using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<DateTime> AvailableSlots { get; set; }
    }
}
