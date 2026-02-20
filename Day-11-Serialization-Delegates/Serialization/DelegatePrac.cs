// using System;

// public delegate int Calculator(int x, int y);

// public class Program
// {
//     public static void Main()
//     {
//         Calculator add = Add;
//         Calculator subtract = Subtract;
//         Calculator multiply = Multiply;

//         Console.WriteLine("Addition: " + add(4, 5));
//         Console.WriteLine("Subtraction: " + subtract(4, 5));
//         Console.WriteLine("Multiplication: " + multiply(4, 5));
//     }

//     public static int Add(int x, int y) => x + y;

//     public static int Subtract(int x, int y) => x - y;

//     public static int Multiply(int x, int y) => x * y;
// }

// public delegate void MultiDel(string input);
// public class Pr
// {
//     public static void Main()
//     {
//         MultiDel del;
//         System.Console.WriteLine("Enter string: ");
//         string input=Console.ReadLine()!;
//         del=InUpper;
//         del+=InLower;
//         del+=Lengths;
//         del.Invoke(input);
//     }

//     public static void InUpper(string input)
//     {
//         System.Console.WriteLine($"Message to Upper: {input.ToUpper()}");
//     }
//     public static void InLower(string input)
//     {
//         System.Console.WriteLine($"Message to Lower: {input.ToLower()}");
//     }
//     public static void Lengths(string input)
//     {
//         System.Console.WriteLine($"Message Length: {input.Length}");
//     }
// }


// public class Program1
// {
//     public static void Main()
//     {
//         Func<int ,int,int >divide=(a,b)=>a/b;
//         Func<int,int,int>modulos=(a,b)=>a%b;
//         int result=divide(4,2);
//         int modulo=modulos(10,2);
//         System.Console.WriteLine($"Division={result},Modulos: {modulo}");

//         string input=Console.ReadLine()!;
//         Action<string>printer=a=>System.Console.WriteLine(a.ToUpper());

//         printer(input);

//         Predicate<int>IsEVen=a=>a%2==0;
//         Predicate<int>Great=a=>a>100;
//         int num=int.Parse(Console.ReadLine()!);
//         if (IsEVen(num))
//         {
//             System.Console.WriteLine("Even");
//         }
//         if (Great(num))
//         {
//             System.Console.WriteLine("Greater than 100");
//         }
//     }
// }
// public delegate void Notifier(string input);
// public class Order
// {
//     public  void ProcessOrder(Notifier notifier)
//     {
//         Console.WriteLine("Processing order...");
//         notifier.Invoke("Order processed successfully!");
//     }
// }
// public class Program1
// {
//     public static void Main()
//     {
//         Notifier notifier=NotifyCustomer;
//         notifier+=EmailNotification;
//         Order order=new Order();
//         order.ProcessOrder(notifier);
//     }
//     public static void NotifyCustomer(string input)
//     {
//         System.Console.WriteLine("Notified: "+input);
//     }
//     public static void EmailNotification(string input)=>System.Console.WriteLine("Email notifcation: "+input);
// }
// public delegate int Operation(int a, int b);
// public class Program1
// {
//     public static void Main()
//     {
//         Operation ops = Add;
//         ops += Subtract;
//         ops += Multiply;
//         int a = ops.Invoke(5, 4);
//         System.Console.WriteLine(a);
//         foreach (Operation op in ops.GetInvocationList())
//         {
//             int result = op(5, 4);
//             Console.WriteLine(result);
//         }

//         System.Console.WriteLine(ops.GetInvocationList().Length);
//     }
//     public static int Add(int a, int b) => a + b;
//     public static int Subtract(int a, int b) => a - b;
//     public static int Multiply(int a, int b) => a * b;
// }
// public delegate T Transformer<T>(T input);
// public class Program1
// {
//     public static void Main()
//     {
//         Transformer<string> Upper=UpperCAse;
//         Transformer<int> square=Square;
//         Transformer<string> reverse=Reverse;
//         System.Console.WriteLine(Upper("Avishek"));
//         System.Console.WriteLine(Square(10));
//         System.Console.WriteLine(reverse("Avsihek"));
//     }
//     public static string UpperCAse(string input)
//     {
//         return input.ToUpper();
//     }
//     public static int Square(int input)
//     {
//         return input*input;
//     }
//     public static string Reverse(string input)
//     {

