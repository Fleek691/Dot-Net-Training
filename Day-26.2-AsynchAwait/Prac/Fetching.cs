using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program4
{
    public static async Task Main()
    {
        using var http = new HttpClient();

        await FetchJsonAsync(http);
        await FetchGoogleAsync(http);
    }

    private static async Task FetchJsonAsync(HttpClient http)
    {
        try
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            string json = await http.GetStringAsync(url);
            Console.WriteLine("JSON response:");
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("JSON fetch error: " + ex.Message);
        }
    }

    private static async Task FetchGoogleAsync(HttpClient http)
    {
        try
        {
            string url = "https://www.google.com";
            string html = await http.GetStringAsync(url);
            Console.WriteLine("Google response (first 500 chars):");
            Console.WriteLine(html.Length > 500 ? html.Substring(0, 500) : html);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Google fetch error: " + ex.Message);
        }
    }
}
