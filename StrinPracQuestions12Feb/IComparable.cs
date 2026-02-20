// using System;                                                     // Console, DateTime
// using System.Collections.Generic;                                    // List, Comparer
// using System.Globalization;                                         // parsing
// using System.Linq;                                                  // LINQ

// namespace ItTechGenie.M1.IComparable.WarmUp
// {
//     // Ticket model that can be sorted (default) using IComparable<Ticket>
//     public class SupportTicket : IComparable<SupportTicket>          // IComparable<T> enables Sort()
//     {
//         public string TicketId { get; }                              // unique id (may contain spaces/unicode)
//         public int Priority { get; }                                 // lower number => higher priority
//         public DateTime CreatedAt { get; }                            // created time
//         public string Title { get; }                                  // message/title

//         public SupportTicket(string ticketId, int priority, DateTime createdAt, string title) // constructor
//         {
//             TicketId = ticketId;                                     // assign id
//             Priority = priority;                                     // assign priority
//             CreatedAt = createdAt;                                   // assign time
//             Title = title;                                           // assign title
//         }

//         // ✅ Warm-up TODO: Student can compare with the reference answer (below)
//         public int CompareTo(SupportTicket? other)                    // contract: -1/0/+1
//         {
//             // TODO:
//             // 1) null other => current is "greater" or "after" (return 1)
//             if (other == null)
//             {
//                 return 1;
//             }
//             int priorityChecker=this.Priority.CompareTo(other.Priority);
//             if (priorityChecker != 0)
//             {
//                 return priorityChecker;
//             }
//             int Secondary=this.CreatedAt.CompareTo(other.CreatedAt);
//             if (Secondary != 0)
//             {
//                 return Secondary;
//             }
            

//             // 2) Primary: Priority ascending (1 before 2)
//             // 3) Secondary: CreatedAt ascending (earlier first)
//             // 4) Tertiary: TicketId ordinal (string compare)
//             return string.Compare(this.TicketId,other.TicketId,StringComparison.Ordinal);
//         }

//         public override string ToString()                             // print
//             => $"{Priority} | {CreatedAt:HH:mm:ss} | {TicketId} | {Title}";
//     }

//     internal class Program
//     {
//         static void Main()
//         {
//             // sample tickets (hard-coded for warm-up)
//             var tickets = new List<SupportTicket>                     // list of comparable tickets
//             {
//                 new SupportTicket("TKT- 001 ✅", 2, DateTime.Parse("2026-02-18 10:05:02"), "Login fail!@#"),
//                 new SupportTicket("TKT-α12", 1, DateTime.Parse("2026-02-18 10:04:59"), "Payment ₹ 1,999.25"),
//                 new SupportTicket("TKT-β77", 2, DateTime.Parse("2026-02-18 10:05:02"), "Timeout α/β"),
//                 new SupportTicket("TKT- 001 ✅", 2, DateTime.Parse("2026-02-18 10:05:02"), "Duplicate id")
//             };

//             // 1) Default sort uses IComparable<T> (CompareTo)
//             tickets.Sort();                                           // relies on CompareTo

//             Console.WriteLine("Default Sort (Priority, CreatedAt, TicketId):");
//             tickets.ForEach(t => Console.WriteLine(t));               // print sorted list

//             // 2) Descending sort example using Comparer (not IComparable)
//             var desc = tickets.OrderByDescending(t => t.Priority)      // higher priority number first
//                               .ThenBy(t => t.CreatedAt)               // then by time
//                               .ToList();

//             Console.WriteLine("\nCustom Sort (Priority DESC, CreatedAt ASC):");
//             desc.ForEach(t => Console.WriteLine(t));
//         }
//     }
// }
using System;                                                     // Console
using System.Collections.Generic;                                    // List

namespace ItTechGenie.M1.IComparable.Q2
{
    public class Product : IComparable<Product>                      // comparable for Sort()
    {
        public string Sku { get; }                                   // key (may contain spaces)
        public string Name { get; }                                  // display name
        public decimal Price { get; }                                // price

        public Product(string sku, string name, decimal price)        // constructor
        {
            Sku = sku;                                               // assign
            Name = name;                                             // assign
            Price = price;                                           // assign
        }

        // ✅ TODO: Student must implement only this method
        public int CompareTo(Product? other)
        {
            // TODO:
            // - handle null
            if (other == null)
            {
                return 1;
            }
            int a=string.Compare(this.Sku.Trim(),other.Sku.Trim(),StringComparison.Ordinal);
            if (a != 0)
            {
                return a;
            }
            int priceComparer=this.Price.CompareTo(other.Price);
            if (priceComparer != 0)
            {
                return priceComparer;
            }

            // - compare Sku.Trim() using StringComparison.Ordinal
            // - then Price
            // - then Name (ignore case)
            return string.Compare(this.Name,other.Name,StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"{Sku} | {Name} | ₹{Price}";
    }

    internal class Program
    {
        static void Main()
        {
            var list = new List<Product>
            {
                new Product(" SKU-β77  ", "Headphones ✅", 7999m),
                new Product("SKU-α12", "Laptop Stand", 1299.50m),
                new Product("SKU-α12", "Laptop stand", 1299.50m),
                new Product("SKU-!@#", "Cable 2m", 499m),
            };

            list.Sort();                                             // uses CompareTo
            list.ForEach(p => Console.WriteLine(p));
        }
    }
}

