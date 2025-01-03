import { Component, model, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { SpecialtiesService } from '../../services/specialty.service';
import { Category } from '../../interfaces/category.interface';
import { CategoriesServices } from '../../services/category.service';
import { lastValueFrom, map, Observable, of, startWith, switchMap } from 'rxjs';
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

  public datesFromBackend: Date[] = [];

  public options: Specialty[] = [];
  public filteredOptions: Observable<Specialty[]> = of([]);

  // Calendar
  public selected: Date | null = null;
  public availableDates: Date[] = [];

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
    .subscribe( schedules => {

      // Updating dates from backend
      this.schedules = schedules;
      // this.updateAvailableDates();

    } );

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
  async updateAvailableDates(doctor: Doctor): Promise<void> {

    try {
      const schedules = await this.getSheduleByDoctorId(doctor.id);

      this.schedules = schedules;

      this.availableDates = this.schedules.map((schedule) =>
      new Date(schedule.date));
    } catch (error) {
      console.error(error);
    }

  }

  // Investigating ifd we can use async await so we don have to double click for it

  async getSheduleByDoctorId(id: number): Promise<Schedule[]> {
    try {
      const schedules = await lastValueFrom(this.scheduleService.getScheduleByDoctorId(id));
      return schedules
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

  // Date filters
  dateFilter = (date: Date | null): boolean => {
    if (!date) return false;
    // Verifies if the given date is available
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
