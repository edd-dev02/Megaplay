using System;

namespace API_megaplay.Models.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    // TODO: Relación N:M con Movies
}
