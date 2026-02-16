using System.Collections.Generic;
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
        // Validate priority range
        if (priority < 1 || priority > 5)
        {
            System.Console.WriteLine("Invalid Priority");
            return;
        }
        if (!_queues.ContainsKey(priority))
        {
            _queues[priority] = new Queue<T>();
        }
        _queues[priority].Enqueue(patient);
        System.Console.WriteLine("Added Succesfully");
        // Create queue if doesn't exist for priority
    }

    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        // Return patient from highest non-empty priority
        var a = _queues.OrderBy(e => e.Key).Where(e => e.Value.Count > 0).FirstOrDefault();
        if (a.Value == null || a.Value.Count == 0)
        {
            throw new ArgumentNullException();

        }
        return a.Value.Dequeue();


        // Throw if empty
    }

    // TODO: Peek without removing
    public T Peek()
    {
        // Look at next patient
        var a = _queues.OrderBy(e => e.Key).Where(e => e.Value.Count > 0).FirstOrDefault();
        if (a.Value == null || a.Value.Count == 0)
        {
            throw new ArgumentNullException();

        }
        return a.Value.Peek();
    }

    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        if (!_queues.ContainsKey(priority))
        {
            System.Console.WriteLine("no patients");
            return 0;
        }
        return _queues[priority].Count;
    }
}

// 2. Generic medical record
public class MedicalRecord<T> where T : IPatient
{
    private T? _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        if (_diagnoses.Contains(diagnosis))
        {
            System.Console.WriteLine("Already present");
            return;
        }
        _diagnoses.Add(diagnosis);
        System.Console.WriteLine("Added");

    }

    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        if (_treatments.ContainsKey(date))
        {
            System.Console.WriteLine("Already Present");
            return;
        }
        _treatments[date] = treatment;
        System.Console.WriteLine("Added Successfully");
    }

    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        // Return sorted by date
        SortedDictionary<DateTime, string> treatmentHistory = new SortedDictionary<DateTime, string>(_treatments);
        return (IEnumerable<KeyValuePair<DateTime, string>>)treatmentHistory;
    }
}

// 3. Specialized patient types
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string? GuardianName { get; set; }
    public double Weight { get; set; } // in kg
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string? Name { get; set; }
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
        // Validate dosage using the provided validator
        if (!dosageValidator(patient))
        {
            System.Console.WriteLine("Dosage validation failed");
            return;
        }

        // Create entry if patient not in dictionary yet
        if (!_medications.ContainsKey(patient))
        {
            _medications[patient] = new List<(string, DateTime)>();
        }

        // Add medication with current timestamp
        _medications[patient].Add((medication, DateTime.Now));
        System.Console.WriteLine($"Medication '{medication}' prescribed successfully");  // Check if dosage is valid for patient type

        // Pediatric: weight-based validation
        // Geriatric: kidney function consideration
    }

    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        // Return true if interaction with existing medications
        if(!_medications.ContainsKey(patient))return false;
        return true;
    }
}

