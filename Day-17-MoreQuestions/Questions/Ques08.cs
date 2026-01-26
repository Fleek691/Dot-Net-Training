// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// namespace Solution
// {
//     public abstract class Employee
//     {
//         protected string department;
//         protected string name;
//         protected string location;
//         protected bool isOnVacation = false;
//         public Employee(string department, string name, string location)
//         {
//             this.department = department;
//             this.name = name;
//             this.location = location;
//         }
//         public abstract string GetDepartment();
//         public abstract string GetName();
//         public abstract string GetLocation();
//         public abstract bool GetStatus();
//         public abstract void SwitchStatus();
//     }
//     class FinanceEmployee : Employee
//     {
//         public FinanceEmployee(string name,string location): base("finance", name, location)
//         {
//         }
//         public override string GetDepartment()
//         {
//             return this.department;
//         }

//         public override string GetLocation()
//         {
//             return this.location;
//         }

//         public override string GetName()
//         {
//             return this.name;
//         }

//         public override bool GetStatus()
//         {
//             return isOnVacation;
//         }

//         public override void SwitchStatus()
//         {
//             isOnVacation=true;
//         }
//     }
//     class MarketingEmployee : Employee
//     {
//         public MarketingEmployee(string name,string location): base("Marketing", name, location)
//         {
            
//         }
//         public override string GetDepartment()
//         {
//             return this.department;
//         }

//         public override string GetLocation()
//         {
//             return this.location;
//         }

//         public override string GetName()
//         {
//             return this.name;
//         }

//         public override bool GetStatus()
//         {
//             return isOnVacation;
//         }

//         public override void SwitchStatus()
//         {
//             isOnVacation=!isOnVacation;
//         }
//     }
//     class Solution
//     {
//         static void Main()
//         {
//             Type baseType = typeof(Employee);
//             if (!baseType.IsAbstract)
//                 throw new Exception($"{baseType.Name} type should be abstract");
//             string[] strArr = str.Split(' ');
//             Employee financeEmployee = new FinanceEmployee(strArr[0], strArr[1]);
//             var department = financeEmployee.GetDepartment();
//             var name = financeEmployee.GetName();
//             var location = financeEmployee.GetLocation();
//             var status = financeEmployee.GetStatus() ? "on" : "not on";
//             Console.WriteLine($"FinanceEmployee info: Department -{department}, Name - {name}, Location - {location}");
//             Console.WriteLine($"{name} is {status} vacation");
//             Console.WriteLine("Switching");
//             financeEmployee.SwitchStatus();
//             status = financeEmployee.GetStatus() ? "on" : "not on";
//             Console.WriteLine($"{name} is {status} vacation");
//             Console.WriteLine("Switching");
//             financeEmployee.SwitchStatus();
//             status = financeEmployee.GetStatus() ? "on" : "not on";
//             Console.WriteLine($"{name} is {status} vacation");
//             str = Console.ReadLine();
//             strArr = str.Split(' ');
//             Employee marketingEmployee = new MarketingEmployee(strArr[0], strArr[1]);
//             department = marketingEmployee.GetDepartment();
//             name = marketingEmployee.GetName();
//             location = marketingEmployee.GetLocation();
//             status = marketingEmployee.GetStatus() ? "on" : "not on"
//             ;
//             Console.WriteLine($"MarketingEmployee info: Department- {department}, Name - {name}, Location - {location}");
//             Console.WriteLine($"{name} is {status} vacation");
//             Console.WriteLine("Switching");
//             marketingEmployee.SwitchStatus();
//             status = marketingEmployee.GetStatus() ? "on" : "not on";
//             Console.WriteLine($"{name} is {status} vacation");
//             Console.WriteLine("Switching");
//             marketingEmployee.SwitchStatus();
//             status = marketingEmployee.GetStatus() ? "on" : "not on"
//             ;
//             Console.WriteLine($"{name} is {status} vacation");
//         }
//     }
// }