using System;

namespace API_megaplay.Models.Dtos;

public class FavoritesDto
{

    public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public double Score { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public string SectionName { get; set; } = string.Empty;


}
