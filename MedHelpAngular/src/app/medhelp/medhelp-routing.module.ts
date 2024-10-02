import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { SpecialtyPageComponent } from './pages/specialty-page/specialty-page.component';
import { SpecialtiesListComponent } from './pages/specialties-list/specialties-list.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutPageComponent,
    children: [
      {
        path: 'specialties',
        component: SpecialtiesListComponent
      },
      {
        path: 'specialty',
        component: SpecialtyPageComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedhelpRoutingModule { }
