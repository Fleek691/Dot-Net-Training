using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_bookService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _bookService.GetById(id);
        if (book is null)
            return NotFound("Book not found");
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create(CreateBookDTO dto)
    {
        var book = _bookService.Create(dto);
        return Created($"/books/{book.Id}", book);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _bookService.Delete(id);
        if (!result)
            return NotFound("Book not found");
        return NoContent();
    }
}