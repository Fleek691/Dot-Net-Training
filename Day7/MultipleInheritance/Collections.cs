using System.Collections;

public class ExampleOfCollections
{
    public void Generics1()
    {
    List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

    Stack<string> stack = new Stack<string>();
        stack.Push("First");
        stack.Push("Second");
        stack.Push("Third");
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    Queue<double> queue = new Queue<double>();
        queue.Enqueue(1.1);
        queue.Enqueue(2.2);
        queue.Enqueue(3.3);
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }    
    }
}