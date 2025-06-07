import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogListComponent } from './components/catalog-list/catalog-list.component';
import { FavoritesListComponent } from './components/favoritesList/favoritesList.component';
import { AuthGuard } from '../guards/auth.guard';

const routes: Routes = [
  {
    path: 'home',
    component: CatalogListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'favorites',
    component: FavoritesListComponent,
    canActivate: [AuthGuard]
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

