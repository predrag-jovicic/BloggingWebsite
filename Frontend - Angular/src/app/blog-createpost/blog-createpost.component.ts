import { INewPost } from './../shared/ViewModels/INewPost';
import { PostsService } from './../shared/posts.service';
import { CategoriesService } from './../shared/categories.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { slide } from '../shared/Animations/slide';
import { scale } from '../shared/Animations/scale';
import { ICategory } from '../blog-categories/iCategory';
import { INewPost } from '../shared/ViewModels/INewPost';
import { Router } from '@angular/router';
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
  categories : ICategory[];
  constructor(private fb:FormBuilder, private categoriesService : CategoriesService, private postService : PostsService, private router:Router) { }

  ngOnInit() {
    this.categoriesService.getCategories().subscribe(
      categories => this.categories = categories
    );
    this.newPostForm = this.fb.group({
      title : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\.\\,\\!\\-\\&\\%\\#]{3,60}$")]],
      tags : ['',[Validators.required,Validators.pattern("^[\\w\\-\\s]{3,75}$")]],
      category : [0,Validators.min(1)],
      content : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\.\\@\\n\\,\\!\\-\\&\\%\\#]{3,}$")]]
    });
  }

  onSubmit(){
    if(!this.newPostForm.valid){
      alert("You cannot submit the form because your data is not valid.");
      return;
    }
    else{
      let tagsArray = this.newPostForm.controls.tags.value.split(' ');
      let tags : string[] = [];
      for(let tag of tagsArray){
        tags.push(tag); 
      }
      let newPost : INewPost = {
        title : this.newPostForm.controls.title.value,
        categoryId : this.newPostForm.controls.category.value,
        content : this.newPostForm.controls.content.value,
        tags : tags
      };
      this.postService.createPost(newPost).subscribe(
        result => { alert('You have created a new post'); this.router.navigate(['']); },
        error => alert(error.statusText)
      );
    }
  }

}