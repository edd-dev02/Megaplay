import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../../interfaces/Movie.interface';

@Component({
  selector: 'catalog-favorites-list',
  templateUrl: './favoritesList.component.html',
  styleUrl: './favoritesList.component.css',
})
export class FavoritesListComponent {

  favoritos: Movie[] = [];

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.movieService.getFavorites().subscribe({
      next: (ids: number[]) => {
        // Ya se actualizó el BehaviorSubject, pero no tenemos los objetos Movie aún,
        // así que aquí podrías hacer otra petición o simplemente llamar a un método auxiliar
        this.loadFavoriteMovies();
      },
      error: (err) => {
        console.error('Error al cargar favoritos', err);
      }
    });
  }

  loadFavoriteMovies(): void {
    this.movieService.getMovies().subscribe({
      next: (allMovies: Movie[]) => {
        const favoritosIds = this.movieService.favoritosSubject.getValue(); // trae los IDs actuales
        this.favoritos = allMovies.filter(movie => favoritosIds.includes(movie.id));
      },
      error: (err) => {
        console.error('Error al cargar todas las películas', err);
      }
    });
  }

  eliminarFavorito(pelicula: Movie): void {
    this.movieService.removeFromFavorites(pelicula.id).subscribe({
      next: () => {
        this.favoritos = this.favoritos.filter(m => m.id !== pelicula.id);
      },
      error: (err) => {
        console.error('Error al eliminar favorito', err);
      }
    });
  }


}
