import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { map, Observable, of, startWith } from 'rxjs';

@Component({
  selector: 'app-autocomplete',
  templateUrl: './autocomplete.component.html',
  styleUrl: './autocomplete.component.css'
})
export class AutocompleteComponent implements OnInit{
  @Input() options: any[] = [];
  @Input() displayWith!: (item: any) => string;
  @Input() placeholder: string = 'Search...';
  @Input() control!: FormControl;
  @Output() selected = new EventEmitter<any>();

  public filteredOptions: Observable<any[]> = of([]);

  ngOnInit(): void {
    this.filteredOptions = this.control.valueChanges.pipe(
      startWith(''),
      map(value => {
        const filterValue = typeof value === 'string' ? value : this.displayWith(value);
        return filterValue ? this.filter(filterValue) : this.options.slice();
      })
    );
  }

  onFocus(): void {
    this.filteredOptions = of(this.options);
  }

  onInput(): void {
    const value = this.control.value;
    const name = typeof value === 'string' ? value : this.displayWith(value);
    this.filteredOptions = of(
      name ? this.filter(name) : this.options.slice()
    );
  }

  onOptionSelected(option: any): void {
    this.selected.emit(option);
  }

  private filter(value: string): any[] {
    const filterValue = value.toLowerCase();
    return this.options.filter( option => this.displayWith(option).toLocaleLowerCase().includes(filterValue));
  }

}
