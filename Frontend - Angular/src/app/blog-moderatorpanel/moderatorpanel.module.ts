import { BlogModeratorpanelComponent } from './blog-moderatorpanel.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    BlogModeratorpanelComponent
  ],
  imports: [
    SharedModule
  ],
  exports:[
    BlogModeratorpanelComponent
  ]
})
export class ModeratorpanelModule { }
