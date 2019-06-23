import { IComment } from './../../blog-comments/IComment';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-blog-comment',
  templateUrl: './blog-comment.component.html',
  styleUrls: ['./blog-comment.component.css']
})
export class BlogCommentComponent implements OnInit {

  @Input() replies : IComment[];

  constructor() { }

  ngOnInit() {
  }

}
