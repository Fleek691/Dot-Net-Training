using System.Text;

namespace Day40Practise
{

    public class Program
    {
        public static void ECommerceCartConsolidation()
        {
            List<(string sku, int qty)> scans = new()
            {
                ("A101", 2),
                ("B205", 1),
                ("A101", 3),
                ("C111", -1)
            };

            Dictionary<string, int> skuQty = new();

            for (int i = 0; i < scans.Count; i++)
            {
                if (scans[i].qty <= 0)
                    continue;
                skuQty.TryAdd(scans[i].sku, 0);
                skuQty[scans[i].sku] += scans[i].qty;
            }

            foreach (var item in skuQty)
            {
                System.Console.WriteLine($"{item.Key} -- {item.Value}");
            }
        }

        public static void AttendanceFirstUniqueEntry()
        {
            List<int> scans = new()
            {
                10, 20, 10, 30, 20, 40
            };

            HashSet<int> seen = new();
            List<int> firstTime = new();
            foreach (int item in scans)
            {
                if (seen.Add(item))
                    firstTime.Add(item);
            }
            foreach (int item in firstTime)
            {
                System.Console.Write($"{item} ");
            }
        }

        public static void LeaderboardTopKScores()
        {
            List<(string name, int score)> players = new()
            {
                ("Raj",80),("Anu",95),("Vikram",95),("Meena",70)
            };
            int k = 3;
            List<(string name, int score)> topK = players.OrderByDescending(s => s.score).ThenBy(s => s.name).Take(k).ToList();
            foreach (var item in topK)
            {
                System.Console.WriteLine($"{item.name} -- {item.score}");
            }
        }
        public static void MetroTicketingPeakHourCount()
        {
            Queue<(TimeSpan entryTime, string ticketType)> q = new();
            q.Enqueue((new TimeSpan(7, 30, 0), "Regular"));
            q.Enqueue((new TimeSpan(8, 15, 0), "Regular"));
            q.Enqueue((new TimeSpan(9, 0, 0), "VIP"));
            q.Enqueue((new TimeSpan(9, 45, 0), "Regular"));
            q.Enqueue((new TimeSpan(10, 0, 0), "Regular"));
            q.Enqueue((new TimeSpan(10, 30, 0), "Regular"));

            int count = 0;
            TimeSpan start = new(8, 0, 0);
            TimeSpan end = new(10, 0, 0);
            while (q.Count > 0)
            {
                var passenger = q.Dequeue();
                if (passenger.ticketType == "Regular" && (start <= passenger.entryTime && end >= passenger.entryTime)) count++;
            }
            System.Console.WriteLine($"Tickets Purchased in Peak Hours Is/Are: {count}");
        }

        public static void UndoFeatureTextEditor()
        {
            List<string> ops = new()
            {
                "TYPE Hello","TYPE World","UNDO","TYPE CSharp"
            };
            Stack<string> cleanser = new();
            foreach (var item in ops)
            {
                string[] split = item.Split(" ");
                if (split[0] == "UNDO")
                {
                    if (cleanser.Count > 0) cleanser.Pop();
                }
                else if (split[0] == "TYPE")
                {
                    cleanser.Push(split[1]);
                }
            }
            Stack<string> reverser = new();
            while (cleanser.Count > 0)
            {
                reverser.Push(cleanser.Pop());
                reverser.Push(" ");
            }
            if (reverser.Count > 0) reverser.Pop();
            while (reverser.Count > 0)
            {
                System.Console.Write(reverser.Pop());
            }
        }
        public static void CustomerSupportMergeTwoTicketStreams()
        {
            List<int> a = new()
            {
                1,4,7
            };
            List<int> b = new()
            {
              2,3,8
            };

            List<int> merged = new();
            int i = 0;
            int j = 0;
            while (i < a.Count && j < b.Count)
            {
                if (a[i] <= b[j])
                {
                    merged.Add(a[i]);
                    i++;
                }
                else
                {
                    merged.Add(b[j]);
                    j++;
                }
            }
            while (i < a.Count)
            {
                merged.Add(a[i]);
                i++;
            }
            while (j < b.Count)
            {
                merged.Add(b[j]);
                j++;
            }
            foreach (int item in merged)
            {
                System.Console.Write($"{item} ");
            }
        }

        public static void BankStatementSpendbyCategory()
        {
            List<(string category, decimal amount)> txns = new()
            {
                ("Food",-200),("Fuel",-500),("Food",-50),("Salary",1000)
            };
            Dictionary<string, decimal> spendByCategory = new();
            foreach (var item in txns)
            {
                if (item.amount >= 0)
                    continue;
                spendByCategory.TryAdd(item.category, 0);
                spendByCategory[item.category] += item.amount;
            }
            foreach (var item in spendByCategory)
            {
                System.Console.WriteLine($"{item.Key} -- {-1 * item.Value}");
            }
        }
        public static void InventoryDetectDuplicateSerials()
        {
            List<string> serials = new()
            {
              "S1","S2","S1","S3","S2","S2"
            };
            HashSet<string> seen = new();
            HashSet<string> duplicates = new();
            foreach (string item in serials)
            {
                if (!seen.Add(item)) duplicates.Add(item);
            }

            foreach (string item in duplicates)
            {
                System.Console.Write($"{item} ");
            }
        }

        public static void MovieBookingSeatAllocation()
        {
            int n = 5;
            List<int> alreadyBooked = new() { 2, 4 };
            int requestCount = 5;

            SortedSet<int> available = new();

            for (int seat = 1; seat <= n; seat++)
            {
                available.Add(seat);
            }

            foreach (int booked in alreadyBooked)
            {
                available.Remove(booked);
            }

            List<int> allocatedSeats = new();

            for (int i = 0; i < requestCount; i++)
            {
                if (available.Count > 0)
                {
                    int seat = available.Min;
                    allocatedSeats.Add(seat);
                    available.Remove(seat);
                }
                else
                {
                    allocatedSeats.Add(-1);
                }
            }

            foreach (int seat in allocatedSeats)
            {
                Console.Write(seat + " ");
            }
        }
        public static void LogAnalyzerMostFrequentErrorCode()
        {
            List<string> codes = new()
            {
                "E02","E01","E02","E01","E03"
            };
            string result = codes.GroupBy(x => x).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).First()
        .Key;

            Console.WriteLine(result);
        }

        public static void Main()
        {
            //Question 1    
            // Program.ECommerceCartConsolidation();
            //Question 2
            // Program.AttendanceFirstUniqueEntry();
            //Question3
            // Program.LeaderboardTopKScores();
            //Question4
            // Program.MetroTicketingPeakHourCount();
            //Question5
            // Program.UndoFeatureTextEditor();
            //Question6
            // Program.CustomerSupportMergeTwoTicketStreams();
            // Question7
            // Program.BankStatementSpendbyCategory();
            //Question8
            // Program.InventoryDetectDuplicateSerials();
            //Question9
            // Program.MovieBookingSeatAllocation();
            //Question10
            Program.LogAnalyzerMostFrequentErrorCode();
        }
    }
}