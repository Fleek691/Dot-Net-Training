using System;

public class ThresholdChangedEventArgs<T> : EventArgs
{
    public T? OldValue { get; set; }                   // Previous value
    public T? NewValue { get; set; }                   // Current value
    public string Message { get; set; } = "";          // Info
}

public class ThresholdMonitor<T> where T : IComparable<T>
{
    private readonly T _threshold;                    // Threshold to compare
    private T _current;                               // Current value

    public ThresholdMonitor(T threshold, T initial)
    {
        _threshold = threshold;                       // Save threshold
        _current = initial;                           // Save initial
    }

    public event EventHandler<ThresholdChangedEventArgs<T>>? ThresholdCrossed;

    // ✅ TODO: Students implement only this function
    public void Update(T newValue)
    {
        
        if(newValue.CompareTo(_threshold)>=0 && _current.CompareTo(_threshold)<0){
            var args=new ThresholdChangedEventArgs<T>{
                OldValue=_current,
                NewValue=newValue,
                Message=$"Threshold changed from {_current} to {newValue}"
            };
            ThresholdCrossed?.Invoke(this,args);
        };
        
    }
}

public class Program9
{
    public static void Main()
    {
        var monitor = new ThresholdMonitor<int>(threshold: 100, initial: 90);

        monitor.ThresholdCrossed += (sender, e) =>
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Old={e.OldValue}, New={e.NewValue}");
        };

        monitor.Update(95);                           // No event
        monitor.Update(101);                          // ✅ Event should fire
    }
}