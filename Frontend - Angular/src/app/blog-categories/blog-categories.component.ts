import { PostsService } from './../shared/posts.service';
import { CategoriesService } from './../shared/categories.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ICategory } from './iCategory';
import { NavigationExtras, Router } from '@angular/router';
import { slide } from '../shared/Animations/slide';

@Component({
  selector: 'app-blog-categories',
  templateUrl: './blog-categories.component.html',
  styleUrls: ['./blog-categories.component.css']
})
export class BlogCategoriesComponent implements OnInit {
  private getCategoriesService : CategoriesService;
  categories : ICategory[];
  @Output() categorySelected = new EventEmitter<string>();
  constructor(getCategoriesService : CategoriesService, private postsService : PostsService, private router : Router) {
    this.getCategoriesService = getCategoriesService;
  }

  ngOnInit() {
    this.getCategoriesService.getCategories().subscribe(categories => this.categories = categories);
  }

  onClick($event){
    let navigationExtras: NavigationExtras = { 
      queryParams: { 'category': $event.target.getAttribute("data-id")},
      queryParamsHandling: "merge"
    };
    this.router.navigate(['/home'],navigationExtras);
    return false;
  }

}
