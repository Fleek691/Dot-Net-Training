public class BookService : IBookService
{
    private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", Rating = 5, InternalNotes = "Best seller", CostPrice = 29.99m },
        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Rating = 4, InternalNotes = "Good stock", CostPrice = 24.99m },
        new Book { Id = 3, Title = "C# in Depth", Author = "Jon Skeet", Rating = 5, InternalNotes = "Low stock", CostPrice = 34.99m }
    };

    public List<BookDto> GetAll()
    {
        return books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Rating = b.Rating
        }).ToList();
    }

    public BookDto? GetById(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book is null) return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Rating = book.Rating
        };
    }

    public BookDto Create(CreateBookDTO dto)
    {
        var book = new Book
        {
            Id = books.Max(b => b.Id) + 1,
            Title = dto.Title,
            Author = dto.Author,
            Rating = dto.Rating,
            InternalNotes = "",
            CostPrice = 0
        };
        books.Add(book);

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Rating = book.Rating
        };
    }

    public bool Delete(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book is null) return false;
        books.Remove(book);
        return true;
    }
}