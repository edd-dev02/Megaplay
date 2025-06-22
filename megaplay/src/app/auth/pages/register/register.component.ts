import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/access.service';
import { CreateUserDto } from '../../../interfaces/CreateUserDto.interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    username: ['', [Validators.required, Validators.minLength(3)]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  registerError: string | null = null;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  onSubmit(): void {
    if (this.registerForm.invalid) return;

    const newUser = this.registerForm.value as CreateUserDto;

    this.authService.register(newUser).subscribe({
      next: () => {
        this.router.navigate(['/auth/login']); //
      },
      error: err => {
        console.error('Error al registrarse:', err);
        this.registerError = 'No se pudo crear el usuario. Intenta con otro correo.';
      }
    });
  }

  get email() {
    return this.registerForm
  }

  get username() {
    return this.registerForm.get('username');
  }

  get password() {
    return this.registerForm.get('password');
  }

}
