using System;
using API_megaplay.Models;
using Microsoft.EntityFrameworkCore;

namespace API_megaplay.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // DB Sets: Se definen las tablas de la BD
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Favorites> Favorites { get; set; }

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

        // Relación N:M Usuarios-Peliculas para crear favoritos
        modelBuilder.Entity<Favorites>()
        .HasKey(f => new { f.UsersId, f.MoviesId }); // Clave compuesta

        modelBuilder.Entity<Favorites>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UsersId);

        modelBuilder.Entity<Favorites>()
            .HasOne(f => f.Movie)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MoviesId);
    }
}
