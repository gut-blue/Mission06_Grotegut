using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6Assignment.Models;

namespace Mission6Assignment.Controllers;

public class HomeController : Controller
{
    private readonly MovieDetailsContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(MovieDetailsContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovieForm()
    {
        var model = new Movie
        {
            CategoryName = string.Empty,
            MovieTitle = string.Empty, // Default empty string
            MovieYear = null, // Default to current year
            DirectorFirstName = string.Empty,
            DirectorLastName = string.Empty,
            MovieRating = "--Select a Rating--" // Default value for rating
        };
        
        return View(model);
    }

    [HttpPost]
    public IActionResult AddMovieForm(Movie response)
    {
        _context.Movies.Add(response);  // Adding "Movie" record to the database
        _context.SaveChanges(); // Commit changes to the database
        
        if (!ModelState.IsValid)
        {
            return View(response);
        }
        
        return View("Confirmation", response);
    }
}