import { Component, OnInit } from '@angular/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialties.service';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrl: './list-page.component.css'
})
export class ListPageComponent implements OnInit {

  public specialties: Specialty[] = [];

  constructor(private specialtiesService: SpecialtiesService) { }

  ngOnInit(): void {
    this.specialtiesService.getSpecialties()
      .subscribe(specialties => this.specialties = specialties);
  }
}
