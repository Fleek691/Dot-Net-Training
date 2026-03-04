public interface IBookService
{
    List<BookDto> GetAll();
    BookDto? GetById(int id);
    BookDto Create(CreateBookDTO dto);
    bool Delete(int id);
}