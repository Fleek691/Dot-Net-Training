// 🧩 Question 1 — Power Game
// Problem Statement

// In a game, N people with different strengths participate one by one.

// Rules of the Game

// If the current person’s strength is greater than or equal to the previous person’s strength:
// → Both current and previous person are eliminated.

// Otherwise:
// → They become friends and their strengths are added (summed).

// A group loses only if the new participant’s strength is greater than the previously summed strength.

// Task

// After all N people have participated:

// Print "NO" if no one is left.

// Otherwise print "YES" followed by the last summed strength left.

// Input Format

// First line → Integer N (number of people)

// Second line → N space-separated integers representing strengths

// Output Format
// NO


// OR

// YES <last_strength>

// Sample Input
// 5
// 2 5 7 3 2

// Sample Output
// YES 12

using System;

public class Test
{
    public static string powerGame(int N, int[] A)
    {
        
        Stack<int>st=new Stack<int>();
        for(int i = 0; i < A.Length; i++)
        {
            int curr=A[i];
            if (st.Count == 0)
            {
                st.Push(curr);
            }
            else
            {
                int  top=st.Peek();
                if (curr >= top)
                {
                    st.Pop();
                }
                else
                {
                    st.Pop();
                    st.Push(top+curr);
                }
            }
        }
        if (st.Count == 0)
        {
            return "No";
        }
        return "Yes"+" "+st.Peek();
    }

    public static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());

        int[] A = new int[N];
        string[] tokens = Console.ReadLine()!.Split();

        for (int i = 0; i < N; i++)
        {
            A[i] = Convert.ToInt32(tokens[i]);
        }

        Console.WriteLine(powerGame(N, A));
    }
}
