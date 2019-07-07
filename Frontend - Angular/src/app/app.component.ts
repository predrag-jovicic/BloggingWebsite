import { AuthenticationserviceService } from './shared/authenticationservice.service';
import { Component } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { trigger, transition, animate, style } from '@angular/animations';
import { setClassMetadata } from '@angular/core/src/render3';
import { shouldCallLifecycleInitHook } from '@angular/core/src/view';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations : [
    trigger('fade',[
      transition("void => *",[
        style({opacity:0}),
        animate('2s 0.5s')
      ])
    ]),
    trigger('extend',[
      transition("void => *",[
        style({width:0,opacity:0}),
        animate('0.8s')
      ])
    ])
  ]
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