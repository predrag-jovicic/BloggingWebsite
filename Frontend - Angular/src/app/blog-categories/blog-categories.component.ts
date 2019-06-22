import { CategoriesService } from './../shared/categories.service';
import { Component, OnInit } from '@angular/core';
import { ICategory } from './iCategory';

@Component({
  selector: 'app-blog-categories',
  templateUrl: './blog-categories.component.html',
  styleUrls: ['./blog-categories.component.css']
})
export class BlogCategoriesComponent implements OnInit {
  getCategoriesService : CategoriesService;
  categories : ICategory[];

  constructor(getCategoriesService : CategoriesService) {
    this.getCategoriesService = getCategoriesService;
  }

  ngOnInit() {
    this.getCategoriesService.getCategories().subscribe(categories => this.categories = categories);
  }

  onClick($event){
    console.log($event.target.getAttribute("data-id"));
  }

}
