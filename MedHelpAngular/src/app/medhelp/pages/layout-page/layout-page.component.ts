import { Component } from '@angular/core';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styleUrl: './layout-page.component.css'
})
export class LayoutPageComponent {

  public sidebarItems = [
    {
      label: 'List',
      icon: 'label',
      url: './list-specialties'
    },
    {
      label: 'Specialty',
      icon: 'add',
      url: './specialty'
    }
  ]

}
