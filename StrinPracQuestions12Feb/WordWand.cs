namespace String
{

    /// <summary>
    /// Question 1: Word Wand - Manipulates words in a sentence based on word count
    /// If even number of words: reverse the order of words
    /// If odd number of words: reverse each individual word
    /// </summary>
    public class Ques1
    {
        /// <summary>
        /// Main entry point of the program
        /// Prompts user to enter a sentence and processes it
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        public static void Main(string[] args)
        {
            // Display prompt for user input
            System.Console.WriteLine("Enter the sentence: ");
            // Read the entire sentence from user input
            string input = Console.ReadLine()!;

            // Validate that the input contains only alphabetic characters
            if (IsAlpha(input))
            {
                // Process the input using the WordWand method
                string res = WordWand(input);
                System.Console.WriteLine(res);
            }
            else
            {
                // Display error if input contains non-alphabetic characters
                System.Console.WriteLine("Invalid Sentence");
            }
        }

        /// <summary>
        /// Processes the input sentence based on the number of words
        /// Even word count: Reverses the order of words in the sentence
        /// Odd word count: Reverses each individual word in the sentence
        /// </summary>
        /// <param name="input">The input sentence to process</param>
        /// <returns>The processed sentence with spaces between words</returns>
        public static string WordWand(string input)
        {
            string result = "";
            // Split the input sentence into individual words using space delimiter
            string[] parts = input.Split(" ");

            // Check if the number of words is even
            if (parts.Length % 2 == 0)
            {
                // Initialize pointers for two-pointer swap technique
                int i = 0;
                int j = parts.Length - 1;

                // Swap words from both ends moving towards the center
                while (i < j)
                {
                    var temp = parts[i];
                    parts[i] = parts[j];
                    parts[j] = temp;
                    i++;
                    j--;
                }

                // Reconstruct the result string with reversed word order
                for (int k = 0; k < parts.Length; k++)
                {
                    result += parts[k] + " ";
                }
            }
            else
            {
                // Odd number of words: reverse each individual word
                for (int i = 0; i < parts.Length; i++)
                {
                    // Reverse the characters in each word
                    string temp = new string(parts[i].Reverse().ToArray());
                    result += temp + " ";
                }
            }

            return result;
        }

        /// <summary>
        /// Validates that the input sentence contains only alphabetic characters and spaces
        /// </summary>
        /// <param name="input">The sentence to validate</param>
        /// <returns>True if all characters are letters (spaces are allowed), false otherwise</returns>
        public static bool IsAlpha(string input)
        {
            // Split the input into individual words by space delimiter
            string[] parts = input.Split(" ");

            // Iterate through each word in the sentence
            for (int i = 0; i < parts.Length; i++)
            {
                // Check each character in the current word
                foreach (char c in parts[i])
                {
                    // Return false if any non-letter character is found
                    if (!Char.IsLetter(c))
                    {
                        return false;
                    }
                }
            }

            // All characters are letters, so the sentence is valid
            return true;
        }
    }

}