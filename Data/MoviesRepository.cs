using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data;

public class MoviesRepository
{
    private readonly MovieContext _context;

    public MoviesRepository(MovieContext context){
        _context = context;
    }

    public async Task<List<Movie>> GetMoviesAsync() => await _context.Movies.Include(m => m.Reviews).ToListAsync();

    public async Task<Movie?> GetMovieByTitleAsync(string Title) => await _context.Movies.FirstOrDefaultAsync(m => m.Title == Title);

    public async Task<Movie?> GetMovieAsync(int id) => await _context.Movies.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.Id == id);

    public async Task AddMovieAsync(Movie movie){
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task EditMovieAsync(Movie movie){
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(int id){
        Movie? movie = await GetMovieAsync(id);
        if(movie is not null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Cannot delete a movie that doesn't exist");
        }
    }

    public async Task<List<Review>> GetReviewsAsync() => await _context.Reviews.ToListAsync();

    public async Task AddReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }


}