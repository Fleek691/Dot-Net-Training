public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }

// 1. Generic portfolio
public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new(); // Instrument -> Quantity

    // TODO: Buy instrument
    public void Buy(T instrument, int quantity, decimal price)
    {
        // Validate: quantity > 0, price > 0
        if (quantity <= 0 || price <= 0)
            throw new ArgumentException();

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;
        // Add to holdings or update quantity
    }

    // TODO: Sell instrument
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        // Validate: enough quantity
        if (quantity < 0 || currentPrice < 0) throw new ArgumentException();
        // Remove/update holdings
        if (!_holdings.ContainsKey(instrument)) return null;
        if (_holdings[instrument] < quantity) return null;
        _holdings[instrument] -= quantity;
        if (_holdings[instrument] == 0)
        {
            _holdings.Remove(instrument);
        }
        return quantity * currentPrice;
        // Return proceeds (quantity * currentPrice)
    }

    // TODO: Calculate total value
    public decimal CalculateTotalValue()
    {
        decimal sum = 0;
        // Sum of (quantity * currentPrice) for all holdings
        foreach (var item in _holdings)
        {
            sum = sum + (item.Key.CurrentPrice * item.Value);
        }
        return sum;

    }

    // TODO: Get top performing instrument
    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        // Calculate return percentage for each
        if (_holdings.Count == 0 || purchasePrices == null || purchasePrices.Count == 0) return null;
        T? topInstrument = default;
        decimal maxReturn = decimal.MinValue;
        foreach (var holding in _holdings)
        {
            if (!purchasePrices.ContainsKey(holding.Key)) continue;
            var purchasePrice = purchasePrices[holding.Key];
            if (purchasePrice <= 0) continue;
            decimal returnPercentage = ((holding.Key.CurrentPrice - purchasePrice) / purchasePrice) * 100;
            if (returnPercentage > maxReturn)
            {
                maxReturn = returnPercentage;
                topInstrument = holding.Key;
            }
        }
        if (topInstrument == null) return null;
        return (topInstrument, maxReturn);
        // Return highest performer
    }
    public Dictionary<T, int> GetHolding()
    {
        return new Dictionary<T, int>(_holdings);
    }
}

// 2. Specialized instruments
public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// 3. Generic trading strategy
public class TradingStrategy<T> where T : IFinancialInstrument
{
    // TODO: Execute strategy on portfolio
    public void Execute(Portfolio<T> portfolio,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        var instruments = portfolio.GetHolding();
        // For each instrument in market data
        foreach (var item in instruments)
        {
            var instrument = item.Key;
            var quantity = item.Value;
            if (sellCondition(instrument))
            {
                portfolio.Sell(instrument, quantity, instrument.CurrentPrice);
            }
            else if (buyCondition(instrument))
            {
                portfolio.Buy(instrument, 1, instrument.CurrentPrice);
            }
        }
        // Apply buy/sell conditions
        // Execute trades

    }

    // TODO: Calculate risk metrics
    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var list = instruments.ToList();

        if (list.Count == 0)
            return new Dictionary<string, decimal>();

        var prices = list.Select(i => i.CurrentPrice).ToList();

        decimal avgPrice = prices.Average();

        if (avgPrice == 0)
            return new Dictionary<string, decimal>();

        // Calculate returns relative to average price
        var returns = prices
            .Select(p => (p - avgPrice) / avgPrice)
            .ToList();

        decimal avgReturn = returns.Average();

        // Variance
        decimal variance = returns
            .Select(r => (r - avgReturn) * (r - avgReturn))
            .Average();

        // Volatility (standard deviation)
        decimal volatility = (decimal)Math.Sqrt((double)variance);

        // Sharpe Ratio (assuming risk-free rate = 0)
        decimal sharpeRatio = volatility == 0 ? 0 : avgReturn / volatility;

        // Simplified Beta (no market benchmark available)
        decimal beta = volatility == 0 ? 0 : avgReturn / volatility;

