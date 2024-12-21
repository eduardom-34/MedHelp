import { Component, model, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialty.service';
import { Category } from '../../interfaces/category.interface';
import { CategoriesServices } from '../../services/category.service';
import { map, Observable, of, startWith, switchMap } from 'rxjs';
import { DoctorService } from '../../services/doctor.service';
import { Doctor, SpecialtyName } from '../../interfaces/doctor.interface';
import { scheduleService } from '../../services/schedule.service';
import { Schedule } from '../../interfaces/schedule.interface';

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
  public schedules: Schedule[] = [];

  public options: Specialty[] = [];
  public filteredOptions: Observable<Specialty[]> = of([]);

  // Calendar
  selected: Date | null = null;
  availableDates: Date[] = [
    new Date(2024, 11, 12), // 12 de diciembre de 2024
    new Date(2024, 11, 15), // 15 de diciembre de 2024
    new Date(2024, 11, 20), // 20 de diciembre de 2024
  ];


  public firstAppointmentForm: FormGroup;
  public secondAppointmentForm: FormGroup;

  constructor(private fb: FormBuilder,
    private specialtiesService: SpecialtiesService,
    private categoriesService: CategoriesServices,
    private doctorService: DoctorService,
    private scheduleService: scheduleService) {

    this.firstAppointmentForm = this.fb.group({
      specialty: ['', Validators.required],
    });

    this.secondAppointmentForm = this.fb.group({
      doctor: ['', Validators.required],
    });

  }

  ngOnInit(): void {

    this.onSpecialtyChanged();

    this.specialtiesService.getSpecialties()
      .subscribe( specialties => this.specialties = specialties );

    this.doctorService.getDoctors()
      .subscribe( doctors => this.doctors = doctors );

    this.categoriesService.getCategories()
    .subscribe( categories => this.categories = categories );

    this.scheduleService.getSchedules()
    .subscribe( schedules => this.schedules = schedules );

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

  onSpecialtyChanged(): void {
    this.firstAppointmentForm.get('specialty')!.valueChanges
      .pipe(
        map( (specialty: Specialty) => specialty.id ),
        switchMap( specialty => this.doctorService.getDoctorsBySpecialty(specialty))
      )
      .subscribe( doctors => this.doctors = doctors );
  }

  // Calendar methods:

  // Filtro de fechas
  dateFilter = (date: Date | null): boolean => {
    if (!date) return false;
    // Verifica si la fecha está en la lista de días disponibles
    return this.availableDates.some(
      (availableDate) =>
        availableDate.getDate() === date.getDate() &&
        availableDate.getMonth() === date.getMonth() &&
        availableDate.getFullYear() === date.getFullYear()
    );
  };

  // here we need to update the form thirdAppointmentForm
  onDateSelected(selectedDate: Date | null): void {
    this.firstAppointmentForm.patchValue({ date: selectedDate });
  }

}
