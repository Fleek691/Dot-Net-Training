using System;

namespace ExceptionA
{
    // Main user interface for gadget validation
    public class UserInterface2
    {
        // Main entry point
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter id,type and period seperated by (:)");

            try
            {
                // Read and parse input
                string input = Console.ReadLine()!;
                string[] parts = input.Split(':');

                // Check input format
                if (parts.Length != 3)
                {
                    throw new InvalidGadgetException("Invalid gadget ID");
                }

                // Validate Gadget ID
                GadgetValidatorUtilClass.ValidateGadgetID(parts[0]);

                // Validate Warranty Period
                int period;
                if (!int.TryParse(parts[2], out period))
                {
                    throw new InvalidGadgetException("Invalid warranty period");
                }

                GadgetValidatorUtilClass.ValidateWarrantyPeriod(period);

                // If everything is valid
                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch (InvalidGadgetException ex)
            {
                // Display error message
                Console.WriteLine(ex.Message);
            }
        }
    }

    // Utility class for gadget validation
    public static class GadgetValidatorUtilClass
    {
        // Validate gadget ID format (1 uppercase letter + 3 digits)
        public static bool ValidateGadgetID(string gadgetID)
        {
            // Check length is exactly 4
            if (gadgetID.Length != 4)
                throw new InvalidGadgetException("Invalid gadget ID");

            // Check first character is uppercase
            if (!char.IsUpper(gadgetID[0]))
                throw new InvalidGadgetException("Invalid gadget ID");

            // Check last 3 characters are digits
            if (!int.TryParse(gadgetID.Substring(1, 3), out _))
                throw new InvalidGadgetException("Invalid gadget ID");

            return true;
        }

        // Validate warranty period (6-36 months)
        public static bool ValidateWarrantyPeriod(int period)
        {
            // Check period is between 6 and 36 months
            if (period < 6 || period > 36)
                throw new InvalidGadgetException("Invalid warranty period");

            return true;
        }
    }

    // Custom exception for invalid gadget details
    public class InvalidGadgetException : Exception
    {
        // Constructor with custom message
        public InvalidGadgetException(string message) : base(message)
        {
        }
    }
}
