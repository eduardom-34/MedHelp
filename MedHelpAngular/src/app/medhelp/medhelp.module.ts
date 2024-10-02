import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedhelpRoutingModule } from './medhelp-routing.module';
import { SpecialtyPageComponent } from './pages/specialty-page/specialty-page.component';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { SpecialtiesListComponent } from './pages/specialties-list/specialties-list.component';


@NgModule({
  declarations: [
    SpecialtyPageComponent,
    LayoutPageComponent,
    SpecialtiesListComponent
  ],
  imports: [
    CommonModule,
    MedhelpRoutingModule
  ]
})
export class MedhelpModule { }
