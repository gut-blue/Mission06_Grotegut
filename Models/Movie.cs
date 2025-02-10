using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission6Assignment.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    public required string CategoryName { get; set; }
    public required string MovieTitle { get; set; }
    public required int? MovieYear { get; set; }
    public required string DirectorFirstName { get; set; }
    public required string DirectorLastName { get; set; }

    public required string MovieRating { get; set; }

    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
    public string? Notes { get; set; }
}

// Set up a connection string for SQLite Database in my appsettings.json file
