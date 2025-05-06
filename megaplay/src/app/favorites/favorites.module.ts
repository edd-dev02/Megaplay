import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavoritesListComponent } from './favoritesList/favoritesList.component';
import { CatalogModule } from '../catalog/catalog.module';



@NgModule({
  declarations: [
    FavoritesListComponent
  ],
  imports: [
    CommonModule,
    CatalogModule
  ],
  exports: [
    FavoritesListComponent
  ]
})
export class FavoritesModule { }
