import { CatalogRoutingModule } from './catalog-routing.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

import { CatalogListComponent } from './components/catalog-list/catalog-list.component';
import { MainPageComponent } from './pages/main-page.component';
import { FavoritesListComponent } from './components/favoritesList/favoritesList.component';



@NgModule({
  declarations: [
    CatalogListComponent,
    FavoritesListComponent,
    MainPageComponent,
  ],
  imports: [
    CatalogRoutingModule,
    CommonModule,
    RouterModule,
    SharedModule,
  ],
  exports: [
    CatalogListComponent,
    FavoritesListComponent,
    MainPageComponent,
  ]
})
export class CatalogModule { }
