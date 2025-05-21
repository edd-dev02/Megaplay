import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CatalogModule } from './catalog/catalog.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from "./shared/shared.module";
import { AuthModule } from './auth/auth.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CatalogModule,
    HttpClientModule,
    SharedModule,
    AuthModule
],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
