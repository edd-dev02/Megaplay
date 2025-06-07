export class Movie {

  public movieId: number;

  constructor(movieId: number) {
    this.movieId = movieId;
  }

  // Encapsulamiento
  public getMovieId(): number {
    return this.movieId;
  }

  public setMovieId(movieId: number): void {
    this.movieId = movieId;
  }

}