//         var b=input.Reverse().ToArray();
//         return new string(b);
//     }
// }
// public class UserValidator
// {
//     public bool Validate(string input, Func<string, bool> rule)
//     {
//         return rule(input);
//     }
// }

// public class Program1
// {
//     public static void Main()
//     {
//         Func<string,bool> Rule1 = a =>a.Length>5;
//         Func<string,bool> Rule2 = a =>a.Any(char.IsDigit);
//         Func<string,bool> Rule3 = a =>
//         {
//             char temp=a[0];
//             if(char.IsUpper(temp))return true;
//             return false;
//         };
//         UserValidator validator=new UserValidator();
//         if (validator.Validate("Avishek1", Rule1))
//         {
//             System.Console.WriteLine("Satisfies rule1");
//         }
//         if (validator.Validate("Avishek1", Rule2))
//         {
//             System.Console.WriteLine("Satisfies rule2");
//         }
//         if (validator.Validate("Avishek1", Rule3))
//         {
//             System.Console.WriteLine("Satisfies rule3");
//         }

//     }

// // }
// public class TemperatureMonitor
// {
//     public event Action<int>? TemperatureExceed;
//     public void CheckTemperature(int temp)
//     {
//         System.Console.WriteLine($"Current Temperature: {temp}");
//         if (temp > 100)
//         {
//             TemperatureExceed?.Invoke(temp);
//         }
//     }
// }
// public class Program1
// {

//     public static void Main()
//     {
//         TemperatureMonitor tm = new TemperatureMonitor();
//         tm.TemperatureExceed += ShowAlert;
//         tm.TemperatureExceed += SendEmail;
//         tm.CheckTemperature(90);
//         tm.CheckTemperature(120);
//     }
//     public static void ShowAlert(int a)
//     {
//         System.Console.WriteLine("Temperature is high: " + a);
//     }
//     public static void SendEmail(int a)
//     {
//         System.Console.WriteLine("Email of high temo: " + a);

//     }
// }using System;

// public class BalanceEventArgs : EventArgs
// {
//     public decimal CurrentBalance { get; set; }
// }

// public class BankAccount
// {
//     private decimal balance;

//     public event EventHandler<BalanceEventArgs>? LowBalance;

//     public BankAccount(decimal initialBalance)
//     {
//         balance = initialBalance;
//     }

//     public void Withdraw(decimal amount)
//     {
//         if (amount > 0 && amount <= balance)
//         {
//             balance -= amount;

//             Console.WriteLine($"Remaining Balance: {balance}");

//             if (balance < 1000)
//             {
//                 var args = new BalanceEventArgs
//                 {
//                     CurrentBalance = balance
//                 };

//                 LowBalance?.Invoke(this, args);
//             }
//         }
//     }
// }

// public class Program1
// {
//     public static void Main()
//     {
//         BankAccount account = new BankAccount(5000);

//         account.LowBalance += ShowWarning;
//         account.LowBalance += SendSMS;

//         account.Withdraw(4500);
//     }

//     public static void ShowWarning(object? sender, BalanceEventArgs e)
//     {
//         Console.WriteLine("Warning: Low balance! Current balance: " + e.CurrentBalance);
//     }

//     public static void SendSMS(object? sender, BalanceEventArgs e)
//     {
//         Console.WriteLine("SMS Sent: Balance below limit: " + e.CurrentBalance);
//     }
// }
// public delegate int Aloo(int input);
// public class Program1
// {
//     public   event Aloo EventUsage;
//     public static void Main()
//     {
//         Program1 obj=new Program1();
//         obj.EventUsage+=Add;
//         System.Console.WriteLine(obj.EventUsage.Invoke(4));
//     }
//     public static int Add(int a)
//     {
//         return a+a;
//     }
// }