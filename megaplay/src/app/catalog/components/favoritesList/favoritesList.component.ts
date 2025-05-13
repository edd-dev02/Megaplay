import { Component, OnInit } from '@angular/core';
import { Movie } from '../../interfaces/movie.interfaces';
import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'catalog-favorites-list',
  templateUrl: './favoritesList.component.html',
  styleUrl: './favoritesList.component.css',
})
export class FavoritesListComponent implements OnInit{
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
