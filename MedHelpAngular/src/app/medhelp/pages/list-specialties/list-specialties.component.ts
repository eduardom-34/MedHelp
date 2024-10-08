import { Component, OnInit } from '@angular/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialty.service';

@Component({
  selector: 'app-list-specialties',
  templateUrl: './list-specialties.component.html',
  styleUrl: './list-specialties.component.css'
})
export class ListSpecialtiesPageComponent implements OnInit {

  public specialties: Specialty[] = [];


  constructor( private specialtiesService: SpecialtiesService ) {}

  ngOnInit(): void {
    this.specialtiesService.getSpecialties()
      .subscribe( specialties => this.specialties = specialties );
  }

}
