import { PostsService } from './../shared/posts.service';
import { Component, OnInit } from '@angular/core';
import { IRecentPost } from './IRecentPost';

@Component({
  selector: 'app-blog-postpreview',
  templateUrl: './blog-postpreview.component.html',
  styleUrls: ['./blog-postpreview.component.css']
})
export class BlogPostpreviewComponent implements OnInit {
  private postService : PostsService;
  recentPosts : IRecentPost[];
  constructor(postService : PostsService) { 
    this.postService = postService;
  }

  ngOnInit() {
    this.postService.getRecentPosts().subscribe(posts => this.recentPosts = posts);
    this.postService.recentPostsByTag$.subscribe(posts => this.recentPosts = posts);
    this.postService.recentPostsByCategory$.subscribe(posts => this.recentPosts = posts);
  }

}
