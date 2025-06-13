using System;
using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_megaplay.Repository;

public class FavoritesRepository : IFavoritesRepository
{
    // Instancia del contexto
    private readonly ApplicationDbContext _db;

    public FavoritesRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool AddToFavorites(int userId, int movieId)
    {

        if (userId <= 0 || movieId <= 0)
            return false;

        // Validar que el usuario y la película existan
        var userExists = _db.Users.Any(u => u.UserId == userId);
        var movieExists = _db.Movies.Any(m => m.Id == movieId);
        if (!userExists || !movieExists)
            return false;

        // Verificar que no esté ya en favoritos
        var alreadyFavorite = _db.Favorites.Any(f => f.UsersId == userId && f.MoviesId == movieId);
        if (alreadyFavorite)
            return false;

        var favorite = new Favorites { UsersId = userId, MoviesId = movieId };
        _db.Favorites.Add(favorite);
        return Save();
    }

    public async Task<IEnumerable<FavoritesDto>> GetFavoriteMoviesByUser(int userId)
    {
        return await _db.Favorites
            .Where(f => f.UsersId == userId)
            .Include(f => f.Movie)
                .ThenInclude(m => m.Genre)
            .Include(f => f.Movie)
                .ThenInclude(m => m.Section)
            .Select(f => new FavoritesDto
            {
                MovieId = f.Movie.Id,
                Title = f.Movie.Title,
                Description = f.Movie.Description,
                Duration = f.Movie.Duration,
                Score = f.Movie.Score,
                GenreName = f.Movie.Genre!.GenreName,
                SectionName = f.Movie.Section!.SectionName
            })
            .ToListAsync();
    }

    public bool RemoveFromFavorites(int userId, int movieId)
    {
        var favorite = _db.Favorites.FirstOrDefault(f => f.UsersId == userId && f.MoviesId == movieId);
        if (favorite != null)
        {
            _db.Favorites.Remove(favorite);
            return Save();
        }
        return false;
    }

    public bool UserExists(int userId)
    {
        return _db.Users.Any(u => u.UserId == userId);
    }

    public bool MovieExists(int movieId)
    {
        return _db.Movies.Any(m => m.Id == movieId);
    }

    public bool IsFavorite(int userId, int movieId)
    {
        return _db.Favorites.Any(f => f.UsersId == userId && f.MoviesId == movieId);
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }
}
