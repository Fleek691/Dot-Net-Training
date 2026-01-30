public class PipelineProcessor<T>
{
    public void Execute(
        T input,
        Predicate<T> isValid,
        Func<T, T> transformer,
        Action<T> onSuccess,
        Action<string> onFailure)
    {
        if (isValid(input))
        {
            T result = transformer(input);
            onSuccess(result);
        }
        else
        {
            onFailure($"Validation failed for input: {input}");
        }
    }
}

public class Helper3
{
    public static void Main(string[] args)
    {
        // Usage: Processing a Username
        var processor = new PipelineProcessor<string>();

        System.Console.WriteLine("Test 1: Valid username");
        processor.Execute(
            "admin_user",
            u => u.Length > 5,               // Predicate
            u => u.ToUpper(),                // Func
            res => System.Console.WriteLine($"Success: {res}"),   // Action (Success)
            err => System.Console.WriteLine($"Error: {err}")      // Action (Failure)
        );

        System.Console.WriteLine("\nTest 2: Invalid username (too short)");
        processor.Execute(
            "user",
            u => u.Length > 5,               // Predicate
            u => u.ToUpper(),                // Func
            res => System.Console.WriteLine($"Success: {res}"),   // Action (Success)
            err => System.Console.WriteLine($"Error: {err}")      // Action (Failure)
        );
    }
}