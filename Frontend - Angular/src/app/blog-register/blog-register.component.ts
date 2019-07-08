import { AuthenticationserviceService } from './../shared/authenticationservice.service';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { slideUp } from '../shared/Animations/slideUp';
import { IUserRegistration } from '../shared/ViewModels/IUserRegistration';
import { Router } from '@angular/router';

function passwordMatcher(c:AbstractControl) : { [key:string] : boolean} | null {
  let passw = c.get('password');
  let confpasswd = c.get('confpassword');
  if(passw.pristine || confpasswd.pristine)
    return null;
  if(passw.value === confpasswd.value)
    return null;
  else
    return { 'match':true};
}

@Component({
  selector: 'app-blog-register',
  templateUrl: './blog-register.component.html',
  styleUrls: ['./blog-register.component.css'],
  animations : [
    slideUp
  ]
})
export class BlogRegisterComponent implements OnInit {
  registerForm : FormGroup;
  constructor(private fb:FormBuilder,private authService : AuthenticationserviceService, private router: Router) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      firstname : ['',[Validators.required,Validators.pattern("^[A-Za-z\\s]{2,20}$")]],
      lastname : ['',[Validators.required,Validators.pattern("^[A-Za-z\\s]{2,30}$")]],
      email : ['',[Validators.required,Validators.email]],
      username : ['',[Validators.required,Validators.pattern("^[\\w\-\\.]{2,20}$")]],
      passwordGroup : this.fb.group({
        password : ['',[Validators.required]],
        confpassword : ['',[Validators.required]]
      },{validator:passwordMatcher}),
      biography : ['',Validators.pattern("^[\\w\\-\\,\\.\\!\\?\\(\\)\\n\\r\\s]{3,150}$")]
    });
  }

  onSubmit(){
    if(this.registerForm.valid){
      let newUser : IUserRegistration = {
        firstName : this.registerForm.controls.firstname.value,
        lastName : this.registerForm.controls.lastname.value,
        biography : this.registerForm.controls.biography.value,
        username : this.registerForm.controls.username.value,
        password : this.registerForm.controls.passwordGroup.value.password,
        email : this.registerForm.controls.email.value
      };
      this.authService.register(newUser).subscribe(
        result => {
          alert('You have successfully made an account. Check your e-mail account for a confirmation link.');
          this.router.navigate(['/login']);
        },
        error => alert(error.statusText)
      );
    }
    else{
      alert("Error. Invalid data");
    }
  }

}
