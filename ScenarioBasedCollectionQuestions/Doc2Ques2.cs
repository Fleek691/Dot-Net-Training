public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

// Generic catalog class
public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private HashSet<string> _isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();

    // Add item with genre indexing
    public bool AddItem(T item)
    {
        if (_isbnSet.Add(item.ISBN)) return false;
        _items.Add(item);
        if (!_genreIndex.ContainsKey(item.Genre))
        {
            _genreIndex[item.Genre] = new List<T>() { item };
        }
        _genreIndex[item.Genre].Add(item);
        return true;

        // TODO: Check ISBN uniqueness, add to list and genre index
    }

    // Get books by genre using indexer
    public List<T> this[string genre]
    {
        get
        {
            if (!_genreIndex.ContainsKey(genre))
            {
                return new List<T>();
            }
            var a = _genreIndex.Where(e => e.Key == genre).SelectMany(e => e.Value);
            return new List<T>(a);
        }
    }

    // Find books using LINQ and lambda expressions
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        // TODO: Use LINQ Where with predicate
        // var a =_items.Where(e=>predicate(e)).ToList();
        // return a;
        return _items.Where(predicate);
    }
}
