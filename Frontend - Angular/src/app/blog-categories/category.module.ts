import { BlogCategoriesComponent } from './blog-categories.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [BlogCategoriesComponent],
  imports: [
    CommonModule
  ],
  exports: [
    BlogCategoriesComponent
  ]
})
export class CategoryModule { }
