import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../interfaces/cateogry.interface';

@Component({
  selector: 'category-card',
  templateUrl: './category-card.component.html',
  styleUrl: './category-card.component.css'
})
export class CategoryCardComponent implements OnInit{

  @Input()
  public category?: Category;

  ngOnInit(): void {
    if( !this.category ) throw Error('Category property is requiered')
  }

}
