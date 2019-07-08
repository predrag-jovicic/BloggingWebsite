import { PostsService } from '../../shared/posts.service';
import { Component, OnInit, Input } from '@angular/core';
import { IRecommendedPost } from './IRecommendedPost';

@Component({
  selector: 'app-blog-recommendedposts',
  templateUrl: './blog-recommendedposts.component.html',
  styleUrls: ['./blog-recommendedposts.component.css']
})
export class BlogRecommendedpostsComponent implements OnInit {

  recommendations : IRecommendedPost[];
  @Input() postId : number;
  constructor(private postService : PostsService) { }

  ngOnInit() {
    this.postService.getPostRecommendations(this.postId).subscribe(
      posts => this.recommendations = posts
    );
  }

}
