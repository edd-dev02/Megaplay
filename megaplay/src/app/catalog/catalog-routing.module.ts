import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogListComponent } from './components/catalog-list/catalog-list.component';
import { MainPageComponent } from './pages/main-page.component';
import { FavoritesListComponent } from './components/favoritesList/favoritesList.component';

const routes: Routes = [
  {
    path: 'home',
    component: CatalogListComponent
  },
  {
    path: 'favorites',
    component: FavoritesListComponent
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [
    RouterModule.forChild( routes )
  ],
  exports: [
    RouterModule
  ],
})
export class CatalogRoutingModule { }
