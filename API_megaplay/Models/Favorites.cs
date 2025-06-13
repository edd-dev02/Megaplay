using System;

namespace API_megaplay.Models;

public class Favorites
{

    public int UsersId { get; set; }
    public int MoviesId { get; set; }

    public User User { get; set; } = null!;
    public Movie Movie { get; set; } = null!;

}
