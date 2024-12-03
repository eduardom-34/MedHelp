import { Component, Input, OnInit } from '@angular/core';
import { Doctor } from '../../interfaces/doctor.interface';
import { DoctorService } from '../../services/doctor.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrl: './doctor-card.component.css'
})
export class DoctorCardComponent implements OnInit{

  @Input()
  public doctor?: Doctor;

  // @Input()
  // // myControl!: FormControl;
  // myControl = new FormControl<string | Doctor >('');

  ngOnInit(): void {
    if ( !this.doctor ) throw Error('Specialty property is requiered');

  }

}
