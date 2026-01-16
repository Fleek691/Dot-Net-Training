public class Movie
{
    public string? Title{get;set;}
    public string? Artist{get;set;}
    public string? Genre{get;set;} 
    public int Rating{get;set;}
}
public class Ques2
{
    public static List<Movie> MovieList=new List<Movie>();
    public static void Main(string[] args)
    {
        Addmovie("Kalki,Prabhas,Fiction,4");
        Addmovie("DDlJ,Sarukh Khan,Romance ,5");
        Addmovie("Bhag Milkha Bhag,Milkha sing,Fiction,1");
        System.Console.WriteLine("Enter movie details (Title,Artist,Genre,Rating): ");
        string? details=Console.ReadLine();
        Addmovie(details);
        System.Console.WriteLine("====Enter Genre====");
        string? genre=Console.ReadLine();
        var suggestions=ViewMoviesByGenre(genre);
        if(suggestions.Count!=0){
            foreach(var s in suggestions){
            System.Console.WriteLine($"Movie  Details: {s.Title} , {s.Artist} , {s.Genre} , {s.Rating}");
        }
        }
        else{
            System.Console.WriteLine("No movies found in this genre");
        }
        
        ViewMovieByRating();
        System.Console.WriteLine("====Movies by rating====");
        foreach(var s in MovieList){
            System.Console.WriteLine($"Movie  Details: {s.Title} , {s.Artist} , {s.Genre} , {s.Rating}");
        }
    }
    public static void Addmovie(string MovieDetails){
        string [] parts=MovieDetails.Split(',');

        Movie movie=new Movie{
            Title=parts[0],
            Artist=parts[1],
            Genre=parts[2],
            Rating = int.Parse(parts[3])
        };
        MovieList.Add(movie);  
    }
    public static List<Movie> ViewMoviesByGenre(string genre)
    {
        List<Movie> movies=new List<Movie>();
        foreach(var m in MovieList){
            if(genre.ToLower()==m.Genre.ToLower()){
                movies.Add(m);
            }
        }
         return movies;
    }
    public static List<Movie> ViewMovieByRating()
    {
        MovieList.Sort((a,b)=>a.Rating.CompareTo(b.Rating));
         return MovieList;
    }
}
    


