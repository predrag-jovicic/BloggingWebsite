import { AuthenticationserviceService } from './shared/authenticationservice.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BloggingSpaApp';
  visible=false;

  constructor(private router:Router, private authService : AuthenticationserviceService){
    
  }

  onClick(){
    this.visible = !this.visible;
  }

  onFilterSelected(){
    this.router.navigate(['']);
  }

  signOut(){
    this.authService.logOut();
    this.router.navigate(['']);
  }

}