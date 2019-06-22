import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-blog-comments',
  templateUrl: './blog-comments.component.html',
  styleUrls: ['./blog-comments.component.css']
})
export class BlogCommentsComponent implements OnInit {
  commentFormGroup: FormGroup;
  constructor(private fb:FormBuilder) { }

  ngOnInit() {
    this.commentFormGroup = this.fb.group({
      name : ['',[Validators.required,Validators.pattern("[A-z][\\w\\s\\.\\,]{2,25}$")]],
      message : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\!\\.\\,\\@\\#\\-\\n]{3,300}$")]]
    });
  }

}
