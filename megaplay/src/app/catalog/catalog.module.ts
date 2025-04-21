import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './pages/main-page.component';
import { CatalogNavComponent } from './components/catalog-nav/catalog-nav.component';
import { CatalogListComponent } from './components/catalog-list/catalog-list.component';



@NgModule({
  declarations: [
    MainPageComponent,
    CatalogNavComponent,
    CatalogListComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MainPageComponent
  ]
})
export class CatalogModule { }
