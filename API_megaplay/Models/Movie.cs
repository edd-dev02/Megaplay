using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models;

public class Movie
{

    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(typeof(TimeSpan), "00:30:00", "05:00:00", ErrorMessage = "La duración debe ser entre 30 minutos mínimo y 5 horas máximo")]
    public TimeSpan Duration { get; set; }
    [Required]
    [Range(1.0, 10.0, ErrorMessage = "La puntuación debe estar entre 1.0 y 10.0")]
    public double Score { get; set; }
    [Required]
    public string Trailer { get; set; } = string.Empty;
    [Required]
    public string Posterpath { get; set; } = string.Empty;
    [Required]
    public DateTime CreationDate { get; set; }

    // Foreign Key: Géneros
    [Required]
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    // Foreign Key: Secciones
    [Required]
    public int SectionId { get; set; }
    public Section? Section { get; set; }

    // TODO: Relación N:M con Users
    public ICollection<Favorites> Favorites { get; set; } = new List<Favorites>();

}
