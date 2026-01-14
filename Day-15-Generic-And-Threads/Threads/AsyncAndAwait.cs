public class AsAnAw
{
    public async Task SimpleDelayAsync()
    {
        Console.WriteLine("Task starting...");
        await Task.Delay(3000);
        Console.WriteLine("Task completed after 3 seconds.");
    }

    public async Task<string> FetchData(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            return response;
        }
    }

}
