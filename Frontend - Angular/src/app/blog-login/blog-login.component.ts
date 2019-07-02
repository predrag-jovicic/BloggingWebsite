import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-blog-login',
  templateUrl: './blog-login.component.html',
  styleUrls: ['./blog-login.component.css']
})
export class BlogLoginComponent implements OnInit {

  loginForm : FormGroup;
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      username : ['',[Validators.required,Validators.pattern("^[\\w\-\\.]{2,20}$")]],
      password : ['',Validators.required]
    });
  }

  onSubmit(){
    alert("it works");
  }

}
