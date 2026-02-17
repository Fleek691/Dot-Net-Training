// public enum OrderSide
// {
//     Buy,
//     Sell
// }

// public interface IOrder<T> where T : IComparable<T>
// {
//     string OrderId { get; }
//     T Instrument { get; }
//     OrderSide Side { get; }
//     decimal Price { get; }
//     int Quantity { get; }
//     DateTime Timestamp { get; }
//     int Priority { get; } // 1-10, 1 is highest
// }

// // Thread-safe Order Book with Price-Time Priority
// public class OrderBook<T> where T : IComparable<T>
// {
//     // Concurrent collections for thread safety
//     private ConcurrentDictionary<string, IOrder<T>> _allOrders = new ConcurrentDictionary<string, IOrder<T>>();
//     private ConcurrentPriorityQueue<IOrder<T>> _buyOrders = new ConcurrentPriorityQueue<IOrder<T>>(
//         Comparer<IOrder<T>>.Create((a, b) => 
//         {
//             // Priority first, then price (higher better for buys), then time
//             int priorityCompare = a.Priority.CompareTo(b.Priority);
//             if (priorityCompare != 0) return -priorityCompare;
            
//             int priceCompare = b.Price.CompareTo(a.Price); // Higher price first
//             if (priceCompare != 0) return priceCompare;
            
//             return a.Timestamp.CompareTo(b.Timestamp); // Earlier first
//         }));
    
//     private ConcurrentPriorityQueue<IOrder<T>> _sellOrders = new ConcurrentPriorityQueue<IOrder<T>>(
//         Comparer<IOrder<T>>.Create((a, b) => 
//         {
//             int priorityCompare = a.Priority.CompareTo(b.Priority);
//             if (priorityCompare != 0) return -priorityCompare;
            
//             int priceCompare = a.Price.CompareTo(b.Price); // Lower price first
//             if (priceCompare != 0) return priceCompare;
            
//             return a.Timestamp.CompareTo(b.Timestamp);
//         }));
    
//     // Market data stream processor
//     private BufferBlock<MarketData<T>> _marketDataStream = new BufferBlock<MarketData<T>>();
    
//     // Real-time analytics
//     private CircularBuffer<decimal> _priceHistory = new CircularBuffer<decimal>(1000);
//     private ConcurrentDictionary<TimeSpan, decimal> _volumeByTime = new ConcurrentDictionary<TimeSpan, decimal>();
    
//     public async Task ProcessOrderAsync(IOrder<T> order)
//     {
//         // TODO: Implement atomic order processing with matching engine
//         // 1. Add to appropriate priority queue
//         // 2. Attempt to match with opposite side
//         // 3. Update market data stream
//         // 4. Calculate analytics in real-time
//         // 5. Handle partial fills
//     }
    
//     public IEnumerable<OrderMatch<T>> GetOrderMatches(int count)
//     {
//         // TODO: Use PLINQ for parallel processing of match history
//         // Include complex join operations between buys and sells
//     }
    
//     public decimal CalculateVWAP(TimeSpan period)
//     {
//         // TODO: Calculate Volume Weighted Average Price using LINQ aggregation
//         // with windowing over time-based partitions
//     }
// }
