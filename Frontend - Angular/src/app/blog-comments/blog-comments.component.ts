import { AuthenticationserviceService } from './../shared/authenticationservice.service';
import { CommentcommunicationService } from './../shared/commentcommunication.service';
import { IComment } from './IComment';
import { CommentsService } from './../shared/comments.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-blog-comments',
  templateUrl: './blog-comments.component.html',
  styleUrls: ['./blog-comments.component.css']
})
export class BlogCommentsComponent implements OnInit {
  commentFormGroup: FormGroup;
  @Input() postId : number;
  comments : IComment[];
  replyCommentId : number = null;
  constructor(private fb:FormBuilder, private commentsService : CommentsService, private commentCommunicationService : CommentcommunicationService, private authService : AuthenticationserviceService) { }

  ngOnInit() {
    this.commentsService.getCommentsByPost(this.postId).subscribe(comments => this.comments = comments);
    this.commentCommunicationService.replyCommentSelected.subscribe(
      result => {
        this.replyCommentId = result;
      }
    );
    if(this.authService.currentUser == null){
      this.commentFormGroup = this.fb.group({
        name : ['',[Validators.required,Validators.pattern("[A-z][\\w\\s\\.\\,]{2,25}$")]],
        message : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\!\\.\\,\\@\\#\\-\\n]{3,300}$")]]
      });
    }
    else{
      this.commentFormGroup = this.fb.group({
        message : ['',[Validators.required,Validators.pattern("^[\\w\\s\\?\\!\\.\\,\\@\\#\\-\\n]{3,300}$")]]
      });
    }
  }

  replyCommentSelected($event){
    this.replyCommentId = $event.target.getAttribute("data-id");
  }

  onSubmit(){
    if(this.commentFormGroup.invalid){
      alert("You've entered invalid data.");
      return;
    }
    else{
      let comment = {
        name : this.authService.currentUser != null ? null : this.commentFormGroup.controls.name.value,
        content : this.commentFormGroup.controls.message.value,
        postId : this.postId,
        replyOnId : this.replyCommentId
      };
      this.commentsService.postComment(comment).subscribe(
        result => alert("The comment will be visible after a moderator confirms it obeys our rules."),
        error => alert(error.textStatus)
      );
    }
  }

}
