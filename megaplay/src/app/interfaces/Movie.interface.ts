import { Genre } from './Genre.interface';
import { Section } from './Section.interface';

export interface Movie {
  id: number;
  title: string;
  description: string;
  duration: string;
  score: number;
  trailer: string;
  posterpath: string;
  genreId: number;
  genreName: string;
  sectionId: number;
  sectionName: string;
  creationDate?: string;
}
