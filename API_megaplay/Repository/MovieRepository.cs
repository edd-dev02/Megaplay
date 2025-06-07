using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_megaplay.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _db;

    public MovieRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool MovieExists(int id)
    {
        return _db.Movies.Any(m => m.Id == id);
    }

    public bool MovieExists(string title)
    {
        return _db.Movies.Any(m => m.Title.ToLower().Trim() == title.ToLower().Trim());
    }

    public bool CreateMovie(Movie movie)
    {
        movie.CreationDate = DateTime.Now;
        _db.Movies.Add(movie);
        return Save();
    }

    public bool DeleteMovie(Movie movie)
    {
        _db.Movies.Remove(movie);
        return Save();
    }

    public Movie? GetMovie(int id)
    {
        return _db.Movies
            .Include(m => m.Genre)
            .Include(m => m.Section) 
            .FirstOrDefault(m => m.Id == id);
    }

    public ICollection<Movie> GetMovies()
    {
        return _db.Movies
        .Include(m => m.Genre)
        .Include(m => m.Section)
        .OrderBy(m => m.Title)
        .ToList();
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    public bool UpdateMovie(Movie movie)
    {
        movie.CreationDate = DateTime.Now;
        _db.Movies.Update(movie);
        return Save();
    }
}

