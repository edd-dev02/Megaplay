import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FavoritesListComponent } from './favoritesList.component';
import { MovieService } from '../../catalog/services/movie.service';
import { Movie } from '../../catalog/interfaces/movie.interfaces';
import { of } from 'rxjs';

describe('FavoritesListComponent', () => {
  let component: FavoritesListComponent;
  let fixture: ComponentFixture<FavoritesListComponent>;
  let mockMovieService: jasmine.SpyObj<MovieService>;

  const falsasPelis: Movie[] = [
    {
      id: '1',
      titulo: 'Película 1',
      calificacion: 8.5,
      imagen: 'url1',
      descripcion: 'Descripción 1',
      duracion: '120 min',
      genero: 'Acción',
    },
    {
      id: '2',
      titulo: 'Película 2',
      calificacion: 7.2,
      imagen: 'url2',
      descripcion: 'Descripción 2',
      duracion: '90 min',
      genero: 'Drama',
    }
  ];


  beforeEach(async () => {
    mockMovieService = jasmine.createSpyObj('MovieService', ['obtenerFavoritos', 'eliminarDeFavoritos']);
    mockMovieService.obtenerFavoritos.and.returnValue(falsasPelis);

    await TestBed.configureTestingModule({
      declarations: [FavoritesListComponent],
      providers: [{ provide: MovieService, useValue: mockMovieService }]
    }).compileComponents();

    fixture = TestBed.createComponent(FavoritesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Crear el componente', () => {
    expect(component).toBeTruthy();
  });

  it('Cargar los favoritos al inicializar', () => {
    expect(component.favoritos.length).toBe(2);
    expect(component.favoritos[0].titulo).toBe('Película 1');
  });

  it('Eliminar una película de favoritos y actualizar la lista', () => {
    mockMovieService.obtenerFavoritos.and.returnValue([falsasPelis[1]]); // simula que se eliminó la primera
    component.eliminar('1');
    expect(mockMovieService.eliminarDeFavoritos).toHaveBeenCalledWith('1');
    expect(component.favoritos.length).toBe(1);
    expect(component.favoritos[0].id).toBe('2');
  });
});
