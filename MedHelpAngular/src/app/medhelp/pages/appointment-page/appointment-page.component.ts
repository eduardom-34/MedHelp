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

  selected: Date | null = null;

  public firstAppointmentForm: FormGroup;
  public secondAppointmentForm: FormGroup;

  constructor(private fb: FormBuilder,
    private specialtiesService: SpecialtiesService,
    private categoriesService: CategoriesServices,
    private doctorService: DoctorService) {

    this.firstAppointmentForm = this.fb.group({
      specialty: ['', Validators.required],
    });

    this.secondAppointmentForm = this.fb.group({
      // specialty: ['', Validators.required],
      doctor: ['', Validators.required],
      // date: [''],
      // time: [''],
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

  // here we need to update the form thirdAppointmentForm
  onDateSelected(selectedDate: Date): void {
    this.firstAppointmentForm.patchValue({ date: selectedDate });
  }

  // Specialties Methods

  get specialtyControl(): FormControl<string | Specialty | null>{
    return this.firstAppointmentForm.get('specialty') as FormControl<string | Specialty | null>;
  }

  onCheckboxChange(specialty: Specialty) {
    // this updates the value of the form with the selected object
    this.firstAppointmentForm.patchValue({ specialty });
  }

  isSelected(specialty: Specialty): boolean {
    //Veirfy if this object is currently selected
    return this.firstAppointmentForm.value.specialty?.id === specialty.id;
  }


  // Doctor methods

  get doctorControl(): FormControl<string | Doctor | null>{
    return this.secondAppointmentForm.get('doctor') as FormControl<string | Doctor | null>;
  }

  onDoctorSelected( doctor: Doctor): void {
    this.secondAppointmentForm.patchValue({ doctor });
  }
}
