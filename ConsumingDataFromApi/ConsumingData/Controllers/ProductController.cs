using ConsumingData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ConsumingData.Controllers;

public class ProductController : Controller
{
    private static readonly HttpClient _client = new HttpClient();
    private readonly string _baseUrl = "https://dummyjson.com/products";

    // GET: Fetch all posts
    public async Task<IActionResult> Index()
    {
        List<Product> posts = new List<Product>();

        HttpResponseMessage response = await _client.GetAsync(_baseUrl);

        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();

            // Deserialize to wrapper class, then access Products property
            var result = JsonSerializer.Deserialize<ProductRespone>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            posts = result?.Products ?? new List<Product>();
        }

        return View(posts);
    }

    // GET: Show create form
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create a new post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product newPost)
    {
        if (!ModelState.IsValid)
        {
            return View(newPost);
        }

        // 1. Convert C# object to JSON string
        string jsonPayload = JsonSerializer.Serialize(newPost);

        // 2. Wrap string in StringContent (sets Encoding and Media Type)
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // 3. Send POST request
        HttpResponseMessage response = await _client.PostAsync(_baseUrl, content);

        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Post created successfully (Fake API)!";
            return RedirectToAction("Index");
        }

        TempData["Error"] = "Failed to create post.";
        return View(newPost);
    }
}
