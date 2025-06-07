using System;

namespace API_megaplay.Models.Dtos;

public class SectionDto
{
    // Dto para listar las secciones del catálogo
    public int Id { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}
