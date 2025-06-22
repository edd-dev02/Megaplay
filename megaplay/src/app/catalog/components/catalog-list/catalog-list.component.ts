import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../../interfaces/Movie.interface';

@Component({
  selector: 'catalog-list',
  templateUrl: './catalog-list.component.html',
  styleUrls: ['./catalog-list.component.css']
})
export class CatalogListComponent implements OnInit {

  hero: Movie[] = [];
  masVistos: Movie[] = [];
  recomendados: Movie[] = [];

  favoritosIds: number[] = [];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe({
      next: (movies) => {
        this.hero = movies.filter(m => m.sectionName === 'Hero');
        this.masVistos = movies.filter(m => m.sectionName === 'Mas_vistos');
        this.recomendados = movies.filter(m => m.sectionName === 'Recomendados');
      },
      error: (err) => {
        console.error('Error al obtener películas:', err);
      }
    });

    this.movieService.getFavorites().subscribe();

    this.movieService.favoritos$.subscribe(ids => {
      this.favoritosIds = ids;
    });

  }

  verTrailer(trailerUrl: string): void {
    if (trailerUrl) {
      window.open(trailerUrl, '_blank');
    } else {
      console.warn('No hay trailer disponible');
    }
  }

  toggleFavorito(pelicula: Movie): void {
    const isFav = this.favoritosIds.includes(pelicula.id);

    if (isFav) {
      this.movieService.removeFromFavorites(pelicula.id).subscribe({
        next: () => {
          // No hace falta volver a llamar a getFavorites()
          console.log(`Película ${pelicula.id} eliminada de favoritos`);
        },
        error: (err) => {
          console.error('Error al eliminar de favoritos', err);
        }
      });
    } else {
      this.movieService.addToFavorites(pelicula.id).subscribe({
        next: () => {
          console.log(`Película ${pelicula.id} agregada a favoritos`);
        },
        error: (err) => {
          if (err.status === 409) {
            console.warn('La película ya estaba en favoritos (backend)');
          } else {
            console.error('Error al agregar a favoritos', err);
          }
        }
      });
    }
  }

  estaEnFavoritos(pelicula: Movie): boolean {
    return this.favoritosIds.includes(pelicula.id);
  }
}


