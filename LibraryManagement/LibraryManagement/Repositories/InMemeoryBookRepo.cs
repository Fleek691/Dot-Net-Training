using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class InMemeoryBookRepo : IBookRepository
    {
        private List<Book> _books;
        public InMemeoryBookRepo()
        {
            _books = new List<Book>()
            {
                new Book { Id = 1, Title = "Harry Potter", Author = "Avishek", Price = 10.99m },
                new Book { Id = 2, Title = "The Lord of the Rings", Author = "Asad", Price = 15.99m },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "Varsith", Price = 12.99m }
            };
        }   
        public void Add(Book book)
        {
            if (_books.Any(b=>b.Id==book.Id))
            {
                Console.WriteLine("Book already present");
                return;
            }
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void DelById(int id)
        {
            var book= _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
    }
}
