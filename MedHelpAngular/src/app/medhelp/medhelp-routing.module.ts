import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { SpecialtyPageComponent } from './pages/specialty-page/specialty-page.component';
import { ListSpecialtiesPageComponent } from './pages/list-specialties/list-specialties.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutPageComponent,
    children: [
      {
        path: 'specialty',
        component: SpecialtyPageComponent
      },
      {
        path: 'list-specialties',
        component: ListSpecialtiesPageComponent
      },
      {
        path: ':id',
        component: SpecialtyPageComponent
      },
      {
        path: '**',
        redirectTo: 'list-specialties'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedhelpRoutingModule { }
