// auth.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Login } from '../../interfaces/Login.interface';
import { AuthResponse } from '../../interfaces/AuthResponse.interface';
import { Router } from '@angular/router';
import { appsettings } from '../../settings/appsettings';
import { CreateUserDto } from '../../interfaces/CreateUserDto.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = appsettings.apiUrl;
  private tokenKey = 'auth_token';

  constructor(private http: HttpClient, private router: Router) { }

  register(data: CreateUserDto): Observable<any> {
    return this.http.post(`${this.baseUrl}Users`, data);
  }

  // Login: guarda el token recibido
  login(data: Login): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.baseUrl}Users/Login`, data).pipe(
      tap(resp => {
        localStorage.setItem(this.tokenKey, resp.token);
      })
    );
  }

  // Logout: borra el token y redirige
  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/auth/login']);
  }

  // Obtiene el token del localStorage
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // Verifica si el token ha expirado
  private isTokenExpired(token: string): boolean {
    try {
      const [, payloadBase64] = token.split('.');
      const payload = JSON.parse(atob(payloadBase64));
      const now = Math.floor(Date.now() / 1000);
      return payload.exp < now;
    } catch (e) {
      return true; // Si no puede leer el token, se considera inválido
    }
  }

  // Verifica si el usuario está logueado y el token es válido
  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token || this.isTokenExpired(token)) {
      this.logout(); // Borra token si ya no sirve
      return false;
    }
    return true;
  }
}

