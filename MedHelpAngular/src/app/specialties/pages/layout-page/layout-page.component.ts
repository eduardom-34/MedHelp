import { Component, inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';

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
      url: './list'
    },
    {
      label: 'Appointments',
      icon: 'add',
      url: './appointments'

    }
  ]

}
