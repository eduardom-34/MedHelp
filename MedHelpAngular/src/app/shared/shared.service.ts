import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor( private snackbar: MatSnackBar ) { }

  showSnackbar( message: string, type: string){
    this.snackbar.open(message, type, {
      // horizontalPosition: "end",
      verticalPosition: "top",
      duration: 2000,
    })
  }


}
