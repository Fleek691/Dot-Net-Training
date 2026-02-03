public class Robot
{
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