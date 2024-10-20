import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environments } from '../../../environments/environments';
import { Observable } from 'rxjs';
import { Category } from '../interfaces/cateogry.interface';

@Injectable({providedIn: 'root'})
export class CategoriesServices {

  private baseUrl = environments.baseUrl;

  constructor(private http: HttpClient) { }

  getCategories():Observable<Category[]> {

    return this.http.get<Category[]>(`${this.baseUrl}/category`)

  }


}
