public class Program
{
    public static async Task Main(string[] args)
    {
        #region Thread Basic Example
    //     Thread one=new Thread(Task1);
    //     Thread two=new Thread(Task2);
    //     one.Start();
    //     one.Join();//completes task 1 then starts task 2
    //     two.Start();
    //     two.Join();
        
        
    // }
    // public static void Task1()
    // {
    //     for (int i = 0; i < 11; i++)
    //     {
    //         System.Console.WriteLine(i+"*");
    //         Thread.Sleep(100);
    //     }
    // }

    // public static void Task2()
    // {
    //     for (int i = 1; i < 11; i++)
    //     {
    //         System.Console.WriteLine(i);
    //         Thread.Sleep(100);
    //     }
    #endregion
        
        #region Async and Await
        AsAnAw a=new AsAnAw();
        Task result=a.FetchData("https://jsonplaceholder.typicode.com/todos/1");
        Task task2=a.SimpleDelayAsync();
        await Task.WhenAll(result,task2);
        System.Console.WriteLine(result);
        

        

        #endregion

    }
}