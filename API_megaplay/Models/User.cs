using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models;

public class User
{


    [Key]
    public int UserId { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // TODO: Relación N:M con Movies
    public ICollection<Favorites> Favorites { get; set; } = new List<Favorites>();


}
