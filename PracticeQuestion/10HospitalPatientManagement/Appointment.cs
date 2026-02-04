using System;

namespace HospitalPatientManagement
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; } // Scheduled/Completed/Cancelled
        public Appointment(int id,int pId,int dId,DateTime time)
        {
            AppointmentId=id;
            PatientId=pId;
            DoctorId=dId;
            AppointmentTime=time;
            Status="Scheduled";
        }
    }
}

