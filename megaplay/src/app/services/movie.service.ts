import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Movie {
  titulo: string;
  descripcion: string;
  duracion: string;
  calificacion: number;
  genero: string;
  imagen: string;
}

export interface MovieData {
  hero: Movie[];
  mas_vistas: Movie[];
  recomendados: Movie[];
}


@Injectable({
  providedIn: 'root'
})

export class MovieService {

  private url = 'assets/data/movies.json'

  constructor(private http: HttpClient) { }

  getMovies(): Observable<MovieData> {
    return this.http.get<MovieData>(this.url);
  }
}
