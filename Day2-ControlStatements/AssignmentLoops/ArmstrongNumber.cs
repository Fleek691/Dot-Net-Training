using System;
public class BankingSystem
{
    public static void Bank()
    {
        Console.WriteLine("Welcome to Phagwara Bank!! <3");
        int choice;
        double balance=0;
        do
        {
            Console.WriteLine("=========BANK MENU=========");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposite Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("0. Exit");
            Console.Write("Enter request: ");
            choice=Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Current Account Balance: Rs {balance}");
                    break;
                case 2:
                    System.Console.Write("Enter amount to be Deposited: ");
                    double amountDeposit=Convert.ToDouble(Console.ReadLine());
                    balance=balance+amountDeposit;
                    System.Console.WriteLine($"Rs {amountDeposit} deposited succesfully.");
                    System.Console.WriteLine($"Account Balance: Rs{balance}");
                    break;
                case 3:
                    System.Console.Write("Enter amount in to be Withrawn: Rs ");
                    double amountWithdraw=Convert.ToDouble(Console.ReadLine());
                    if (amountWithdraw > balance)
                    {
                        System.Console.WriteLine("Insufficient Balance.");
                    }
                    else
                    {
                        System.Console.WriteLine("Withdrawl Succesfull");
                        balance=balance-amountWithdraw;
                        System.Console.WriteLine($"Account Balance: Rs{balance}");
                    }
                    break;
                case 0:
                    System.Console.WriteLine("ThankYou for your service!! <3");
                    break;
                default:
                    System.Console.WriteLine("Enter Valid Request.");
                    break;
            }
        }while(choice!=0);
        System.Console.WriteLine("Please visit Again.");
    }
}