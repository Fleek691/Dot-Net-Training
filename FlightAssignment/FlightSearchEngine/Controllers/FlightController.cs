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
        var model = new SearchViewModel();

        try
        {
            model.SourceList = new SelectList(await _db.GetSourcesAsync());
            model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
        }
        catch (Exception ex)
        {
            model.SourceList = new SelectList(Array.Empty<string>());
            model.DestinationList = new SelectList(Array.Empty<string>());
            ViewBag.ErrorMessage = ex.Message;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlights(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await ReloadDropdownsAsync(model);
            return View("Index", model);
        }

        try
        {
            var results = await _db.SearchFlightsAsync(
                model.Source!,
                model.Destination!,
                model.NumberOfPersons);

            return View("Results", results);
        }
        catch (Exception ex)
        {
            await ReloadDropdownsAsync(model);
            ViewBag.ErrorMessage = ex.Message;
            return View("Index", model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await ReloadDropdownsAsync(model);
            return View("Index", model);
        }

        try
        {
            var results = await _db.SearchFlightsWithHotelsAsync(
                model.Source!,
                model.Destination!,
                model.NumberOfPersons);

            return View("HotelResults", results);
        }
        catch (Exception ex)
        {
            await ReloadDropdownsAsync(model);
            ViewBag.ErrorMessage = ex.Message;
            return View("Index", model);
        }
    }

    private async Task ReloadDropdownsAsync(SearchViewModel model)
    {
        try
        {
            model.SourceList = new SelectList(await _db.GetSourcesAsync());
            model.DestinationList = new SelectList(await _db.GetDestinationsAsync());
        }
        catch
        {
            model.SourceList = new SelectList(Array.Empty<string>());
            model.DestinationList = new SelectList(Array.Empty<string>());
        }
    }
}