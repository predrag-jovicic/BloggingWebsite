import { AuthenticationserviceService } from './shared/authenticationservice.service';
import { Component } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';

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

  onEnterKey($event){
    let navigationExtras: NavigationExtras = { 
      queryParams: { 'searchQuery': $event.target.value},
      queryParamsHandling: "merge"
    };
    this.router.navigate(['/home'],navigationExtras);
  }

  signOut(){
    this.authService.logOut();
    this.router.navigate(['/home']);
  }

}