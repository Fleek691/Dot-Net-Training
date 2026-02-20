
using System;                                           // Console
using System.Collections.Generic;                          // List
using System.Globalization;
using System.Linq;                                        // LINQ

namespace ItTechGenie.M1.Linq.Q1
{
    public static class ProductCleaner
    {
        // ✅ TODO: Student must implement only this method
        public static List<string> GetUniqueNames(List<string> rawNames)
        {
            if (rawNames == null || rawNames.Count == 0)
                return new List<string>();

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            var result = new List<string>();

            for (int i = 0; i < rawNames.Count; i++)
            {
                string name = rawNames[i];

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                name = name.Trim();
                name = textInfo.ToTitleCase(name.ToLower());

                if (!result.Any(r => r.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    result.Add(name);
            }

            return result;
        }
    }

    internal class Program
    {
        static void Main()
        {
            var raw = new List<string> { "  laptop stand  ", " LAPTOP   STAND ", "  headphones; noise-cancel  ", "  ", "  cable-α12 ✅  " };
            var names = ProductCleaner.GetUniqueNames(raw);

            Console.WriteLine("Clean Names:");
            names.ForEach(Console.WriteLine);
        }
    }
}