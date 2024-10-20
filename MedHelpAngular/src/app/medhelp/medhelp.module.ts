import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedhelpRoutingModule } from './medhelp-routing.module';
import { MaterialModule } from '../material/material.module';

import { SpecialtyPageComponent } from './pages/specialty-page/specialty-page.component';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { ListSpecialtiesPageComponent } from './pages/list-specialties/list-specialties.component';
import { CardComponent } from './components/specialty-card/specialty-card.component';
import { ListCategoriesComponent } from './pages/list-categories/list-categories.component';
import { CategoryCardComponent } from './components/category-card/category-card.component';

@NgModule({
  declarations: [
    SpecialtyPageComponent,
    LayoutPageComponent,
    ListSpecialtiesPageComponent,
    CardComponent,
    ListCategoriesComponent,
    CategoryCardComponent,
  ],
  imports: [
    CommonModule,
    MedhelpRoutingModule,
    MaterialModule
  ]
})
export class MedhelpModule { }
