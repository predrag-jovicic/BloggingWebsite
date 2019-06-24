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

  constructor(private router:Router){
    
  }

  onClick(){
    this.visible = !this.visible;
  }

  onTagSelected(){
    this.router.navigate(['']);
  }

}