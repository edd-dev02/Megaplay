using System;

namespace API_megaplay.Models.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Username { get; set; } 
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }

    // TODO: Relación N:M con Movies
}