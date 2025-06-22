import { HttpClientModule, provideHttpClient } from "@angular/common/http";
import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from "@angular/core";
import { provideClientHydration } from "@angular/platform-browser";
import { provideRouter } from "@angular/router";


export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection( { eventCoalescing: true } ),
    provideClientHydration(),
    provideHttpClient(),
    importProvidersFrom(HttpClientModule)
  ]
};
