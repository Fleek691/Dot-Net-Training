using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
public interface IBankAccountOperation
{
/*
Sample operations expected to be proceeded
Values may be different
-I want to see my balance
-I want to see money in my account
-I want to withdraw 200
-I want to pull 100
-I want to deposit 500
-I want to invest 600
-I want to transfer 100 to my account
-I want to deposit 500 dollars
-Pull 100 dollars
-Deposit 200
*/
void Deposit(decimal d);
void Withdraw(decimal d);
//returns the current balance after process.
decimal ProcessOperation(string message);
}
//Create BankOperations class by implementing IBankAccountOperation interface

class BankOperations : IBankAccountOperation

{
    decimal balance=0;
    public void Deposit(decimal d)
    {
        if (d > 0)
        {
            balance+=d;
        }
    }
    private decimal ExtractAmount(string msg)
    {
        string[] parts=msg.Split(" ");
        foreach(var item in parts)
        {
            if(decimal.TryParse(item,out decimal Value))
            {
                return Value;
            }
        }
        return 0;
    }

    public decimal ProcessOperation(string message)
    {
        string msg=message.ToLower();
        decimal amount=ExtractAmount(msg);
        if (msg.Contains("pull") || msg.Contains("withdraw"))
        {
            Withdraw(amount);
            
        }
        else if (msg.Contains("deposit") || msg.Contains("put")||msg.Contains("invest") || msg.Contains("transfer"))
        {
            Deposit(amount);   
        }
        else if (msg.Contains("see") || msg.Contains("show"))
        {
        }
        return balance;
        
    }

    public void Withdraw(decimal d)
    {
        if(d>0 && d<=balance)
        {
            balance-=d;
        }
    }
}


class Ques6
{
public static void Main(string[] args)
{
TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH")!, true);
string? k = Console.ReadLine();
int n = Convert.ToInt32(k);
List<string> inputs = new List<string>();
for (int i = 0; i < n; i++)
{
inputs.Add(Console.ReadLine()!);
}
BankOperations opt = new BankOperations();
foreach (var item in inputs)
{
textWriter.WriteLine(opt.ProcessOperation(item));
}
textWriter.Flush();
textWriter.Close();
}
}