        return new Dictionary<string, decimal>
    {
        { "Volatility", volatility },
        { "Beta", beta },
        { "SharpeRatio", sharpeRatio }
    };
    }

}

// 4. Price history with generics
public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    // TODO: Add price point
    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if (price <= 0) throw new ArgumentException();
        if (!_history.ContainsKey(instrument))
        {
            _history[instrument] = new List<(DateTime, decimal)>();
        }
        _history[instrument].Add((timestamp, price));


    }

    // TODO: Get moving average
    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (days <= 0)
        {
            return null;
        }
        if (!_history.ContainsKey(instrument))
        {
            return null;
        }
        var prices = _history[instrument].OrderBy(e => e.Item1).Select(x => x.Item2).ToList();
        if (prices.Count < days) return null;
        var recentPrices = prices
        .TakeLast(days);

        return recentPrices.Average();
    }

    // TODO: Detect trends
    public Trend DetectTrend(T instrument, int period)
    {
        if (period <= 1)
            return Trend.Sideways;

        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var prices = _history[instrument]
            .OrderBy(x => x.Item1)
            .Select(x => x.Item2)
            .ToList();

        if (prices.Count < period)
            return Trend.Sideways;

        var recent = prices.TakeLast(period).ToList();

        decimal first = recent.First();
        decimal last = recent.Last();

        if (last > first)
            return Trend.Upward;

        if (last < first)
            return Trend.Downward;

        return Trend.Sideways;
    }
}

public enum Trend { Upward, Downward, Sideways }

class Program3
{
    static void Main()
    {
        // a) Create mixed instruments
        var stock = new Stock
        {
            Symbol = "AAPL",
            CurrentPrice = 150,
            CompanyName = "Apple",
            DividendYield = 0.5m
        };

        var bond = new Bond
        {
            Symbol = "GOVT10Y",
            CurrentPrice = 100,
            MaturityDate = DateTime.Now.AddYears(10),
            CouponRate = 5
        };

        // Portfolio with mixed instruments
        var portfolio = new Portfolio<IFinancialInstrument>();

        // b) Buy instruments
        portfolio.Buy(stock, 10, stock.CurrentPrice);
        portfolio.Buy(bond, 20, bond.CurrentPrice);

        Console.WriteLine("Initial Portfolio Value:");
        Console.WriteLine(portfolio.CalculateTotalValue());

        // c) Trading strategy with lambdas
        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(
            portfolio,
            buyCondition: i => i.CurrentPrice < 120,
            sellCondition: i => i.CurrentPrice > 140
        );

        Console.WriteLine("Portfolio Value After Strategy:");
        Console.WriteLine(portfolio.CalculateTotalValue());

        // d) Track price history
        var history = new PriceHistory<IFinancialInstrument>();

        history.AddPrice(stock, DateTime.Now.AddDays(-4), 130);
        history.AddPrice(stock, DateTime.Now.AddDays(-3), 135);
        history.AddPrice(stock, DateTime.Now.AddDays(-2), 140);
        history.AddPrice(stock, DateTime.Now.AddDays(-1), 145);
        history.AddPrice(stock, DateTime.Now, 150);

        // e) Demonstrations

        // Trend detection
        Console.WriteLine("Trend:");
        Console.WriteLine(history.DetectTrend(stock, 5));

        // Moving average
        Console.WriteLine("Moving Average (3 days):");
        Console.WriteLine(history.GetMovingAverage(stock, 3));

        // Risk calculation
        var risk = strategy.CalculateRiskMetrics(
            new List<IFinancialInstrument> { stock, bond });

        Console.WriteLine("Risk Metrics:");
        foreach (var item in risk)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Performance comparison
        var purchasePrices = new Dictionary<IFinancialInstrument, decimal>
        {
            { stock, 120 },
            { bond, 95 }
        };

        var top = portfolio.GetTopPerformer(purchasePrices);

        if (top != null)
        {
            Console.WriteLine("Top Performer:");
            Console.WriteLine($"{top.Value.instrument.Symbol} - {top.Value.returnPercentage}%");
        }
    }
}
