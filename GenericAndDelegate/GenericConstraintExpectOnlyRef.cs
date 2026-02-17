using System;

public class Program3
{
    public static void Main()
    {
        var cache = new RefCache<string>();         // ✅ Allowed (string is class)
        cache.Set(null);                            // Store null
        Console.WriteLine(cache.GetOrDefault("NA")); // Expected: NA

        cache.Set("Hello");
        Console.WriteLine(cache.GetOrDefault("NA")); // Expected: Hello

        // var wrong = new RefCache<int>();          // ❌ Should not compile because int is a struct
    }
}

public class RefCache<T> where T : class            // Constraint: only reference type
{
    private T? _value;                              // Nullable reference

    public void Set(T? value)
    {
        _value = value;                             // Save value
    }

    // ✅ TODO: Students implement this
    public T GetOrDefault(T defaultValue)
    {
        // TODO: if _value is null, return defaultValue, else return _value
        if (_value == null)
        {
            return defaultValue;
        }
        return _value!;
    }
}