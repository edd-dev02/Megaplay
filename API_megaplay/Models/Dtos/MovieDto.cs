using System;

namespace API_megaplay.Models.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public double Score { get; set; }
    public string Trailer { get; set; } = string.Empty;
    public string Posterpath { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public int SectionId { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}

