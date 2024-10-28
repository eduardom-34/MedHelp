import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Sesion } from '../../../auth/pages/interfaces/sesion.interface';
import { AuthService } from '../../../auth/services/auth.service';
import { SharedService } from '../../../shared/shared.service';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styleUrl: './layout-page.component.css'
})
export class LayoutPageComponent {

  public sidebarItems = [
    {
      label: 'List of specialties',
      icon: 'label',
      url: './list-specialties'
    },
    {
      label: 'List of categories',
      icon: 'group',
      url: './list-categories'
    },
    {
      label: 'Appointment',
      icon: 'calendar_month',
      url: './appointment'
    }
  ];

  constructor( private authService: AuthService,
    private router: Router, private sharedService: SharedService
   ) {}

  get user(): Sesion | undefined {
    return this.authService.currentUser;
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigate(['/auth/login']);
    this.sharedService.showSnackbar("You logged out");
  }

}
