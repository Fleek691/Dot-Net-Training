public class ForensicReport
{
    private Dictionary<string, DateTime> reportMap = new Dictionary<string, DateTime>();

    public void addReportDetails(string reportingOfficerName, DateTime reportFiledDate)
    {
        // overwrite if same officer appears again
        reportMap[reportingOfficerName] = reportFiledDate;
    }

    public List<string> getOfficersWhoFiledReportsOnDate(DateTime reportFiledDate)
    {
        return reportMap
               .Where(x => x.Value.Date == reportFiledDate.Date)
               .Select(x => x.Key)
               .ToList();
    }
}


public class UserInterfaceC2
{
    public static void Main(string[] args)
    {
        ForensicReport forensicReport = new ForensicReport();

        Console.WriteLine("Enter number of reports to be added");
        int n = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter the Forensic reports (Reporting Officer: Report Filed Date)");
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()!;
            string[] parts = input.Split(":");

            string officer = parts[0];
            DateTime date = DateTime.Parse(parts[1]);

            forensicReport.addReportDetails(officer, date);
        }

        Console.WriteLine("Enter the filed date to identify the reporting officers");
        DateTime searchDate = DateTime.Parse(Console.ReadLine()!);

        List<string> result =
            forensicReport.getOfficersWhoFiledReportsOnDate(searchDate);

        if (result.Count == 0)
        {
            Console.WriteLine("No reporting officer filed the report");
        }
        else
        {
            Console.WriteLine($"Reports filed on the {searchDate:yyyy-MM-dd} are by");
            foreach (string name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
