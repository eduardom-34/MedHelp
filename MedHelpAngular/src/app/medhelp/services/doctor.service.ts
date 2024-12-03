import { Injectable } from '@angular/core';
import { environments } from '../../../environments/environments';
import { HttpClient } from '@angular/common/http';
import { Doctor } from '../interfaces/doctor.interface';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class DoctorService {

  private baseUrl: string = environments.baseUrl;

  constructor(private http: HttpClient) { }

  getDoctors(): Observable<Doctor[]>{
    return this.http.get<Doctor[]>(`${this.baseUrl}/doctor`)
  }

}