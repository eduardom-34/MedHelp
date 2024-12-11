import { Injectable } from '@angular/core';
import { environments } from '../../../environments/environments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Schedule } from '../interfaces/schedules.interface';

@Injectable({providedIn: 'root'})
export class ServiceNameService {

  private baseUrl: string = environments.baseUrl;

  constructor( private http: HttpClient ) { }

  getSchedules(): Observable<Schedule[]>{
    return this.http.get<Schedule[]>(`${this.baseUrl}/schedule`)
  }

}
