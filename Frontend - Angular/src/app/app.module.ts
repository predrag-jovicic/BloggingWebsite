import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BlogPostpreviewComponent } from './blog-posts/blog-postpreview/blog-postpreview.component';
import { BlogPostdetailsComponent } from './blog-posts/blog-postdetails/blog-postdetails.component';
import { BlogCreatepostComponent } from './blog-posts/blog-createpost/blog-createpost.component';
import { NotFoundPageComponentComponent } from './shared/not-found-page-component/not-found-page-component.component';
import { BlogLoginComponent } from './blog-login/blog-login.component';
import { BlogRegisterComponent } from './blog-register/blog-register.component';
import { AuthguardService } from './shared/AuthguardService';
import { BlogModeratorpanelComponent } from './blog-moderatorpanel/blog-moderatorpanel.component';
import { CategoryModule } from './blog-categories/category.module';
import { CommentModule } from './blog-comments/comment.module';
import { TagModule } from './blog-populartags/tag.module';
import { LoginModule } from './blog-login/login.module';
import { RegistrationModule } from './blog-register/registration.module';
import { ModeratorpanelModule } from './blog-moderatorpanel/moderatorpanel.module';
import { PostModule } from './blog-posts/post.module';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundPageComponentComponent
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
    CategoryModule,
    CommentModule,
    TagModule,
    LoginModule,
    RegistrationModule,
    ModeratorpanelModule,
    PostModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
