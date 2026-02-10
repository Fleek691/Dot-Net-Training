// // NOTE: Each solution below is SELF-CONTAINED and includes required demo types.
// // These demo types exist only to make Reflection questions testable in a single file.
// // Type names used in sample inputs belong to this namespace: Assessment

// namespace Assessment
// {
//     using System;

//     // ----- Attributes -----
//     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
//     public sealed class LabelAttribute : Attribute
//     {
//         public string Name { get; }
//         public int Level { get; set; }
//         public bool Enabled { get; set; }
//         public LabelAttribute(string name) { Name = name; }
//     }

//     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
//     public sealed class PluginAttribute : Attribute
//     {
//         public string Name { get; }
//         public PluginAttribute(string name) { Name = name; }
//     }

//     // ----- Interfaces -----
//     public interface IPlugin { string Run(); }

//     // ----- Base/Derived for inheritance tests -----
//     public class BaseSample
//     {
//         private int baseSecret = 7;
//         protected string baseToken = "BASE";
//         internal double baseRate = 1.5;
//         public string PublicBase = "PB";

//         private void BasePrivate() { }
//         protected void BaseProtected() { }
//         internal void BaseInternal() { }
//         public void BasePublic() { }
//     }

//     [Label("PII", Level = 3, Enabled = true)]
//     public class DerivedSample : BaseSample
//     {
//         private int secret = 99;
//         protected int ProtectedValue = 10;
//         internal string InternalValue = "IN";
//         public string Name { get; set; } = "Gopi";
//         public int Age { get; set; } = 25;

//         private void Hidden() { }
//         protected void Shield() { }
//         internal void Inside() { }
//         public void Visible() { }

//         public int Sum(int a, int b) => a + b;
//         public long Sum(long a, long b) => a + b;
//         public double Sum(double a, double b) => a + b;
//         public string Sum(string a, string b) => a + b;

//         public System.Threading.Tasks.Task AsyncPing() => System.Threading.Tasks.Task.Delay(10);
//         public System.Threading.Tasks.ValueTask<int> AsyncValue() => new System.Threading.Tasks.ValueTask<int>(42);
//     }

//     // ----- For property attribute test -----
//     public class DisplayModel
//     {
//         [System.ComponentModel.DisplayName("Customer Name")]
//         public string CustomerName { get; set; } = "Arjun";
//         public int Score { get; set; } = 100;
//     }

//     // ----- Plugins -----
//     [Plugin("alpha")]
//     public class PluginA : IPlugin { public string Run() => "A"; }

//     [Plugin("beta")]
//     public class PluginB : IPlugin { public string Run() => "B"; }

//     // ----- Generic host for MakeGenericMethod -----
//     public class GenericHost
//     {
//         public T Echo<T>(T value) => value;
//     }

//     // ----- Class with private ctor -----
//     public class SecretCtor
//     {
//         private SecretCtor() { }
//         public static SecretCtor CreatePublic() => new SecretCtor();
//     }

//     // ----- For delegate performance test -----
//     public class Calc
//     {
//         public int Square(int x) => x * x;
//     }

//     // ----- Generic type definitions for scan -----
//     public class Repository<T> { }
//     public class Service<T1, T2> { }

//     // ----- Extension methods -----
//     public static class DerivedExtensions
//     {
//         public static string Shout(this DerivedSample d) => d.Name.ToUpperInvariant();
//         public static int AddAge(this DerivedSample d, int inc) => d.Age + inc;
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
        
//     }
// }
