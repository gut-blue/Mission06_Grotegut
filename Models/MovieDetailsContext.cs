using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models;

public class MovieDetailsContext : DbContext
{
    public MovieDetailsContext(DbContextOptions<MovieDetailsContext> options) : base(options)
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
}