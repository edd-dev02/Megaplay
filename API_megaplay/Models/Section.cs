using System;
using System.ComponentModel.DataAnnotations;

namespace API_megaplay.Models;

public class Section
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string SectionName { get; set; } = string.Empty;
    [Required]
    public DateTime CreationDate { get; set; }

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    
}
