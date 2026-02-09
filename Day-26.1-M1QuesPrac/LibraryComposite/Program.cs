public class Author
{
    public string AuthorName{get;set;}
    public string COuntry{get;set;}
}
public class Book
{
    public string Title{get;set;}
    public int Price{get;set;}
    public Author author{get;set;}
    public Book(string title,int price)
    {
        Title=title;
        Price=price;
        author=new Author();
    }
}
public class Helper
{
    public static void Main()
    {
        Book book=new Book("GOT",2000);
        book.author.AuthorName="Avishek";
        book.author.COuntry="India";
        System.Console.WriteLine($"The book {book.Title} written by {book.author.AuthorName} from {book.author.COuntry} is of Rs. {book.Price}");
        Book book2 = new Book("LOL",1000);
        book2.author.AuthorName="AP";
        book2.author.COuntry="Japan";
        System.Console.WriteLine($"{book2.author.AuthorName} from {book2.author.COuntry} wrote {book2.Title} whihc costs {book2.Price}");

    }
}