
using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8; // MB

        // TODO:
        // 1. Validate file extension
        // 2. Validate file size
        // 3. Throw and handle appropriate exceptions

        try
        {
            ValidateFile(fileName, fileSize);
            System.Console.WriteLine("File uploaded successfully!");
        }
        catch (InvalidFileExtensionException ex)
        {
            System.Console.WriteLine($"Upload failed: {ex.Message}");
        }
        catch (FileSizeLimitExceededException ex)
        {
            System.Console.WriteLine($"Upload failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ValidateFile(string fileName, int fileSize)
    {
        // Validate file extension
        string extension = System.IO.Path.GetExtension(fileName).ToLower();
        string[] allowedExtensions = { ".pdf", ".jpg", ".png", ".docx", ".txt" };

        bool isValidExtension = false;
        foreach (string ext in allowedExtensions)
        {
            if (extension == ext)
            {
                isValidExtension = true;
                break;
            }
        }

        if (!isValidExtension)
        {
            throw new InvalidFileExtensionException($"Invalid file extension '{extension}'. Allowed: .pdf, .jpg, .png, .docx, .txt");
        }

        // Validate file size (max 5 MB)
        const int maxSizeInMB = 5;
        if (fileSize > maxSizeInMB)
        {
            throw new FileSizeLimitExceededException($"File size {fileSize}MB exceeds the maximum limit of {maxSizeInMB}MB.");
        }
    }
}

public class InvalidFileExtensionException : Exception
{
    public InvalidFileExtensionException(string message) : base(message)
    {
    }
}

public class FileSizeLimitExceededException : Exception
{
    public FileSizeLimitExceededException(string message) : base(message)
    {
    }
}