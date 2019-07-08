import { SharedModule } from './../shared/shared.module';
import { BlogLoginComponent } from './blog-login.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    BlogLoginComponent
  ],
  imports: [
    SharedModule
  ],
  exports:[
    BlogLoginComponent
  ]
})
export class LoginModule { }
