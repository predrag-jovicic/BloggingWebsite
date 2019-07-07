import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-blog-register',
  templateUrl: './blog-register.component.html',
  styleUrls: ['./blog-register.component.css'],
  animations : [
    trigger('slideUp',[
      transition("void => *",[
        style({transform:'translateY(35px)',opacity:0}),
        animate('0.6s')
      ])
    ])
  ]
})
export class BlogRegisterComponent implements OnInit {
  registerForm : FormGroup;
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      firstname : ['',[Validators.required,Validators.pattern("^[A-Za-z\\s]{2,20}$")]],
      lastname : ['',[Validators.required,Validators.pattern("^[A-Za-z\\s]{2,30}$")]],
      email : ['',[Validators.required,Validators.email]],
      username : ['',[Validators.required,Validators.pattern("^[\\w\-\\.]{2,20}$")]],
      password : ['',[Validators.required]],
      confpassword : ['',[Validators.required]],
      biography : ['',Validators.pattern("^[\\w\\-\\,\\.\\!\\?\\(\\)\\n\\r\\s]{3,150}$")]
    });
  }

  onSubmit(){
    if(this.registerForm.valid){
      alert("Submitted!");
      this.registerForm.reset();
    }
    else{
      alert("Error. Invalid data");
    }
  }

}
