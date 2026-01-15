// public class Program
// {
//     public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();
//     public static List<Movie> MovieList=new List<Movie>();

//     public static void Main(string[] args)
//     {

//         #region Ques1
//         // itemDetails.Add("Laptop", 150);
//         // itemDetails.Add("Phone", 300);
//         // itemDetails.Add("Tablet", 100);
//         // itemDetails.Add("Monitor", 200);
//         // itemDetails.Add("Keyboard", 50);

//         // Console.WriteLine("=== Find Item By Sold Count ===");
//         // Console.Write("Enter sold count to search: ");
//         // long searchCount = 200;
//         // var foundItem = FindItemDetails(searchCount);
//         // if (foundItem.Count > 0)
//         // {
//         //     foreach (var item in foundItem)
//         //         Console.WriteLine($"Item: {item.Key}, Sold Count: {item.Value}");
//         // }
//         // else
//         //     Console.WriteLine("Invalid sold count");

//         // Console.WriteLine("\n=== Find Min and Max Sold Items ===");
//         // var minMaxItems = FindMaxandMinSoliditems();
//         // Console.WriteLine($"Minimum Sold Item: {minMaxItems[0]}");
//         // Console.WriteLine($"Maximum Sold Item: {minMaxItems[1]}");


//         // Console.WriteLine("\n=== Sort Items by Sold Count ===");
//         // var sortedItems = SortByCount();
//         // foreach (var item in sortedItems)
//         //     Console.WriteLine($"Item: {item.Key}, Sold Count: {item.Value}");
//         // }
//         // public static SortedDictionary<string,long>FindItemDetails(long soldCount)
//         // {
//         //     SortedDictionary<string, long> result = new SortedDictionary<string, long>();
//         //     foreach(var item in itemDetails)
//         //     {
//         //         if (item.Value==soldCount)
//         //         {
//         //             result.Add(item.Key, item.Value);
//         //             return result;
//         //         }
//         //     }
//         //     return result;
//         // }
//         // public static List<String> FindMaxandMinSoliditems()
//         // {
//         //     List<string> result = new List<string>();
//         //     long max = long.MinValue;
//         //     long min = long.MaxValue;
//         //     string minItemName = "";
//         //     string maxItemName = "";

//         //     foreach(var item in itemDetails)
//         //     {
//         //         if(item.Value > max)
//         //         {
//         //             max = item.Value;
//         //             maxItemName = item.Key;
//         //         }
//         //         if(item.Value < min)
//         //         {
//         //             min = item.Value;
//         //             minItemName = item.Key;
//         //         }
//         //     }

//         //     result.Add(minItemName);
//         //     result.Add(maxItemName);
//         //     return result;
//         // }
//         // public static Dictionary<string,long> SortByCount()
//         // {
//         //     Dictionary<string, long> sortedDict = itemDetails.OrderBy(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
//         //     return sortedDict;
//         // #endregion
        
//         #region  Ques2
//         Addmovie("Kalki,Prabhas,Fiction,4");
//         Addmovie("DDlJ,Sarukh Khan,Romance ,5");
//         Addmovie("Bhag Milkha Bhag,Milkha sing,Fiction,1");
//         System.Console.WriteLine("Enter movie details (Title,Artist,Genre,Rating): ");
//         string? details=Console.ReadLine();
//         Addmovie(details);
//         System.Console.WriteLine("====Enter Genre====");
//         string? genre=Console.ReadLine();
//         var suggestions=ViewMoviesByGenre(genre);
//         if(suggestions.Count!=0){
//             foreach(var s in suggestions){
//             System.Console.WriteLine($"Movie  Details: {s.Title} , {s.Artist} , {s.Genre} , {s.Rating}");
//         }
//         }
//         else{
//             System.Console.WriteLine("No movies found in this genre");
//         }
//         }
//         ViewMovieByRating();
//         System.Console.WriteLine("====Movies by rating====");
//         foreach(var s in MovieList){
//             System.Console.WriteLine($"Movie  Details: {s.Title} , {s.Artist} , {s.Genre} , {s.Rating}");
//         }
//         #endregion
//     }
//     public static void Addmovie(string MovieDetails){
//         string [] parts=MovieDetails.Split(',');

//         Movie movie=new Movie{
//             Title=parts[0],
//             Artist=parts[1],
//             Genre=parts[2],
//             Rating = int.Parse(parts[3])
//         };
//         MovieList.Add(movie);  
//     }
//     public static List<Movie> ViewMoviesByGenre(string genre){
//         List<Movie> movies=new List<Movie>();
//         foreach(var m in MovieList){
//             if(genre.ToLower()==m.Genre.ToLower()){
//                 movies.Add(m);
//             }
//         }
//          return movies;
//     }
//     public static List<Movie> ViewMovieByRating(){
//         MovieList.Sort((a,b)=>a.Rating.CompareTo(b.Rating));
//          return MovieList;
//     }
    
// }
