namespace ExceptionA
{
    using System;

    /// <summary>
    /// Utility class for validating employee and entry details
    /// </summary>
    public static class EntryUtility
    {
        /// <summary>
        /// Validates the employee ID format
        /// The ID must be exactly 10 characters, start with "GOAIR/", and end with 4 digits
        /// </summary>
        /// <param name="id">The employee ID to validate</param>
        /// <returns>True if the ID is valid</returns>
        /// <exception cref="InvalidEntryException">Thrown when the ID format is invalid</exception>
        public static bool validateEmployeeId(string id)
        {
            // Check if the ID length is exactly 10 characters
            if (id.Length != 10)
            {
                throw new InvalidEntryException("Invalid entry details");
            }

            // Check if the ID starts with the required prefix "GOAIR/"
            if (!id.StartsWith("GOAIR/"))
            {
                throw new InvalidEntryException("Invalid entry details");
            }

            // Extract the last 4 characters and verify they are numeric
            string lastFour = id.Substring(id.Length - 4);
            if (!int.TryParse(lastFour, out _))
            {
                throw new InvalidEntryException("Invalid entry details");
            }

            return true;
        }

        /// <summary>
        /// Validates the duration value
        /// Duration must be between 1 and 5 (inclusive)
        /// </summary>
        /// <param name="a">The duration value to validate</param>
        /// <returns>True if the duration is valid</returns>
        /// <exception cref="InvalidEntryException">Thrown when the duration is out of valid range</exception>
        public static bool validateDuration(int a)
        {
            // Check if duration is within the valid range of 1 to 5
            if (a < 1 || a > 5)
            {
                throw new InvalidEntryException("Invalid entry details");
            }
            return true;
        }
    }

    /// <summary>
    /// User interface class that handles entry data collection and validation
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Main entry point of the application
        /// Prompts user for entry details and validates them using exception handling
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        public static void Main(string[] args)
        {
            // Prompt user for the number of entries to process
            Console.WriteLine("Enter the number of entries");
            int a = int.Parse(Console.ReadLine()!);

            // Loop through each entry
            for (int i = 1; i <= a; i++)
            {
                Console.WriteLine($"Enter entry {i} details");
                // Read the complete entry input from user
                string input = Console.ReadLine()!;

                // Split the input by colon delimiter to extract individual fields
                string[] words = input.Split(':');

                // Try to validate the entry details
                try
                {
                    // Validate the employee ID (first field)
                    EntryUtility.validateEmployeeId(words[0]);

                    // Parse and validate the duration (third field)
                    int dur = int.Parse(words[2]);
                    EntryUtility.validateDuration(dur);

                    // If all validations pass, display success message
                    Console.WriteLine("Valid entry details");
                }
                catch (InvalidEntryException)
                {
                    // If any validation fails, catch the exception and display error message
                    Console.WriteLine("Invalid entry details");
                }
            }
        }
    }

    /// <summary>
    /// Custom exception class for invalid entry data
    /// Inherits from the base Exception class
    /// </summary>
    public class InvalidEntryException : Exception
    {
        /// <summary>
        /// Constructor that accepts a custom error message
        /// </summary>
        /// <param name="message">The error message to be displayed when exception is thrown</param>
        public InvalidEntryException(string message) : base(message)
        {
        }
    }

}