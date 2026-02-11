public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

// 1. Generic patient queue with priority
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    // TODO: Enqueue patient with priority (1=highest, 5=lowest)
    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5) throw new ArgumentException("Priority must be between 1 and 5");
        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();
        _queues[priority].Enqueue(patient);
    }

    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        // Return patient from highest non-empty priority
        // Throw if empty
        foreach (var item in _queues.Keys.OrderBy(e => e))
        {
            if (_queues[item].Count > 0)
            {
                return _queues[item].Dequeue();
            }
        }
        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Peek without removing
    public T Peek()
    {
        foreach (var item in _queues)
        {
            if (item.Value.Count > 0)
            {
                return item.Value.Peek();
            }
        }
        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        if (_queues.ContainsKey(priority))
        {
            return _queues[priority].Count;
        }
        return 0;
    }
}

// 2. Generic medical record
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    public MedicalRecord(T patient)
    {
        _patient = patient;
    }
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add(date.ToString() + " " + diagnosis);
    }

    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        if (_treatments.ContainsKey(date)) throw new ArgumentException("Treatment already exists for this date");
        _treatments[date] = treatment;
    }

    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        var history = _treatments.OrderBy(e => e.Key).ToList();
        return history;
    }
}

// 3. Specialized patient types
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; } // in kg
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; } // 1-10
}

// 4. Generic medication system
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    // TODO: Prescribe medication with dosage validation
    public void PrescribeMedication(T patient, string medication,
        Func<T, bool> dosageValidator)
    {
        if (patient == null) throw new Exception();
        if (string.IsNullOrWhiteSpace(medication)) throw new Exception();
        // Check if dosage is valid for patient type
        if (!dosageValidator(patient)) throw new Exception();
        // Initialize list if patient not already present
        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        // Add medication with current timestamp
        _medications[patient].Add((medication, DateTime.Now));
        // Pediatric: weight-based validation
        // Geriatric: kidney function consideration
    }

    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        // Return true if interaction with existing medications
        if(patient==null)throw new Exception();
        if(!_medications.ContainsKey(patient))throw new Exception();
        return _medications[patient].Any(m=>m.medication==newMedication);
    }
}

public class Program
{
    public static void Main()
    {
        // ===============================
        // a) Create Patients
        // ===============================

        var child1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Rohan",
            DateOfBirth = new DateTime(2018, 5, 10),
            BloodType = BloodType.A,
            GuardianName = "Mr. Sharma",
            Weight = 18
        };

        var child2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Aisha",
            DateOfBirth = new DateTime(2016, 8, 15),
            BloodType = BloodType.O,
            GuardianName = "Mrs. Khan",
            Weight = 12
        };

        var elder1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Mr. Rao",
            DateOfBirth = new DateTime(1945, 2, 20),
            BloodType = BloodType.B,
            MobilityScore = 4
        };

        var elder2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mrs. Das",
            DateOfBirth = new DateTime(1940, 9, 1),
            BloodType = BloodType.AB,
            MobilityScore = 2
        };

        // ===============================
        // b) Add to Priority Queue
        // ===============================

        var queue = new PriorityQueue<IPatient>();

        queue.Enqueue(child1, 3);
        queue.Enqueue(elder1, 1); // highest priority
        queue.Enqueue(child2, 2);
        queue.Enqueue(elder2, 1);

        Console.WriteLine("Next Patient (Peek): " + queue.Peek().Name);

        // ===============================
        // c) Create Medical Records
        // ===============================

        var record1 = new MedicalRecord<PediatricPatient>(child1);
        record1.AddDiagnosis("Fever", DateTime.Now.AddDays(-2));
        record1.AddTreatment("Paracetamol", DateTime.Now.AddDays(-1));

        var record2 = new MedicalRecord<GeriatricPatient>(elder1);
        record2.AddDiagnosis("Hypertension", DateTime.Now.AddDays(-5));
        record2.AddTreatment("BP Medication", DateTime.Now.AddDays(-4));

        // ===============================
        // d) Prescribe Medications
        // ===============================

        var medSystem = new MedicationSystem<IPatient>();

        try
        {
            // Pediatric validation (weight-based)
            medSystem.PrescribeMedication(child1, "SyrupX",
                p => p is PediatricPatient ped && ped.Weight > 10);

            // Geriatric validation (mobility-based)
            medSystem.PrescribeMedication(elder1, "TabletY",
                p => p is GeriatricPatient ger && ger.MobilityScore > 2);

            // This will fail (mobility too low)
            medSystem.PrescribeMedication(elder2, "StrongDrug",
                p => p is GeriatricPatient ger && ger.MobilityScore > 2);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Medication Error: " + ex.Message);
        }

        // ===============================
        // e) Demonstrations
        // ===============================

        Console.WriteLine("\n--- Priority-Based Processing ---");

        while (true)
        {
            try
            {
                var patient = queue.Dequeue();
                Console.WriteLine("Processing: " + patient.Name);
            }
            catch
            {
                break;
            }
        }

        Console.WriteLine("\n--- Treatment History ---");

        foreach (var t in record1.GetTreatmentHistory())
        {
            Console.WriteLine($"{t.Key.ToShortDateString()} - {t.Value}");
        }

        Console.WriteLine("\n--- Drug Interaction Check ---");

        bool interaction = medSystem.CheckInteractions(child1, "SyrupX");
        Console.WriteLine("Interaction exists? " + interaction);
    }
}
