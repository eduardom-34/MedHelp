import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule } from '@angular/forms';

import { Error404PageComponent } from './pages/error404-page/error404-page.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';



@NgModule({
  declarations: [
    Error404PageComponent,
    LoadingSpinnerComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    Error404PageComponent,
    LoadingSpinnerComponent,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
