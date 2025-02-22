using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission6Assignment.Models;

// HINT, adding a ? at the end of the variable type 
// for example, int? means that the variable is NOT required
// for the user to enter in.

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public required int? CategoryId { get; set; }
    public required Category? Category { get; set; }  // Setting up FK relationship to table
    
    [Required(ErrorMessage = "Must enter Movie Name to Add Movie.")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Movie Release Year is required.")]
    [Range(1888, int.MaxValue, ErrorMessage = "Movie Release Year must be between 1888 and today's date")]
    public required int Year { get; set; } // Default value is current year
    public required string? Director { get; set; }
    public required string? Rating { get; set; }

    [Required(ErrorMessage = "Must note whether the movie has been edited or not.")]
    public required bool Edited { get; set; }
    
    [Required(ErrorMessage = "Must note whether the movie has been copied to plex or not")]
    public required bool CopiedToPlex { get; set; } // required column for new database
    public string? LentTo { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
    public string? Notes { get; set; }
}