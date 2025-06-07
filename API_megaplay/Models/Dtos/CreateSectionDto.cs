using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models.Dtos;

public class CreateSectionDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(50, ErrorMessage = "El nombre del género no puede tener más de 50 carácteres")]
    [MinLength(3, ErrorMessage = "El nombre del género no puede tener menos de 3 carácteres")]
    public string SectionName { get; set; } = string.Empty;
}
