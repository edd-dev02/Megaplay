using System;

namespace API_megaplay.Models.Dtos;

public class UserRegisterDto
{
    public string? ID { get; set; }
    //public int UserId { get; set; }
    public string? Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
