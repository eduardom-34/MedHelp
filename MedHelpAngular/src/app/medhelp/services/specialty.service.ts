import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Specialty } from '../interfaces/specialty.interface';
import { Observable } from 'rxjs';
import { environments } from '../../../environments/environments';

@Injectable({providedIn: 'root'})
export class SpecialtiesService {

  private baseUrl: string = environments.baseUrl;

  constructor(private http: HttpClient) { }

  getSpecialties():Observable<Specialty[]>{

    return this.http.get<Specialty[]>(`${ this.baseUrl }/specialty`)

  }

}
