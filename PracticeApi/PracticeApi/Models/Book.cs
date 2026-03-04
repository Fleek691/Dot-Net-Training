
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string InternalNotes { get; set; } = string.Empty;
    public decimal CostPrice { get; set; }
}