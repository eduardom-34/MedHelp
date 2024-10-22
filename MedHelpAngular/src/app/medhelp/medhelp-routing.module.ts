import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { ListSpecialtiesPageComponent } from './pages/list-specialties/list-specialties.component';
import { ListCategoriesPageComponent } from './pages/list-categories/list-categories.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutPageComponent,
    children: [
      {
        path: 'list-specialties',
        component: ListSpecialtiesPageComponent
      },
      {
        path: 'list-categories',
        component: ListCategoriesPageComponent
      },
      // {
      //   path: ':id',
      //   component: SpecialtyPageComponent
      // },
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
