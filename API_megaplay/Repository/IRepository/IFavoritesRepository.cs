using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;

namespace API_megaplay.Repository.IRepository;

public interface IFavoritesRepository
{

    bool AddToFavorites(int userId, int movieId);
    bool RemoveFromFavorites(int userId, int movieId);
    Task<IEnumerable<FavoritesDto>> GetFavoriteMoviesByUser(int userId);
    bool UserExists(int userId);
    bool MovieExists(int movieId);
    bool IsFavorite(int userId, int movieId);
    bool Save();

}
