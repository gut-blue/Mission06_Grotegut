using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    // Simple Index and GetToKnowJoel controllers
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    // Get and Post controllers for my AddMovieForm view
    [HttpGet]
    public IActionResult AddMovieForm()
    {
        ViewBag.Categories = _context.Categories.ToList();
        
        var model = new Movie
        {
            CategoryId = 1,
            Title = string.Empty, // Default empty string
            Year = DateTime.Now.Year, // Default to current year
            Director = string.Empty,
            Rating = "--Select a Rating--",
            Category = null,
            Edited = false,
            CopiedToPlex = false // Default value for rating
        };
        
        // Passing new model, not working
        return View(model);
    }

    [HttpPost]
    public IActionResult AddMovieForm(Movie response)
    {
        if (response.Year > DateTime.Now.Year)
        {
            ModelState.AddModelError("Year", "Movie release year cannot be in the future.");
        }
        
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);  // Adding "Movie" record to the database
            _context.SaveChanges(); // Commit changes to the database
        
            return View("Confirmation", response);
        }
        else // If Invalid Data
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }
    }

    // First ever Linq query, bringing in the data from my database and linking it to any edits made on the view.
    public IActionResult Movielist()
    {
        var movies = _context.Movies
            .Include(m => m.Category)   // Loads Categories table
            .ToList();
        // Return the view with the movies data
        return View("Movielist", movies);  // Pass the movies data to the view
    }

    
    // Edit Action Method/Controller
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(m => m.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("AddMovieForm", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Update(updatedMovie);
        _context.SaveChanges();
        
        return RedirectToAction("Movielist");
    }
    
    // Delete action for deleting a movie record from the table
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(m => m.MovieId == id);
        
        return View(recordToDelete);
    }
    
    // Post for the same action
    [HttpPost]
    public IActionResult Delete(Movie deletedMovie)
    {
        _context.Movies.Remove(deletedMovie);
        _context.SaveChanges();
        
        return RedirectToAction("Movielist");
    }
}