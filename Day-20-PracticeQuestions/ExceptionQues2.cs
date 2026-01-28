using System;
using System.Text.RegularExpressions;

/// <summary>
/// Utility class for validating gadget information
/// </summary>
public class GadgetValidatorUtil
{
    /// <summary>
    /// Validates the gadget ID format
    /// Format must be: one uppercase letter followed by exactly 3 digits (e.g., A123)
    /// </summary>
    /// <param name="gadgetID">The gadget ID to validate</param>
    /// <returns>True if the ID is valid</returns>
    /// <exception cref="InvalidGadgetException">Thrown when the ID format is invalid</exception>
    public bool validateGadgetID(string gadgetID)
    {
        // Use regex pattern to validate: one uppercase letter followed by 3 digits
        if (!Regex.IsMatch(gadgetID, @"^[A-Z][0-9]{3}$"))
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }

        return true;
    }

    /// <summary>
    /// Validates the warranty period for a gadget
    /// Warranty period must be between 6 and 36 months (inclusive)
    /// </summary>
    /// <param name="period">The warranty period in months to validate</param>
    /// <returns>True if the warranty period is valid</returns>
    /// <exception cref="InvalidGadgetException">Thrown when the warranty period is outside valid range</exception>
    public bool validateWarrantyPeriod(int period)
    {
        // Check if warranty period is within valid range (6 to 36 months)
        if (period < 6 || period > 36)
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }

        // Stock update logic would be implemented here if required
        return true;
    }
}

/// <summary>
/// Custom exception class for invalid gadget data
/// </summary>
public class InvalidGadgetException : Exception
{
    /// <summary>
    /// Constructor that accepts a custom error message
    /// </summary>
    /// <param name="message">The error message to display when exception is thrown</param>
    public InvalidGadgetException(string message) : base(message)
    {
    }
}

/// <summary>
/// User interface class for gadget warranty validation system
/// Handles user input and processes multiple gadget entries
/// </summary>
public class UserInterface2
{
    /// <summary>
    /// Main entry point of the application
    /// Accepts gadget details and validates them using exception handling
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    public static void Main(string[] args)
    {
        // Prompt user for the number of gadget entries to process
        Console.WriteLine("Enter the number of gadget entries");
        int n = int.Parse(Console.ReadLine()!);

        // Create an instance of the validator utility
        GadgetValidatorUtil util = new GadgetValidatorUtil();

        // Process each gadget entry
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter gadget {i} details");
            // Read the complete gadget entry from user
            string input = Console.ReadLine()!;

            // Split input by colon delimiter to extract individual fields
            // Expected format: gadgetID:name:warrantyPeriod:price
            string[] parts = input.Split(':');

            // Try to validate the gadget information
            try
            {
                // Extract gadget ID (first field) and warranty period (third field)
                string gadgetId = parts[0];
                int warranty = int.Parse(parts[2]);

                // Validate both the gadget ID format and warranty period
                util.validateGadgetID(gadgetId);
                util.validateWarrantyPeriod(warranty);

                // If all validations pass, display success message
                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch (InvalidGadgetException ex)
            {
                // If validation fails, catch the exception and display the error message
                Console.WriteLine(ex.Message);
            }
        }
    }
}
