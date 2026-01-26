using System.Runtime.Serialization.Formatters;

public class Ques1
{
    public static void Main(string[] args)
    {
        IFilmLibrary filmLibrary=new FilmLibrary();
        filmLibrary.AddFilm(new Film{Title="DDlj",Director="Avoshek",Year=2002});
        filmLibrary.AddFilm(new Film{Title="Dhurandar",Director="Aditya",Year=2001});
        filmLibrary.AddFilm(new Film{Title="Tenet",Director="Nolan",Year=2003});
        var s=filmLibrary.SearchFilms("nolan");
        foreach(var item in s)
        {
            System.Console.WriteLine(item.Title+item.Director+item.Year);
        }
        System.Console.WriteLine();
        var f=filmLibrary.GetFilms();
        foreach(var item in f)
        {
            System.Console.WriteLine(item.Title+item.Director+item.Year);
        }
        System.Console.WriteLine();
        filmLibrary.RemoveFilm("nolan");
        System.Console.WriteLine(filmLibrary.GetTotalFilmCount());
        
    }
}
public class Film : IFilm
{
    public string Title{get;set;}
    public string Director{get;set;}
    public int Year{get;set;}

}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films=new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }
    public void RemoveFilm(string Director)
    {
        
            IFilm removeFilm=null;
            foreach(var item in _films)
            {
                if(item.Director.ToLower().Contains(Director.ToLower())){
                    removeFilm=item;
                    break;
                }
                
            }
        if (removeFilm != null)
        {
            _films.Remove(removeFilm);
        }
            
        
    }
    public List<IFilm> GetFilms()
    {
        return _films;
    }
        
        
    public  List<IFilm> SearchFilms(string query)
    {
        List<IFilm> FilmList=new List<IFilm>();
        foreach(var item in _films)
        {
            if(item.Director.ToLower().Contains(query.ToLower())  || item.Title.ToLower().Contains(query.ToLower()))
            {
                FilmList.Add(item);
            }
        }
        return FilmList;
    }
    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

public interface IFilmLibrary
{
    public void AddFilm(IFilm film);
    public void RemoveFilm(string film);
    public List<IFilm> GetFilms();
    public List<IFilm> SearchFilms(string query);
    public int GetTotalFilmCount();
}

public interface IFilm
{
    string Title{get;set;}
    string Director{get;set;}
    int Year{get;set;}
}