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
    void AddBook(IBook book,int quantity){}
    void RemoveBook(IBook book,int quantity){}
    int CalculateTotal(){return 0;}
    List<(string,int)> CategoryTotalPrice();
    List<(string,int,int)> BooksInfo();
    List<(string,string,int)> CategoryAndAuthorWithCount();
    
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
    public Dictionary<IBook, int> _books =new Dictionary<IBook, int>();
    public void AddBook(IBook book,int quantity)
    {
    if (_books.ContainsKey(book))
        _books[book] += quantity;
    else
        _books.Add(book,quantity);
    }

    public void RemoveBook(IBook book,int quantity)
    {
        if (_books.ContainsKey(book))
        {
            int current=_books[book];
            if (quantity < _books[book])
            {
                _books[book]=current-quantity;
            }
            else
            {
                _books.Remove(book);
            }
        }
        else
        {
            System.Console.WriteLine("Invalid");
        }
    }
    public int CalculateTotal()
    {
        int total=0;
        foreach(var item in _books)
        {
            total=total+(item.Key.Price*item.Value);
        }
        return total;
    }

    public List<(string, int,int)> BooksInfo()
    {
        List<(string, int,int)> bookInfo=new List<(string, int, int)>();
        foreach(var item in _books)
        {
            bookInfo.Add((item.Key.Title,item.Value,item.Key.Price)!);
        }
        return bookInfo;
    }

    public List<(string,string, int)> CategoryAndAuthorWithCount()
    {
        List<(string category,string Author,int quantity)> result=new List<(string category, string Author, int quantity)>();
        foreach(var item in _books)
        {
            string category=item.Key.Category;
            string Author=item.Key.Author;
            int qty=item.Value;
            bool found=false;
            for(int i = 0; i < result.Count; i++)
            {
                if(result[i].category==category && result[i].Author == Author)
                {
                    result[i]=(category,Author,result[i].quantity+qty);
                    found=true;
                    break;
                }
            }
            if (!found)
            {
                result.Add((category,Author,qty));
            }
        }
        return result;
       
    }

    public List<(string, int)> CategoryTotalPrice()
{
    List<(string category,int price)> result = new List<(string, int)>();

    foreach(var item in _books)
    {
        string category = item.Key.Category!;
        int totalPrice = item.Key.Price * item.Value;

        bool found = false;

        for(int i = 0; i < result.Count; i++)
        {
            if(result[i].category == category)
            {
                result[i] = (category, result[i].price + totalPrice);
                found = true;
                break;
            }
        }

        if(!found)
        {
            result.Add((category, totalPrice));
        }
    }

    return result;
}

}

public class Ques3
{
    public static void Main(string[] args)
    {
        LibrarySystem library = new LibrarySystem();

        // Create some books
        IBook b1 = new Book { Id = 1, Title = "Peter Pan", Author = "James Barrie", Category = "Kids", Price = 100 };
        IBook b2 = new Book { Id = 2, Title = "Wizard of Oz", Author = "Frank Baum", Category = "Kids", Price = 150 };
        IBook b3 = new Book { Id = 3, Title = "Sherlock Holmes", Author = "Arthur Conan Doyle", Category = "Mystery", Price = 200 };
        IBook b4 = new Book { Id = 4, Title = "Another Barrie Book", Author = "James Barrie", Category = "Kids", Price = 120 };

        // Add books
        library.AddBook(b1, 2);   // 2 * 100
        library.AddBook(b2, 1);   // 1 * 150
        library.AddBook(b3, 3);   // 3 * 200
        library.AddBook(b4, 2);   // 2 * 120

        Console.WriteLine("=== Books Info (Title, Quantity, Price) ===");
        foreach (var item in library.BooksInfo())
        {
            Console.WriteLine($"{item.Item1} , Qty: {item.Item2} , Price: {item.Item3}");
        }

        Console.WriteLine("\n=== Category Total Price ===");
        foreach (var item in library.CategoryTotalPrice())
        {
            Console.WriteLine($"{item.Item1} : {item.Item2}");
        }

        Console.WriteLine("\n=== Category & Author With Count ===");
        foreach (var item in library.CategoryAndAuthorWithCount())
        {
            Console.WriteLine($"{item.Item1} - {item.Item2} : {item.Item3}");
        }

        Console.WriteLine("\n=== Grand Total Price ===");
        Console.WriteLine(library.CalculateTotal());

        // Test remove
        library.RemoveBook(b1, 1); // remove 1 Peter Pan

        Console.WriteLine("\nAfter removing 1 Peter Pan:");
        foreach (var item in library.BooksInfo())
        {
            Console.WriteLine($"{item.Item1} , Qty: {item.Item2} , Price: {item.Item3}");
        }
    }
}