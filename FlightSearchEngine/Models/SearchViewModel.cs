using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightSearchEngine.Models;

public class SearchViewModel
{
    [Required]
    public string? Source { get; set; }

    [Required]
    public string? Destination { get; set; }

    [Required]
    [Range(1, 10)]
    public int NumberOfPersons { get; set; }

    public SelectList? SourceList { get; set; }
    public SelectList? DestinationList { get; set; }
}