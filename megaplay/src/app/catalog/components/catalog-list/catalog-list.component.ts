import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'; // 👈 agregamos EventEmitter y Output
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../interfaces/movie.interfaces';

@Component({
  selector: 'catalog-list',
  templateUrl: './catalog-list.component.html',
  styleUrls: ['./catalog-list.component.css']
})
export class CatalogListComponent implements OnInit {


  // @Input() peliculas: Movie[] = [];

  @Output() quitarFavorito = new EventEmitter<string>();

  public hero: Movie[] = [];
  public masVistas: Movie[] = [];
  public recomendados: Movie[] = [];

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.movieService.getMovies().subscribe(data => {
      this.hero = data.hero;
      this.masVistas = data.mas_vistas;
      this.recomendados = data.recomendados;
      console.log(data);
    });
  }

  estaEnFavoritos(pelicula: Movie): boolean {
    return this.movieService.estaEnFavoritos(pelicula.id);
  }

  toggleFavorito(pelicula: Movie): void {
    if (this.estaEnFavoritos(pelicula)) {
      this.movieService.eliminarDeFavoritos(pelicula.id);
      this.quitarFavorito.emit(pelicula.id);
    } else {
      this.movieService.agregarAFavoritos(pelicula);
    }
  }

}
