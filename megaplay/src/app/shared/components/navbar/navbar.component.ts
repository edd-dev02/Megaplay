import { Component } from '@angular/core';
import { AuthService } from '../../../auth/services/access.service';

@Component({
  selector: 'shared-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {

  constructor(private authService: AuthService) { }

  logout(): void {
    this.authService.logout(); // Elimina token y redirige
  }

}
