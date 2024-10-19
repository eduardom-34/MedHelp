import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../interfaces/login.interface';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginPageComponent {

  constructor( private authService: AuthService,
    private router: Router
  ) {}


  onLogin(): void {

    this.authService.login('cesar', 'cesar')
      .subscribe( user => {
        this.router.navigate(['/medhelp/']);
      });

  }

}
