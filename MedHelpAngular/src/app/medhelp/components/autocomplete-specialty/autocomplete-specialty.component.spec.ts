import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutocompleteSpecialtyComponent } from './autocomplete-specialty.component';

describe('AutocompleteSpecialtyComponent', () => {
  let component: AutocompleteSpecialtyComponent;
  let fixture: ComponentFixture<AutocompleteSpecialtyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AutocompleteSpecialtyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AutocompleteSpecialtyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
