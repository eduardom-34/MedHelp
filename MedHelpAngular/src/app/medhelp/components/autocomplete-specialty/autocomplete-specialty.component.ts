import { Component, OnInit } from '@angular/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { FormControl } from '@angular/forms';
import { map, Observable, of, startWith } from 'rxjs';
import { SpecialtiesService } from '../../services/specialty.service';

@Component({
  selector: 'autocomplete-specialty',
  templateUrl: './autocomplete-specialty.component.html',
  styleUrl: './autocomplete-specialty.component.css'
})
export class AutocompleteSpecialtyComponent implements OnInit{

  myControl = new FormControl<string | Specialty>('');

  options: Specialty[] = [];
  specialties: Specialty[] = [];
  filteredOptions: Observable<Specialty[]> = of([]);

  constructor(private specialtiesService: SpecialtiesService) {}

  ngOnInit(): void {

    this.specialtiesService.getSpecialties()
      .subscribe( specialties => {
        this.specialties = specialties;
        this.options = specialties;

    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => {
        if( value == null) {
          return this.options.slice();
        }
        const name = typeof value === 'string' ? value : value.name;
        return name ? this._filter(name as string) : this.options.slice();
      })
    )
  });

      console.log("specialties");
      console.log(this.specialties);

  }

  displayFn(user: Specialty): string {
    return user && user.name ? user.name : '';
  }

  private _filter(specialtyName: string): Specialty[] {
    const filterValue = specialtyName.toLowerCase();

    return this.options.filter(option => option.name.toLowerCase().includes(filterValue));
  }


}
