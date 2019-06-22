import { PostsService } from './../shared/posts.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPost } from './IPost';

@Component({
  selector: 'app-blog-postdetails',
  templateUrl: './blog-postdetails.component.html',
  styleUrls: ['./blog-postdetails.component.css']
})
export class BlogPostdetailsComponent implements OnInit {
  private post : IPost;
  /* Fetch post data and display it. */
  constructor(private route: ActivatedRoute, private postsService : PostsService) { }

  ngOnInit() {
    var id = this.route.snapshot.params['id'];
    this.postsService.getPostDetails(id).subscribe(post => this.post = post);
  }

}
