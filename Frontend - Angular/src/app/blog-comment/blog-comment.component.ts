import { IComment } from './../blog-comments/IComment';
import { Component, OnInit, Input } from '@angular/core';
import { CommentcommunicationService } from 'src/app/shared/commentcommunication.service';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {

  @Input() replies : IComment[];

  constructor(private commentCommunicationService : CommentcommunicationService) { }

  ngOnInit() {
  }

  replyCommentSelected($event){
    this.commentCommunicationService.raiseEvent($event.target.getAttribute("data-id"));
  }
}
