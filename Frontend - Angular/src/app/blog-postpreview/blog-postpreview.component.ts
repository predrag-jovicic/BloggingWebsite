import { QueryParam } from './QueryParam';
import { tap, filter } from 'rxjs/operators';
import { ActivatedRoute, Router, NavigationExtras } from '@angular/router';
import { PostsService } from './../shared/posts.service'; 
import { Component, OnInit, OnChanges } from '@angular/core';
import { IRecentPost } from './IRecentPost';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-blog-postpreview',
  templateUrl: './blog-postpreview.component.html',
  styleUrls: ['./blog-postpreview.component.css'],
  animations : [
    trigger('scale',[
      transition("void => *",[
        style({transform:'scale(1.1)',opacity:0}),
        animate('0.4s')
      ])
    ])
  ]
})
export class BlogPostpreviewComponent implements OnInit {
  private loadPageNumber = 1;
  private queryParams = new QueryParam('','','',1);
  private postService : PostsService;
  private activatedRoute : ActivatedRoute
  recentPosts : IRecentPost[];
  constructor(postService : PostsService, activatedRoute : ActivatedRoute, private router : Router) { 
    this.postService = postService;
    this.activatedRoute = activatedRoute;
  }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(queryParams => {
        this.queryParams.category = queryParams['category'] == undefined ? '' : queryParams['category'];
        this.queryParams.tag = queryParams['tag'] == undefined ? '' : queryParams['tag'];
        this.queryParams.searchQuery = queryParams['searchQuery'] == undefined ? '' : queryParams['searchQuery'],
        this.queryParams.pageNumber = 1;

      this.postService.getRecentPosts(this.queryParams).subscribe(posts => this.recentPosts = posts);
    });
  }

  onLoadMore(){
    ++this.loadPageNumber;
    this.queryParams.pageNumber = this.loadPageNumber;
      this.postService.getRecentPosts(this.queryParams).subscribe(posts => {
        if(posts.length == 0)
          document.querySelector('#load-more-post').remove();
        for(let post of posts)
          this.recentPosts.push(post);
      });
  }

}
