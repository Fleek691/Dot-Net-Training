using System;
using LMS;

namespace LMSApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryUtility library = new LibraryUtility();

            library.AddBook("1984", "George Orwell", "Fiction", 1949);
            library.AddBook("Animal Farm", "George Orwell", "Fiction", 1945);
            library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            library.AddBook("The Da Vinci Code", "Dan Brown", "Mystery", 2003);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Option 1");
                Console.WriteLine("2. Option 2");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Total Books: " + library.GetTotalBooksCount());
                        Console.WriteLine();

                        Console.WriteLine("Books Grouped By Genre:");
                        var groupedBooks = library.GroupBooksByGenre();

                        foreach (var genre in groupedBooks)
                        {
                            Console.WriteLine($"Genre: {genre.Key}");
                            foreach (var book in genre.Value)
                            {
                                Console.WriteLine($"  - {book.Title} by {book.Author} ({book.PublicationYear})");
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Books by George Orwell:");
                        var orwellBooks = library.GetBookByAuthor("George Orwell");

                        foreach (var book in orwellBooks)
                        {
                            Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("You selected Option 2.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
