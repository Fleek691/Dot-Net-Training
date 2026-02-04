// using System;
// using System.IO;

// class FileReader
// {
//     static void Main()
//     {
//         string filePath = @"C:\Users\avish\Desktop\\Op for sql.txt";
//         try
//         {
//             string context=File.ReadAllText(filePath);
//             Console.WriteLine("File Content: ");
//             Console.WriteLine(context);
//         }
//         catch (FileNotFoundException ex)
//         {
//             System.Console.WriteLine(ex.Message);
//         }
//         catch (UnauthorizedAccessException ex)
//         {
//             System.Console.WriteLine(ex.Message);
//         }
//         finally
//         {
//             Console.WriteLine("File read operation completed.");
//         }

//         // TODO:
//         // 1. Read file content
//         // 2. Handle FileNotFoundException
//         // 3. Handle UnauthorizedAccessException
//         // 4. Ensure resource is closed properly
//     }
// }
using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = @"C:\Users\avish\Desktop\Op for sql.txt";

        try
        {
            // StreamReader opens the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read entire file content
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            } // File is automatically CLOSED here
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied to the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("File read operation completed.");
        }
    }
}
        