using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models.Dtos;

public class CreateMovieDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "La duración es obligatoria")]
    public TimeSpan Duration { get; set; }

    [Range(1.0, 10.0, ErrorMessage = "El puntaje debe estar entre 1.0 y 10.0")]
    public double Score { get; set; }

    [Required(ErrorMessage = "Debe especificarse el género")]
    public int GenreId { get; set; }
    [Required(ErrorMessage = "Debe especificarse la sección a la que pertenece")]
    public int SectionId { get; set; }

}

