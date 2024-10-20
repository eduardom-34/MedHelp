import { Component } from '@angular/core';
import {  FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../interfaces/login.interface';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginPageComponent {

  public myForm: FormGroup;

  constructor( private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.myForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(3)]]
    })
  }

// TODO: show that the password is wrong in case it is

  onLogin(): void {


    const request: Login = {
      username: this.myForm.value.username,
      password: this.myForm.value.password
    }
    this.authService.login(request.username, request.password)
      .subscribe( user => {
        this.router.navigate(['/medhelp/']);
      });

  }

}
