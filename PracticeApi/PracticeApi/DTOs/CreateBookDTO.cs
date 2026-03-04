using System.ComponentModel.DataAnnotations;

public class CreateBookDTO
{
    [Required]
    [MinLength(2,ErrorMessage = "Title must be at least 2 characters long.")]
    [MaxLength(100,ErrorMessage = "Title must be at most 100 characters long.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(2,ErrorMessage = "Author name must be at least 2 characters long.")]
    [MaxLength(50,ErrorMessage = "Author name must be at most 50 characters long.")]
    public string Author { get; set; } = string.Empty;
    [Range(1, 5,ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
}