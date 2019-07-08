import { CommentModule } from './../blog-comments/comment.module';
import { BlogRecommendedpostsComponent } from './blog-recommendedposts/blog-recommendedposts.component';
import { BlogPostpreviewComponent } from './blog-postpreview/blog-postpreview.component';
import { BlogPostdetailsComponent } from './blog-postdetails/blog-postdetails.component';
import { BlogCreatepostComponent } from './blog-createpost/blog-createpost.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BlogCreatepostComponent,
    BlogPostdetailsComponent,
    BlogPostpreviewComponent,
    BlogRecommendedpostsComponent
  ],
  imports: [
    SharedModule,
    CommentModule
  ],
  exports:[
    BlogCreatepostComponent,
    BlogPostdetailsComponent,
    BlogPostpreviewComponent,
    BlogRecommendedpostsComponent
  ]
})
export class PostModule { }
