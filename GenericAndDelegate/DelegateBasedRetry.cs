using System;

public class Program10
{
    private static int _tries = 0;                    // Simulation counter

    public static void Main()
    {
        // A function that fails twice, then succeeds
        int result = ExecuteWithRetry(() =>
        {
            _tries++;
            if (_tries <= 2) throw new InvalidOperationException("Temporary failure");
            return 999;
        }, maxAttempts: 3);

        Console.WriteLine(result);                    // Expected: 999
    }

    // ✅ TODO: Students implement only this function
    public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
    {
        // TODO:
        // 1) Validate inputs
        if (work == null) throw new Exception(nameof(work));
        if (maxAttempts <= 0) throw new ArgumentException("maxAttempts must be greater than 0");

        // 2) Try executing work
        // 3) If exception occurs and attempts remain, retry
        // 4) If attempts exhausted, throw last exception
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return work();
            }
            catch (Exception)
            {
                if (attempt == maxAttempts)
                {
                    throw;
                }
            }
        }

        return default!;
    }
}