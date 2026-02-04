using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    public class HospitalManager
    {
        public void AddPatient(string name, int age, string bloodGroup)
        {
        }

        public void AddDoctor(string name, string specialization)
        {
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            return false;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return null;
        }

        public List<Appointment> GetTodayAppointments()
        {
            return null;
        }
    }
}
