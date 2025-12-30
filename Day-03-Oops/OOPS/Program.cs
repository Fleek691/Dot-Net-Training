using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using Fields;

namespace Fields
{

    public class Program
    {
        public static void Main(string[] args)
        {
            #region Visitor COnstructor
        //     Visi a = new Visi();
        // try
        // {
        //     Visi b=new Visi(2,"Ravi","Change My name");
        //     System.Console.WriteLine(b.LogHisory);

        // }
        // catch(Exception ex)
        // {
        //     System.Console.WriteLine(ex.Message);
        // }
            #endregion

            #region Addition in Constructor
            // System.Console.Write("Enter First Number: ");
            // string? s=Console.ReadLine();
            // int a=int.TryParse(s);
            // System.Console.Write("Enter First Number: ");
            // int b=Convert.ToInt16(Console.ReadLine());
            // Addition c=new Addition(a,b);
            // System.Console.WriteLine(c.Sum);
            #endregion

            #region Field Property

            // System.Console.WriteLine("I am in");
            // Fields.Field employee=new Fields.Field();
            // employee.Id=100;
            // string result=employee.DisplayEmpDetails();
            // System.Console.WriteLine(employee.Id);

            #endregion

            #region Validation and Exception
            // System.Console.WriteLine("Enter id: ");
            // int a=Convert.ToInt32(Console.ReadLine());
            // System.Console.WriteLine("Enter name: ");
            // string b=Console.ReadLine();
            // System.Console.WriteLine("Enter salary: ");
            // int c=Convert.ToInt32(Console.ReadLine());

            // Employee v=new Employee(a,b,c);
            // System.Console.WriteLine(v);

            #endregion

            #region Inheritance
            // Account ac=new Account(){id=1,Name="Avishek"};
            // System.Console.WriteLine(ac.GetAccountDetails());
            // SalesAccount sa=new SalesAccount(){id=2,Name="Avis"};
            // System.Console.WriteLine(sa.GetSalesAccountDetails());
            // PurchaseAccount pa=new PurchaseAccount(){id=3,Name="Avi"};
            // System.Console.WriteLine(pa.GetPurchaseAccountDetails());
            #endregion

            #region Virtual/Overriding
            // Father fa=new Father();
            // System.Console.WriteLine(fa.InterestOf());
            // Son so=new Son();
            // System.Console.WriteLine(so.InterestOf());
            #endregion
        }
    }
}
    // }

