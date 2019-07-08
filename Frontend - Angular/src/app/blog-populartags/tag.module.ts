import { BlogPopulartagsComponent } from './blog-populartags.component';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    BlogPopulartagsComponent
  ],
  imports: [
    SharedModule
  ],
  exports : [
    BlogPopulartagsComponent
  ]
})
export class TagModule { }
