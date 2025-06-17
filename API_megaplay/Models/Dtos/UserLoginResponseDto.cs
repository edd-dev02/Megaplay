using System;

namespace API_megaplay.Models.Dtos;

public class UserLoginResponseDto
{
    public UserRegisterDto? User { get; set; } // Es nulo por si no es posible el login
    public string? Token { get; set; }
    public string? Message { get; set; }
}
