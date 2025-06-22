import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, tap } from 'rxjs';
import { Movie } from '../../interfaces/Movie.interface';
import { appsettings } from '../../settings/appsettings';

@Injectable({
  providedIn: 'root'
})

export class MovieService {

  private baseUrl: string = appsettings.apiUrl;
  public favoritosSubject = new BehaviorSubject<number[]>([]);
  favoritos$ = this.favoritosSubject.asObservable();


  constructor(private http: HttpClient) {}

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.baseUrl}Movies`);
  }

  getFavorites(): Observable<number[]> {
  return this.http.get<Movie[]>(`${this.baseUrl}Favorites/movies`).pipe(
    map((movies: Movie[]) => movies.map(m => m.id)), // transformamos Movie[] a number[]
    tap((ids: number[]) => this.favoritosSubject.next(ids))
  );
}

  addToFavorites(movieId: number): Observable<any> {
  return this.http.post(`${this.baseUrl}Favorites/add?movieId=${movieId}`, null).pipe(
    tap(() => {
      const current = this.favoritosSubject.getValue();
      if (!current.includes(movieId)) {
        this.favoritosSubject.next([...current, movieId]); // 🔄 actualiza el observable
      }
    })
  );
}

  removeFromFavorites(movieId: number): Observable<any> {
  return this.http.delete(`${this.baseUrl}Favorites/remove?movieId=${movieId}`).pipe(
    tap(() => {
      const current = this.favoritosSubject.getValue();
      this.favoritosSubject.next(current.filter(id => id !== movieId));
    })
  );
}


  isFavorite(movieId: number): boolean {
    return this.favoritosSubject.getValue().includes(movieId);
  }

}