// 5. TEST SCENARIO: Simulate hospital workflow
// a) Create 2 PediatricPatient and 2 GeriatricPatient
// b) Add them to priority queue with different priorities
// c) Create medical records with diagnoses/treatments
// d) Prescribe medications with type-specific validation
// e) Demonstrate:
//    - Priority-based patient processing
//    - Age-specific medication validation
//    - Treatment history retrieval
//    - Drug interaction checking
public class Program3
{
        public static void Main()
    {
        // 1. Create 2 PediatricPatient and 2 GeriatricPatient
        var pediatric1 = new PediatricPatient 
        { 
            PatientId = 1, 
            Name = "Tommy", 
            DateOfBirth = new DateTime(2020, 5, 15),
            BloodType = BloodType.O,
            GuardianName = "John Smith",
            Weight = 30
        };
        
        var pediatric2 = new PediatricPatient 
        { 
            PatientId = 2, 
            Name = "Sarah", 
            DateOfBirth = new DateTime(2019, 8, 22),
            BloodType = BloodType.A,
            GuardianName = "Jane Smith",
            Weight = 35
        };
        
        var geriatric1 = new GeriatricPatient 
        { 
            PatientId = 3, 
            Name = "Mr. Johnson", 
            DateOfBirth = new DateTime(1950, 3, 10),
            BloodType = BloodType.B,
            MobilityScore = 6
        };
        geriatric1.ChronicConditions.Add("Diabetes");
        geriatric1.ChronicConditions.Add("Hypertension");
        
        var geriatric2 = new GeriatricPatient 
        { 
            PatientId = 4, 
            Name = "Mrs. Williams", 
            DateOfBirth = new DateTime(1948, 11, 5),
            BloodType = BloodType.AB,
            MobilityScore = 4
        };
        geriatric2.ChronicConditions.Add("Arthritis");
        
        // 2. Add them to priority queue with different priorities
        var pq = new PriorityQueue<IPatient>();
        pq.Enqueue(pediatric1, 2);
        pq.Enqueue(geriatric1, 1); // Highest priority
        pq.Enqueue(pediatric2, 3);
        pq.Enqueue(geriatric2, 2);
        
        System.Console.WriteLine("=== Patient Queue Status ===");
        System.Console.WriteLine($"Priority 1: {pq.GetCountByPriority(1)} patient");
        System.Console.WriteLine($"Priority 2: {pq.GetCountByPriority(2)} patients");
        System.Console.WriteLine($"Priority 3: {pq.GetCountByPriority(3)} patient");
        System.Console.WriteLine();
        
        // 3. Create medical records with diagnoses/treatments
        var pediatricRecord = new MedicalRecord<PediatricPatient>();
        pediatricRecord.AddDiagnosis("Fever", DateTime.Now);
        pediatricRecord.AddDiagnosis("Common Cold", DateTime.Now.AddHours(1));
        pediatricRecord.AddTreatment("Paracetamol", DateTime.Now.AddHours(2));
        pediatricRecord.AddTreatment("Rest", DateTime.Now.AddHours(3));
        
        var geriatricRecord = new MedicalRecord<GeriatricPatient>();
        geriatricRecord.AddDiagnosis("Hypertension", DateTime.Now);
        geriatricRecord.AddTreatment("Amlodipine", DateTime.Now.AddHours(1));
        geriatricRecord.AddTreatment("Blood Pressure Monitoring", DateTime.Now.AddHours(2));
        
        System.Console.WriteLine("=== Pediatric Treatment History ===");
        foreach (var treatment in pediatricRecord.GetTreatmentHistory())
        {
            System.Console.WriteLine($"{treatment.Key}: {treatment.Value}");
        }
        System.Console.WriteLine();
        
        // 4. Prescribe medications with type-specific validation
        var medicationSys = new MedicationSystem<PediatricPatient>();
        
        // Pediatric validator (weight-based: 20-80 kg)
        Func<PediatricPatient, bool> pediatricValidator = p => p.Weight > 20 && p.Weight < 80;
        
        System.Console.WriteLine("=== Prescribing Medications ===");
        medicationSys.PrescribeMedication(pediatric1, "Amoxicillin", pediatricValidator);
        medicationSys.PrescribeMedication(pediatric2, "Ibuprofen", pediatricValidator);
        System.Console.WriteLine();
        
        // 5. Demonstrate drug interaction checking
        System.Console.WriteLine("=== Checking Drug Interactions ===");
        bool hasInteraction1 = medicationSys.CheckInteractions(pediatric1, "Methotrexate");
        System.Console.WriteLine($"Amoxicillin + Methotrexate interaction: {hasInteraction1}");
        
        bool hasInteraction2 = medicationSys.CheckInteractions(pediatric2, "Aspirin");
        System.Console.WriteLine($"Ibuprofen + Aspirin interaction: {hasInteraction2}");
        System.Console.WriteLine();
        
        // 6. Process patients from priority queue
        System.Console.WriteLine("=== Processing Patients by Priority ===");
        try
        {
            var nextPatient = pq.Dequeue();
            System.Console.WriteLine($"Next patient to process: {nextPatient.Name} (Priority 1)");
            
            var peekedPatient = pq.Peek();
            System.Console.WriteLine($"Next in queue (peeked): {peekedPatient.Name}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}