public class Robot
{
    public static void Main(string[] args)
    {
        RobotazardAuditor robo = new RobotazardAuditor();
        Console.WriteLine("Enter Arm Precision (0.0 - 1.0): ");
        double armPrecision = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Worker Density (1 - 20): ");
        int workerDensity = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical): ");
        string machineryState = Console.ReadLine()!;

        try
        {
            double result = robo.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
            Console.WriteLine($"Robot Hazard Risk Score: {result}");
        }
        catch (RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
public class RobotazardAuditor
{
    // Calculates hazard risk based on arm precision, worker density, and machinery state
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        double riskFactor = 0;
        double risk = 0;

        // Validate arm precision (0.0 - 1.0)
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validate worker density (1 - 20)
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Validate machinery state
        if (machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Set risk factor based on machinery state
        if (machineryState == "Worn")
        {
            riskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            riskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            riskFactor = 3.0;
        }

        // Calculate total risk
        risk = ((1.0 - armPrecision) * 15.0) + (workerDensity * riskFactor);
        return risk;
    }
}
// Custom exception for robot safety validation
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
    }
}