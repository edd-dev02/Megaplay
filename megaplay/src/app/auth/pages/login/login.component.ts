import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../services/access.service';
import { Router } from '@angular/router';
import { Login } from '../../../interfaces/Login.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  loginError: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    // Si ya está logueado, redirige automáticamente
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/catalog']);
    }
  }

  onSubmit(): void {
    if (this.loginForm.invalid) return;

    const credentials: Login = {
      email: this.email?.value ?? '',
      password: this.password?.value ?? ''
    };

    this.authService.login(credentials).subscribe({
      next: () => {
        this.router.navigate(['/catalog']);
      },
      error: (err) => {
        console.error('Error al iniciar sesión:', err);
        this.loginError = 'Correo o contraseña incorrectos.';
      }
    });
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
