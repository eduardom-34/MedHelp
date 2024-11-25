import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedhelpRoutingModule } from './medhelp-routing.module';
import { MaterialModule } from '../material/material.module';

import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { ListSpecialtiesPageComponent } from './pages/list-specialties/list-specialties.component';
import { CardComponent } from './components/specialty-card/specialty-card.component';
import { ListCategoriesPageComponent } from './pages/list-categories/list-categories.component';
import { CategoryCardComponent } from './components/category-card/category-card.component';
import { AppointmentPageComponent } from './pages/appointment-page/appointment-page.component';
import { SharedModule } from '../shared/shared.module';
import { DoctorCardComponent } from './components/doctor-card/doctor-card.component';
import { AutocompleteSpecialtyComponent } from './components/autocomplete-specialty/autocomplete-specialty.component';

@NgModule({
  declarations: [
    LayoutPageComponent,
    ListSpecialtiesPageComponent,
    CardComponent,
    ListCategoriesPageComponent,
    CategoryCardComponent,
    AppointmentPageComponent,
    DoctorCardComponent,
    AutocompleteSpecialtyComponent,
  ],
  imports: [
    CommonModule,
    MedhelpRoutingModule,
    MaterialModule,
    SharedModule
  ]
})
export class MedhelpModule { }
