import { Component, Input, OnInit } from '@angular/core';
import { Doctor } from '../../interfaces/doctor.interface';
import { DoctorService } from '../../services/doctor.service';

@Component({
  selector: 'doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrl: './doctor-card.component.css'
})
export class DoctorCardComponent implements OnInit{
  // @Input()
  public doctors: Doctor[] = [];

  constructor( private doctorService: DoctorService){}

  ngOnInit(): void {
    this.doctorService.getDoctors()
    .subscribe(doctors => this.doctors = doctors);
  }
}
