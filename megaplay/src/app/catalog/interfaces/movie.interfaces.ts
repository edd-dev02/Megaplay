export interface Movie {
  id: string;
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
