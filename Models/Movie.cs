using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models;

public class Movie
{
    public int Id{get; set;}
    [Required]
    [StringLength(100)]
    public String Title {get; set;}

    [Required]
    public String Director {get; set;}

    public DateOnly ReleaseDate {get; set;}

    public List<Review> Reviews {get; set; }

}