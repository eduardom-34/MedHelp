import { Component, model, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialty.service';
import { Category } from '../../interfaces/cateogry.interface';
import { CategoriesServices } from '../../services/category.service';
import { map, Observable, of, startWith } from 'rxjs';

@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrl: './appointment-page.component.css',
  providers: [provideNativeDateAdapter()],
})
export class AppointmentPageComponent implements OnInit {

  public specialties: Specialty[] = [];
  public categories: Category[] = [];

  public options: Specialty[] = [];
  public filteredOptions: Observable<Specialty[]> = of([]);

  selectedSpecialty: any;

  doctors = [
    { id: 1, name: 'Dr. Smith', specialtyId: 1 },
    { id: 2, name: 'Dr. Johnson', specialtyId: 2 },
    // Agrega más doctores según tus datos
  ];

  availableTimes: string[] = [
    '09:00 AM', '10:00 AM', '11:00 AM', '01:00 PM', '02:00 PM'
  ];


  selected: Date | null = null;

  public appointmentForm: FormGroup;

  constructor(private fb: FormBuilder, private specialtiesService: SpecialtiesService, private categoriesServices: CategoriesServices) {

    this.appointmentForm = this.fb.group({
      specialty: ['', Validators.required],
      date: [''],
      time: [''],
      doctor: ['', Validators.required]
    });

  }

  ngOnInit(): void {

  }


  onDateSelected(selectedDate: Date): void {
    this.appointmentForm.patchValue({ date: selectedDate });
  }
}
