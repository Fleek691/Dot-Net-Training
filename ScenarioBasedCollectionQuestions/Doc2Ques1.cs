// Task 1: Implement Patient class with proper encapsulation
public class Patient
{
    // TODO: Add properties with get/set accessors
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }
    // TODO: Add constructor
}

// Task 2: Implement HospitalManager class
public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        Patient patient = new Patient() { Id = id, Name = name, Age = age, Condition = condition };
        if (_patients.ContainsKey(patient.Id))
        {
            System.Console.WriteLine("Already Present");
            return;
        }
        _patients.Add(patient.Id, patient);
    }

    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        if (!_patients.ContainsKey(patientId))
        {
            System.Console.WriteLine("Not a patient yet");
            return;
        }
        _appointmentQueue.Enqueue(_patients[patientId]);
    }

    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count == 0)
            return null;

        return _appointmentQueue.Dequeue();
    }

    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        // TODO: Use LINQ to filter patients
        return _patients.Values.Where(p => p.Condition == condition).ToList();
    }
}
