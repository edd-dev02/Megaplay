import { Component } from '@angular/core';
import { Movie } from '../../catalog/interfaces/movie.interfaces';
import { MovieService } from '../../catalog/services/movie.service';

@Component({
  selector: 'favorites-list-component',
  templateUrl: './favoritesList.component.html',
  styleUrl: './favoritesList.component.css',
})
export class FavoritesListComponent {

  favoritos: Movie[] = [];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.favoritos = this.movieService.obtenerFavoritos();
  }

  eliminar(id: string): void {
    this.movieService.eliminarDeFavoritos(id);
    this.favoritos = this.movieService.obtenerFavoritos();

  }

}
