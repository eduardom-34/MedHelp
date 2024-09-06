import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button'



@NgModule({
  exports:[
    MatButtonModule
  ],
  imports: [
    CommonModule
  ]
})
export class MaterialModule { }
