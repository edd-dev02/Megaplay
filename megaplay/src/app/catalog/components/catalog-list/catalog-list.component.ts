import { Component, OnInit } from '@angular/core';
import { Movie, MovieService } from '../../../services/movie.service';

@Component({
  selector: 'catalog-list',
  templateUrl: './catalog-list.component.html',
  styleUrls: ['./catalog-list.component.css']
})
export class CatalogListComponent implements OnInit {

  hero: Movie[] = [];
  masVistas: Movie[] = [];
  recomendados: Movie[] = [];

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.movieService.getMovies().subscribe(data => {
      this.hero = data.hero;
      this.masVistas = data.mas_vistas;
      this.recomendados = data.recomendados;

    console.log(data);

    });

  }

}
