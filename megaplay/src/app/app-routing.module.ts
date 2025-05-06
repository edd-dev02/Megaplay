import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FavoritesListComponent } from './favorites/favoritesList/favoritesList.component';
import { CatalogListComponent } from './catalog/components/catalog-list/catalog-list.component';

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
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
