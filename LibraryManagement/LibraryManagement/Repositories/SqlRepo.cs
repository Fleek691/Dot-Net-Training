using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Repositories
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public SqlBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DelById(int id)
        {
            var book = _context.Books.Find(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}