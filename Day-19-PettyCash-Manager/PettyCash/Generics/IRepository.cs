public interface IRepository<T>{
    void Add(T item);
    T? GetById(int id);
    List<T> GetAll();
    void Update(T item);
    void Remove(int id);
}