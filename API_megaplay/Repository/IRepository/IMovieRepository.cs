using API_megaplay.Models;

namespace API_megaplay.Repository.IRepository;

public interface IMovieRepository
{
    ICollection<Movie> GetMovies();
    Movie? GetMovie(int id);
    bool MovieExists(int id);
    bool MovieExists(string title);

    bool CreateMovie(Movie movie);
    bool UpdateMovie(Movie movie);
    bool DeleteMovie(Movie movie);
    bool Save();
}