public class Ques3
{
    public static void Main()
    {
        List<(string name, int score)> players = new List<(string name, int score)>();
        System.Console.WriteLine("Enter no of Players ");
        int noOfPlayers = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("enter details (player name, score)");
        for (int i = 0; i < noOfPlayers; i++)
        {
            string input = Console.ReadLine()!;
            string[] parts = input.Split(",");
            players.Add((parts[0], int.Parse(parts[1])));
        }

        System.Console.WriteLine("enter no of top players: ");
        int top = int.Parse(Console.ReadLine()!);

        List<(string name, int score)> topK=players.OrderByDescending(e=>e.score).Take(top).ToList();
        foreach(var item in topK)
        {
            System.Console.WriteLine(item);
        }
    }
}