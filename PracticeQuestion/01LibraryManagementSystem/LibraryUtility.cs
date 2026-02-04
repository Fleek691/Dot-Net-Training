
namespace LMS
{
    public class LibraryUtility
    {
        public SortedDictionary<int, Book> bookCOllection = new SortedDictionary<int, Book>();
        public void AddBook(string title, string author, string genre, int year)
        {
            int id = bookCOllection.Count;
            bookCOllection.Add(id + 1, new Book(title,author,genre,year));
        }
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            var result = bookCOllection.Values.GroupBy(e => e.Genre).OrderBy(e => e.Key).ToDictionary(e => e.Key, e => e.ToList());
            return new SortedDictionary<string, List<Book>>(result);
        }
        public List<Book> GetBookByAuthor(string author)
        {
            var result=bookCOllection.Values.Where(e=>e.Author==author).ToList();
            return result;
        }
        public int GetTotalBooksCount()
        {
            return bookCOllection.Count;
        }
    }
}