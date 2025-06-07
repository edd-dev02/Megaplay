using System;
using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Repository.IRepository;

namespace API_megaplay.Repository;

public class GenreRepository : IGenreRepository
{
    // Instancia del contexto
    private readonly ApplicationDbContext _db;

    public GenreRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public bool GenreExists(int id)
    {
        return _db.Genres.Any(g => g.Id == id);
    }

    public bool GenreExists(string name)
    {
        return _db.Genres.Any(g => g.GenreName.ToLower().Trim() == name.ToLower().Trim());
    }

    public bool CreateGenre(Genre genre)
    {
        genre.CreationDate = DateTime.Now;
        _db.Genres.Add(genre);
        return Save();
    }

    public bool DeleteGenre(Genre genre)
    {
        _db.Genres.Remove(genre);
        return Save();
    }

    public ICollection<Genre> GetGenres()
    {
        return _db.Genres.OrderBy(g => g.GenreName).ToList();
    }

    public Genre? GetGenre(int id)
    {
        return _db.Genres.FirstOrDefault(g => g.Id == id);
    }

    public bool Save()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }

    public bool UpdateGenre(Genre genre)
    {
        genre.CreationDate = DateTime.Now;
        _db.Genres.Update(genre);
        return Save();
    }
}
