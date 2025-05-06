import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie, MovieData } from '../interfaces/movie.interfaces';

@Injectable({
  providedIn: 'root'
})

export class MovieService {

  private url = 'assets/data/movies.json'
  private FAVORITOS_KEY = 'peliculas_favoritas';

  constructor(private http: HttpClient) { }

  // Obtiene todas las peliculas del objeto JSON
  getMovies(): Observable<MovieData> {
    return this.http.get<MovieData>(this.url);
  }

  // Obtiene todos las peliculas guardadas en el localstorage
  obtenerFavoritos(): Movie[] {
    const data = localStorage.getItem(this.FAVORITOS_KEY);
    return data ? JSON.parse(data) : [];
  }

  // Guarda una película en el localStorage
  agregarAFavoritos(pelicula: Movie): void {
    const favoritos = this.obtenerFavoritos();
    const yaExiste = favoritos.some(p => p.id === pelicula.id);

    if (!yaExiste) {
      favoritos.push(pelicula);
      localStorage.setItem(this.FAVORITOS_KEY, JSON.stringify(favoritos));
      console.log('Pelicula agregada a Favoritos');
    }
  }

  // Verifica si una película ya está en favoritos
  estaEnFavoritos(id: string): boolean {
    const favoritos = this.obtenerFavoritos();
    return favoritos.some(p => p.id === id);
  }

  // Elimina del localStorage mediante el id
  eliminarDeFavoritos(id: string): void {
    const favoritos = this.obtenerFavoritos();
    const nuevosFavoritos = favoritos.filter(p => p.id !== id);
    localStorage.setItem(this.FAVORITOS_KEY, JSON.stringify(nuevosFavoritos));
    console.log('Película eliminada de Favoritos');
  }

}

