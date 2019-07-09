import { CommentcommunicationService } from 'src/app/shared/commentcommunication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PostsService } from '../../shared/posts.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IRecommendedPost } from './IRecommendedPost';

@Component({
  selector: 'app-blog-recommendedposts',
  templateUrl: './blog-recommendedposts.component.html',
  styleUrls: ['./blog-recommendedposts.component.css']
})
export class BlogRecommendedpostsComponent implements OnInit {

  recommendations : IRecommendedPost[];
  @Input() postId : number;
  @Output() recommendedEvent = new EventEmitter<any>();
  constructor(private postService : PostsService, private commentCommunicationService : CommentcommunicationService) { }

  ngOnInit() {
    this.postService.getPostRecommendations(this.postId).subscribe(
      posts => this.recommendations = posts
    );
  }

  onClick($event){
    let id = $event.target.parentNode.getAttribute("data-id");
    this.recommendedEvent.emit(id);
    this.commentCommunicationService.raisePostChanged(id);
  }

}
