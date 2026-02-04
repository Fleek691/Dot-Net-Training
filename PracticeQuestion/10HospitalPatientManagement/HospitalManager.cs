using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalPatientManagement
{
    public class HospitalManager
    {
        private int pId = 1;
        private int dId = 1;
        private int AId = 1;
        private Dictionary<int, Patient> patientsList = new Dictionary<int, Patient>();
        private Dictionary<int, Doctor> doctorList = new Dictionary<int, Doctor>();
        private Dictionary<int, Appointment> appointments = new Dictionary<int, Appointment>();
        public void AddPatient(string name, int age, string bloodGroup)
        {
            if (!patientsList.ContainsKey(pId))
            {
                patientsList[pId] = new Patient(pId, name, age, bloodGroup);
                pId++;
            }
            else
            {
                System.Console.WriteLine("Patient already exists");
            }
        }

        public void AddDoctor(string name, string specialization)
        {
            if (!doctorList.ContainsKey(dId))
            {
                doctorList[dId] = new Doctor(dId, name, specialization);
                dId++;
            }
            else
            {
                System.Console.WriteLine("Doctor already exists");
            }
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            if (!patientsList.ContainsKey(patientId)) return false;
            if (!doctorList.ContainsKey(doctorId)) return false;
            if (!doctorList[doctorId].AvailableSlots.Contains(time)) return false;

            //Check for conflicting appointment
            bool conflict = appointments.Values.Any(a =>
                a.DoctorId == doctorId &&
                a.AppointmentTime == time &&
                a.Status == "Scheduled"
            );

            if (conflict)
                return false;

            // 5️⃣ Schedule appointment
            appointments.Add(
                AId,
                new Appointment(AId, patientId, doctorId, time)
            );

            AId++;

            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            var a = doctorList.Values.GroupBy(e => e.Specialization).ToDictionary(g => g.Key, g => g.ToList());
            return a;
        }

        public List<Appointment> GetTodayAppointments()
        {
            var apt = appointments.Values.Where(e => e.AppointmentTime.Date == DateTime.Today).ToList();
            return apt;
        }
    }
}
