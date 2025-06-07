using System;

namespace API_megaplay.Models.Dtos;

public class GenreDto
{

    // Dto para listar géneros de pelicula
    public int Id { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }

}
