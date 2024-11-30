import { Component, OnInit } from '@angular/core';
import { Category } from '../../interfaces/category.interface';
import { CategoriesServices } from '../../services/category.service';

@Component({
  selector: 'app-list-categories',
  templateUrl: './list-categories.component.html',
  styleUrl: './list-categories.component.css'
})
export class ListCategoriesPageComponent implements OnInit {

  public categories: Category[] = [];

  constructor( private categoriesService: CategoriesServices) {}

  ngOnInit(): void {
    this.categoriesService.getCategories()
      .subscribe( categories => this.categories = categories)
  }

}
