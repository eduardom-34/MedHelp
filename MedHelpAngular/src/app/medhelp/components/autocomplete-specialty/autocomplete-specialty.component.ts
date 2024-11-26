import { Component, OnInit } from '@angular/core';
import { Specialty } from '../../interfaces/specialty.interface';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';

@Component({
  selector: 'autocomplete-specialty',
  templateUrl: './autocomplete-specialty.component.html',
  styleUrl: './autocomplete-specialty.component.css'
})
export class AutocompleteSpecialtyComponent implements OnInit{

  myControl = new FormControl<string | Specialty>('');

  options: Specialty[] = [];
  specialties: Specialty[] = [];
  filteredOptions: Observable<Specialty[]>;

  ngOnInit(): void {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => {
        const name = typeof value === 'string' ? value : value.name;
        return name ? this._filter(name as string) : this.options.slice();
      })
    )
  }

  displayFn(user: Specialty): string {
    return user && user.name ? user.name : '';
  }

  private _filter(specialtyName: string): Specialty[] {
    const filterValue = specialtyName.toLowerCase();

    return this.options.filter(option => option.name.toLowerCase().includes(filterValue));
  }


}
