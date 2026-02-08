public interface IFilm
{
    public string? Title { get; set; }
}
public interface IFilmLibrary
{
    public void AddFilm(IFilm film);
    public void RemoveFilm(string name);
    public List<IFilm> GetFilms();
    public List<IFilm> SearchFilms(string query);
    public int GetTotalFIlmCOunt();
}
public class Film : IFilm
{
    public string? Title { get; set; }
    public string? Director { get; set; }
    public int Year { get; set; }
}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        if (_films.Contains(film))
        {
            return;
        }
        _films.Add(film);
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public int GetTotalFIlmCOunt()
    {
        return _films.Count;
    }

    public void RemoveFilm(string title)
    {
        var film = _films.FirstOrDefault(f => f.Title == title);
        if (film != null)
        {
            _films.Remove(film);
        }
    }


    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> res = new List<IFilm>();
        if (_films.Count > 0)
        {
            foreach (var movie in _films)
            {
                Film? film=movie as Film;
                if (movie.Title!.Contains(query) || (film!=null && film.Director!.Contains(query)))
                {
                    res.Add(movie);
                }
            }
        }
        return res;
    }
}