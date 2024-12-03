import { Component, model, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialty.service';
import { Category } from '../../interfaces/category.interface';
import { CategoriesServices } from '../../services/category.service';
import { map, Observable, of, startWith } from 'rxjs';
import { DoctorService } from '../../services/doctor.service';
import { Doctor, SpecialtyName } from '../../interfaces/doctor.interface';

@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrl: './appointment-page.component.css',
  providers: [provideNativeDateAdapter()],
})
export class AppointmentPageComponent implements OnInit {

  public specialties: Specialty[] = [];
  public doctors: Doctor[] = [];
  public categories: Category[] = [];

  public options: Specialty[] = [];
  public filteredOptions: Observable<Specialty[]> = of([]);

  selectedSpecialty: any;

  // doctors = [
  //   { id: 1, name: 'Dr. Smith', specialtyId: 1 },
  //   { id: 2, name: 'Dr. Johnson', specialtyId: 2 },
  // ];

  availableTimes: string[] = [
    '09:00 AM', '10:00 AM', '11:00 AM', '01:00 PM', '02:00 PM'
  ];


  selected: Date | null = null;

  public appointmentForm: FormGroup;

  constructor(private fb: FormBuilder,
    private specialtiesService: SpecialtiesService,
    private categoriesService: CategoriesServices,
    private doctorService: DoctorService) {

    this.appointmentForm = this.fb.group({
      specialty: ['', Validators.required],
      date: [''],
      time: [''],
      doctor: ['', Validators.required]
    });

  }

  ngOnInit(): void {
    this.specialtiesService.getSpecialties()
      .subscribe( specialties => this.specialties = specialties );

    this.doctorService.getDoctors()
      .subscribe( doctors => this.doctors = doctors );

    this.categoriesService.getCategories()
    .subscribe( categories => this.categories = categories );

  }

  onDateSelected(selectedDate: Date): void {
    this.appointmentForm.patchValue({ date: selectedDate });
  }

  // Specialties Methods

  get specialtyControl(): FormControl<string | Specialty | null>{
    return this.appointmentForm.get('specialty') as FormControl<string | Specialty | null>;
  }

  onCheckboxChange(specialty: Specialty) {
    // this updates the value of the form with the selected object
    this.appointmentForm.patchValue({ specialty });
  }

  isSelected(specialty: Specialty): boolean {
    //Veirfy if this object is currently selected
    return this.appointmentForm.value.specialty?.id === specialty.id;
  }


  // Doctor methods
}
