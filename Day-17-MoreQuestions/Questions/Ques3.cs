public interface IBook
{
    int Id{get;set;}
    string? Title{get;set;}
    string? Author{get;set;}
    string? Category{get;set;}
    int Price{get;set;}
}
public interface ILibrarySystem
{
    private Dictionary<IBook,int> _books;
    void AddBook(IBook book,int quantity){}
    void RemoveBook(IBook book,int quantity){}
    int CalculateTotal(){return 0;}
    List<(string,int)> CategoryTotalPrice();
    List<(string,int)> BooksInfo();
    List<(string,int)> CategoryAndAuthorWithCount();
    
}
public class Book : IBook
{
    public int Id { get ; set ; }
    public string? Title { get ; set ; }
    public string? Author { get ; set ; }
    public string? Category { get ; set ; }
    public int Price { get ; set ; }
}
public class LibrarySystem : ILibrarySystem
{
    public Dictionary<IBook, int> _books { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    Dictionary<IBook, int> ILibrarySystem._books { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    List<(string, int)> ILibrarySystem.BooksInfo()
    {
        throw new NotImplementedException();
    }

    List<(string, int)> ILibrarySystem.CategoryAndAuthorWithCount()
    {
        throw new NotImplementedException();
    }

    List<(string, int)> ILibrarySystem.CategoryTotalPrice()
    {
        throw new NotImplementedException();
    }
}