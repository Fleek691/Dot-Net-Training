using System;

/// <summary>
/// Class for calculating profit or loss percentage.
/// </summary>
public class ProfitLoss
{
    /// <summary>
    /// Calculates the profit or loss percentage based on cost price and selling price.
    /// </summary>
    /// <param name="costPrice">The cost price of the item.</param>
    /// <param name="sellingPrice">The selling price of the item.</param>
    /// <returns>The profit percentage if positive, loss percentage if negative.</returns>
    public static double CalculateProfitLossPercentage(double costPrice, double sellingPrice)
    {
        if (costPrice == 0) return 0; // Avoid division by zero
        double profitLoss = ((sellingPrice - costPrice) / costPrice) * 100;
        return profitLoss;
    }
}