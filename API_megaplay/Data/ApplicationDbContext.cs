using System;
using API_megaplay.Models;
using Microsoft.EntityFrameworkCore;

namespace API_megaplay.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // DB Sets
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Section> Sections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación en cascada de Peliculas con Géneros
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación en cascada de Peliculas con Secciones
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Section)
            .WithMany(s => s.Movies)
            .HasForeignKey(m => m.SectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
