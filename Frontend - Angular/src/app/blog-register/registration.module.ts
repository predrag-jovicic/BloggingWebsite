import { NgModule } from '@angular/core';
import { BlogRegisterComponent } from './blog-register.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BlogRegisterComponent
  ],
  imports: [
    SharedModule
  ],
  exports:[
    BlogRegisterComponent
  ]
})
export class RegistrationModule { }
