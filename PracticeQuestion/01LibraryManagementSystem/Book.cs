
namespace LMS
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public Book(string title,string author,string genre,int year){
            this.Title=title;
            Author=author;
            Genre=genre;
            PublicationYear=year;
        }
    }
}
