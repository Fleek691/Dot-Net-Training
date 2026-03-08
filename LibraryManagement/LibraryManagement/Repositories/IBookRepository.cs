using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetById(int id);
        void Add(Book book);
        void DelById(int id);
    }
}
