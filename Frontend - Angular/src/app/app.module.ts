import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { BlogCategoriesComponent } from './blog-categories/blog-categories.component';
import { BlogPopulartagsComponent } from './blog-populartags/blog-populartags.component';
import { BlogPostpreviewComponent } from './blog-postpreview/blog-postpreview.component';
import { BlogPostdetailsComponent } from './blog-postdetails/blog-postdetails.component';
import { BlogCreatepostComponent } from './blog-createpost/blog-createpost.component';
import { NotFoundPageComponentComponent } from './not-found-page-component/not-found-page-component.component';
import { BlogCommentsComponent } from './blog-comments/blog-comments.component';
import { BlogRecommendedpostsComponent } from './blog-recommendedposts/blog-recommendedposts.component';
import { BlogCommentComponent } from './blog-comment/blog-comment/blog-comment.component';
import { BlogLoginComponent } from './blog-login/blog-login.component';
import { BlogRegisterComponent } from './blog-register/blog-register.component';
import { AuthguardService } from './shared/AuthguardService';
import { BlogModeratorpanelComponent } from './blog-moderatorpanel/blog-moderatorpanel.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogCategoriesComponent,
    BlogPopulartagsComponent,
    BlogPostpreviewComponent,
    BlogPostdetailsComponent,
    BlogCreatepostComponent,
    NotFoundPageComponentComponent,
    BlogCommentsComponent,
    BlogRecommendedpostsComponent,
    BlogCommentComponent,
    BlogLoginComponent,
    BlogRegisterComponent,
    BlogModeratorpanelComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: BlogPostpreviewComponent },
      { path: 'home', component: BlogPostpreviewComponent },
      { path: 'postdetails/:id', component: BlogPostdetailsComponent},
      { path: 'createpost', component: BlogCreatepostComponent, canActivate : [AuthguardService], data : {roles:["Blogger"]}},
      { path: 'login', component: BlogLoginComponent},
      { path: 'register',component:BlogRegisterComponent},
      { path: 'moderator-panel',component:BlogModeratorpanelComponent, canActivate : [AuthguardService],data:{roles:["Moderator"]}},
      { path: '**', component: NotFoundPageComponentComponent}
    ]),
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
