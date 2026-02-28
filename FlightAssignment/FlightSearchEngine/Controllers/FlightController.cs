using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightSearchEngine.Data;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Controllers;

public class FlightController : Controller
{
    private readonly DatabaseHelper _db;

    public FlightController(DatabaseHelper db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var model = new SearchViewModel
        {
            SourceList = new SelectList(await _db.GetSourcesAsync()),
            DestinationList = new SelectList(await _db.GetDestinationsAsync())
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlights(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.SourceList = new SelectList(await _db.GetSourcesAsync());
            model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
            return View("Index", model);
        }

        var results = await _db.SearchFlightsAsync(
            model.Source!,
            model.Destination!,
            model.NumberOfPersons);

        return View("Results", results);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.SourceList = new SelectList(await _db.GetSourcesAsync());
            model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
            return View("Index", model);
        }

        var results = await _db.SearchFlightsWithHotelsAsync(
            model.Source!,
            model.Destination!,
            model.NumberOfPersons);

        return View("HotelResults", results);   // 🔥 CHANGE HERE
    }
}