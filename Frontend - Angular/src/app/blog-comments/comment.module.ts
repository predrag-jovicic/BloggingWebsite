import { SharedModule } from './../shared/shared.module';
import { BlogCommentComponent } from './blog-comment/blog-comment.component';
import { BlogCommentsComponent } from './blog-comments.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    BlogCommentsComponent,
    BlogCommentComponent
  ],
  imports: [
    SharedModule
  ],
  exports:[
    BlogCommentsComponent,
    BlogCommentComponent
  ]
})
export class CommentModule { }
