using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Models;

public class Review{
    public int Id {get; set;}
    // Foreign key for movie
    public int MovieId {get; set;}
    // Navigation property for related review
    [ValidateNever]
    public Movie Movie {get; set;}

    public string ReviewerName {get; set;}
    public String Comment {get; set;}

    public int Rating {get; set;}

}