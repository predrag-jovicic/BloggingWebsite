import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { slide } from '../shared/Animations/slide';
import { scale } from '../shared/Animations/scale';
@Component({
  selector: 'app-blog-createpost',
  templateUrl: './blog-createpost.component.html',
  styleUrls: ['./blog-createpost.component.css'],
  animations: [
    slide,
    scale
  ]
})
export class BlogCreatepostComponent implements OnInit {
  newPostForm : FormGroup;
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.newPostForm = this.fb.group({
      title : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\.\\,\\!\\-\\&\\%\\#]{3,60}$")]],
      tags : ['',[Validators.required,Validators.pattern("^[\\w\\-\\s]{3,20}$")]],
      category : [0,Validators.min(1)],
      content : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\.\\@\\n\\,\\!\\-\\&\\%\\#]{3,}$")]],
      photos : [null]
    });
  }

  onSubmit(){
    if(!this.newPostForm.valid){
      alert("You cannot submit the form because your data is not valid.");
      return;
    }
    else{
      console.log(this.newPostForm);
      alert("You've submitted the form!");
      this.newPostForm.reset();
    }
  }

}