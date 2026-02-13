using System.Collections.Generic;
using System.Text;
using System.Linq;
public class StringQuestions
{
    public static void Main()
    {
        #region Universal Input
        Console.Write("Enter a string: ");
        string input = Console.ReadLine()!;
        #endregion

        #region Ques 1 ReverseString
        // string reversed=string.Empty;
        // for(int i = 0; i < input.Length; i++)
        // {
        //     reversed+=input[input.Length-1-i];
        // }
        // Console.WriteLine(reversed);
        #endregion

        #region Ques2 Largest Element
        // Console.Write("Enter the number of elements: ");
        // int n = int.Parse(Console.ReadLine()!);
        // Console.WriteLine("Enter the elements: ");
        // int[] elements = new int[n];
        // for (int i = 0; i < n; i++)
        // {
        //     elements[i]=int.Parse(Console.ReadLine()!);
        // }
        // int max=int.MinValue;
        // for(int i = 0; i < n; i++)
        // {
        //     if (elements[i] >= max)
        //     {
        //         max=elements[i];
        //     }
        // }
        // Console.WriteLine("Maximum element: "+max);
        #endregion

        #region Ques3 HashSet
        // List<int> list=new ();
        // Console.WriteLine("Enter the number of elements: ");
        // int n=int.Parse(Console.ReadLine()!);
        // Console.WriteLine("Enter the elements: ");
        // for(int i = 0; i < n; i++)
        // {
        //     int el=int.Parse(Console.ReadLine()!);
        //     list.Add(el);
        // }
        // HashSet<int> hash=new HashSet<int>(list);
        // Console.Write("New values: ");
        // foreach(var item in hash)
        // {
        //     Console.Write(item+" ");
        // }
        #endregion

        #region Frequency
        // Console.WriteLine("Enter the number of elements: ");
        // int n=int.Parse(Console.ReadLine()!);
        // Console.WriteLine("Enter the elements: ");
        // List<int> elem=new ();
        // for(int i = 0; i < n; i++)
        // {
        //     int el=int.Parse(Console.ReadLine()!);
        //     elem.Add(el);
        // }
        // Dictionary<int,int> freq=new ();
        // foreach(var item in elem)
        // {
        //     if(freq.ContainsKey(item))freq[item]++;
        //     else freq[item]=1;
        // }
        // foreach(var item in freq)
        // {
        //     Console.WriteLine("{0} ,{1}",item.Key,item.Value);
        // }
        #endregion

        #region Palindrome
        // char[] storing=input.ToCharArray();
        // int i=0;
        // int j=input.Length-1;
        // while (i <= j)
        // {
        //     char temp=storing[i];
        //     storing[i]=storing[j];
        //     storing[j]=temp;
        //     i++;
        //     j--;
        // }
        // string inputNew=new string(storing);
        // Console.WriteLine("Palindrome Check: "+(input==inputNew));
        #endregion

        #region SumOfElements
        // Console.WriteLine("Enter the num of elements: ");
        // int n = int.Parse(Console.ReadLine()!);
        // Console.WriteLine("Enter the elements: ");
        // int[] elements = new int[n];
        // for (int i = 0; i < n; i++)
        // {
        //     elements[i] = int.Parse(Console.ReadLine()!);
        // }
        // int sum = elements.Sum(e=>e);
        // // foreach (var item in elements)
        // // {
        // //     sum += item;
        // // }
        // Console.WriteLine("Sum of elemets: " + sum);
        #endregion

        #region MergeTwoSortedArray
        Console.WriteLine("Enter the num of elements for first Array: ");
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the elements: ");
        int[] elements = new int[n];
        for (int l = 0; l < n; l++)
        {
            elements[l] = int.Parse(Console.ReadLine()!);
        }
        Console.WriteLine("Enter the num of elements for second Array: ");
        int n1 = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the elements: ");
        int[] elements1 = new int[n1];
        for (int l = 0; l < n1; l++)
        {
            elements1[l] = int.Parse(Console.ReadLine()!);
        }
        elements.Sort();
        elements1.Sort();
        int[] merged = new int[n1 + n];
        int i = 0;
        int j = 0;
        int k = 0;
        while (i < elements.Length && j < elements1.Length)
        {
            if (elements[i] < elements1[j])
            {
                merged[k++] = elements[i++];
            }
            else
            {
                merged[k++] = elements[j++];
            }
        }
        while (i < elements.Length)
        {
            merged[k++] = elements[i++];
        }
        while (j < elements1.Length)
        {
            merged[k++] = elements1[j++];
        }
        Console.WriteLine("Merged Values: ");
        foreach (var item in merged)
        {
            Console.Write(item);
        }
        #endregion


    }
}
