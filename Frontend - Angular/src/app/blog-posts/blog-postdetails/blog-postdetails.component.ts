import { PostsService } from '../../shared/posts.service';
import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPost } from './IPost';
import { trigger, transition, style, animate } from '@angular/animations';
import { EventEmitter } from 'events';

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
  /* Fetch post data and display it. */
  constructor(private route: ActivatedRoute, private postsService : PostsService) { }

  ngOnInit() {
    var id = this.route.snapshot.params['id'];
    this.postsService.getPostDetails(id).subscribe(post => this.post = post);
  }

  onChangePost(id){
    this.postsService.getPostDetails(id).subscribe(post => this.post = post);
  }

}
