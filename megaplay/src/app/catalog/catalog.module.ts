import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './pages/main-page.component';
import { CatalogNavComponent } from './components/catalog-nav/catalog-nav.component';
import { CatalogListComponent } from './components/catalog-list/catalog-list.component';
import { FavoritesModule } from '../favorites/favorites.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MainPageComponent,
    CatalogNavComponent,
    CatalogListComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    MainPageComponent,
    CatalogNavComponent,
    CatalogListComponent
  ]
})
export class CatalogModule { }
