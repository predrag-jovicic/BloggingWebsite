import { AuthenticationserviceService } from './../../shared/authenticationservice.service';
import { PostsService } from '../../shared/posts.service';
import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPost } from './IPost';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-blog-postdetails',
  templateUrl: './blog-postdetails.component.html',
  styleUrls: ['./blog-postdetails.component.css'],
  animations: [
    trigger('slideLeft',[
      transition("void => *",[
        style({transform:'translateX(35px)',opacity:0}),
        animate('0.6s')
      ])
    ]),
    trigger('slideUp',[
      transition("void => *",[
        style({transform:'translateY(35px)',opacity:0}),
        animate('0.6s')
      ])
    ])
  ]
})
export class BlogPostdetailsComponent implements OnInit {
  post : IPost;
  private postId : number;
  /* Fetch post data and display it. */
  constructor(private route: ActivatedRoute, private postsService : PostsService, private router : Router, private authService : AuthenticationserviceService) { }

  ngOnInit() {
    this.postId = this.route.snapshot.params['id'];
    this.postsService.getPostDetails(this.postId).subscribe(post => this.post = post);
  }

  onChangePost(id){
    this.postsService.getPostDetails(id).subscribe(post => this.post = post);
    this.postId = id;
    this.router.navigate(['/postdetails',id]);
  }

  delete(){
    let flag = confirm("Do you really want to delete this post?");
    if(flag){
      this.postsService.deletePost(this.postId).subscribe(result => {
        alert("The post has been deleted.");
        this.router.navigate(['']);
      },error => alert(error.statusText));
    }
  }

}
