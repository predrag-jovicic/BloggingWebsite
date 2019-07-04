import { AuthenticationserviceService } from './../shared/authenticationservice.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog-login',
  templateUrl: './blog-login.component.html',
  styleUrls: ['./blog-login.component.css']
})
export class BlogLoginComponent implements OnInit {

  loginForm : FormGroup;
  constructor(private fb:FormBuilder,private authService : AuthenticationserviceService,private router:Router) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      username : ['',[Validators.required,Validators.pattern("^[\\w\-\\.]{2,20}$")]],
      password : ['',Validators.required]
    });
  }

  onSubmit(){
    if(this.loginForm.invalid){
      alert("You've entered invalid data.");
      return;
    }
    else{
      let user = {
        username : this.loginForm.controls.username.value,
        password : this.loginForm.controls.password.value
      };
      this.authService.logIn(user).subscribe(result => {
          localStorage.setItem('loggedUser',JSON.stringify(result.body));
          this.router.navigate(['']);
      }, error => {
        alert(error.statusText);
      });
    }
  }

}
