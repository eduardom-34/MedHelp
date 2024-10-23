import { Component, model, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';

@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrl: './appointment-page.component.css',
  providers: [provideNativeDateAdapter()],
})
export class AppointmentPageComponent implements OnInit {

  specialties = [
    { id: 1, name: 'Cardiology' },
    { id: 2, name: 'Dermatology' },
    // Agrega más especialidades según tus datos
  ];

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

  constructor(private fb: FormBuilder) {
    this.appointmentForm = this.fb.group({
      specialty: ['', Validators.required],
      date: [''],
      time: [''],
      doctor: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // console.log(this.appointmentForm);

   }

  onDateSelected(selectedDate: Date): void {
    this.appointmentForm.patchValue({ date: selectedDate });
  }

}
