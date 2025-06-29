using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models.Dtos;

public class CreateUserDto
{
    [Required(ErrorMessage = "El campo Username es requerido")]
    public string? Username { get; set; }
    
    [Required(ErrorMessage = "El campo Email es requerido")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El campo Password es requerido")]
    public string? Password { get; set; }
}
