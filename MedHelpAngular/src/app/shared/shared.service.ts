import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor( private snackbar: MatSnackBar ) { }

  showSnackbar( message: string){
    this.snackbar.open(message, 'done', {
      duration: 2500,
    })
  }


}
