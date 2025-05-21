import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable, take, tap } from 'rxjs';
import { AuthService } from './services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private auth: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {

    /*
    const isAuthenticated = true; // Cambiar luego por lógica real

    if (!isAuthenticated) {
      this.router.navigate(['/auth/login']); // redirección de prueba
      return false;
    }
    */

    return this.auth.isLoggedIn$.pipe(
      take(1),
      tap(loggedIn => {
        if (!loggedIn) {
          this.router.navigate(['/auth/login']);
        }
      })
    );

  }

}


